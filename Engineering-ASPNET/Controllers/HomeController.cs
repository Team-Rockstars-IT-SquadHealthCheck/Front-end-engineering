using Engineering_ASPNET.BLL;
using Engineering_ASPNET.DAL;
using Engineering_ASPNET.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Reflection;

namespace Engineering_ASPNET.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly HomeService _homeService;

    public HomeController(ILogger<HomeController> logger)
    {
        _homeService = new HomeService(new HomeRepository());
        _logger = logger;
    }

    public IActionResult Index(string id)
    {
        //HelloWorld helloWorld = _homeService.HelloWorld();
        //string httpResponseMessage = helloWorld.httpResponseMessage;
        //Console.WriteLine(httpResponseMessage);
        //ViewData["httpResponseMessage"] = httpResponseMessage;
        FormSubmissionModel model = new FormSubmissionModel();

        model.Guid = id;
        return View(model);
    }
    public IActionResult Form(string id)
    {
        FormSubmissionModel model = new FormSubmissionModel();
        model.Guid=id;
        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Form(FormSubmissionModel model, string id)
    {
        if (!ModelState.IsValid)
        {
            string validation = "Je moet alles invullen!";
            ViewData["validationMessage"] = validation;
            return View();
        }
        PropertyInfo[] modelProperties = model.GetType().GetProperties();
        List<int?> questionValues = GetAnswers(model);
        List<AnswerModel> answers = new List<AnswerModel>();

        int questionid = 0;
        foreach (int? question in questionValues)
        {
            questionid++;
            AnswerModel answer = new AnswerModel
            {
                QuestionId = questionid,
                UserId = 1, // temprary for test
                Answer = question.Value,
                Comment = id // for now empty
            };
            answers.Add(answer);
        }

        _homeService.SubmitAnswers(answers);
        return RedirectToAction(nameof(BedanktScherm));
    }
    public IActionResult BedanktScherm()
    {
        return View();
    }

    [NonAction]
    public List<int?> GetAnswers(FormSubmissionModel model)
    {
        List<int?> questionValues = new List<int?>();

        foreach (PropertyInfo prop in model.GetType().GetProperties())
        {
            if (prop.Name.StartsWith("Question") && prop.PropertyType == typeof(int?))
            {
                int? value = (int?)prop.GetValue(model);
                questionValues.Add(value);
            }
        }
        return questionValues;
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}