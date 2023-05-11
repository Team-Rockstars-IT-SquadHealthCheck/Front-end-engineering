using Engineering_ASPNET.BLL;
using Engineering_ASPNET.DAL;
using Engineering_ASPNET.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Reflection;
using System.Security.Principal;

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

    public IActionResult Index(string id, FormSubmissionModel model)
    {
        int user_ID = 0;

        if (id != null)
        {
			user_ID = _homeService.ValidateID(id);
            HttpContext.Session.SetInt32("user_id", user_ID);
        }
        if (user_ID == 0 && HttpContext.Session.GetInt32("user_id") == null)
        {
            return RedirectToAction("UserError");
        }

        // HelloWorld helloWorld = _homeService.HelloWorld();
        // string httpResponseMessage = helloWorld.httpResponseMessage;
        // Console.WriteLine(httpResponseMessage);
        // ViewData["httpResponseMessage"] = httpResponseMessage;
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Index(string id)
    {
        if (id != null && GetQuestionsBy(9) != null)
        {
            return RedirectToAction("Form", "Home", new { id } );
        }
        return View(id);
    }
    public IActionResult Form(string id)
    {
        var questions = GetQuestionsBy(9);

        if (id != null && _homeService.ValidateID(id) != 0)
        {
            FormSubmissionModel model = new FormSubmissionModel();
            model.Guid = id;
            model.questions = questions;

            return View(model);
        }
        else
        {
            return RedirectToAction(nameof(UserError));
        }
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Form(FormSubmissionModel model, string id)
    {
        var questions = GetQuestionsBy(9);

        model.Guid = id;
        model.questions = questions;

        if (_homeService.ValidateID(id) != 0) 
        {
            int user_ID = (int)HttpContext.Session.GetInt32("user_id");
            if (!ModelState.IsValid)
            {
                string validation = "Je moet alles invullen!";
                ViewData["validationMessage"] = validation;
                return View(model);
            }
            //if (model.Answers == null || model.Answers.Count != model.questions.Count)
            //{
            //    string validation = "Je moet alles invullen!";
            //    ViewData["validationMessage"] = validation;
            //    return View(model);
            //}
            PropertyInfo[] modelProperties = model.GetType().GetProperties();
            List<int?> questionValues = GetAnswers(model);
            List<AnswerModel> answers = new List<AnswerModel>();

            int questionid = 0;
            foreach (int? question in questionValues)
            {
                AnswerModel answer = new AnswerModel
                {
                    QuestionId = 2,
                    UserId = user_ID, // temprary for test
                    Answer = question.Value,
                    Comment = "" // for now empty
                };
                answers.Add(answer);
			}

            _homeService.SubmitAnswers(answers);
            return RedirectToAction("BedanktScherm", "Home", model);

        }
        return RedirectToAction(nameof(UserError));

    }
    public IActionResult BedanktScherm(FormSubmissionModel model)
    {
        return View(model);
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

    [NonAction]
    public List<Question> GetQuestionsBy(int id)
    {
        List<Question> questions = new List<Question>();

        var survey = _homeService.GetSurveyBy(id);

        questions.AddRange(survey.Questions);
        return questions;
    }
    public IActionResult UserError()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}