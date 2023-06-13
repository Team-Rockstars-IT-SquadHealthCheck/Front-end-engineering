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
			user_ID = _homeService.ValidateID(id).userid;
            HttpContext.Session.SetInt32("user_id", user_ID);
        }
        if (user_ID == 0 && HttpContext.Session.GetInt32("user_id") == null)
        {
            return RedirectToAction("UserError");
        }

        HelloWorld helloWorld = _homeService.HelloWorld();
        string httpResponseMessage = helloWorld.httpResponseMessage;
        Console.WriteLine(httpResponseMessage);
        ViewData["httpResponseMessage"] = httpResponseMessage;
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Index(string id)
    {
        Url url = _homeService.ValidateID(id);

        if (id != null && GetQuestionsBy(id) != null)
        {
            if (url.status != 1)
            {
                return RedirectToAction("Form", "Home", new { id });
            }
            else if (url.status == 1)
            {
                FormSubmissionModel model = new FormSubmissionModel();
                List<AnswerModel> answersModels = _homeService.GetAnswersBy(id);
                List<int> answers = new List<int>();
                foreach (var answerModel in answersModels)
                {
                    answers.Add(answerModel.Answer);
                }

                foreach (var answer in answers)
                {
                    setColors(model, answer);
                }
                model.Guid = id;
                model.Answers = answers;
                return RedirectToAction("BedanktScherm", "Home", model);
            }
        }
        return View();
    }
    public IActionResult Form(string id)
    {
        var questions = GetQuestionsBy(id);


        Url url = _homeService.ValidateID(id);

        if (id != null && url.userid != 0)
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
        model.questions = GetQuestionsBy(id); ;

        Url url = _homeService.ValidateID(id);

        if (url.userid != 0) 
        {
            int user_ID = (int)HttpContext.Session.GetInt32("user_id");

			if (model.Answers == null || model.Answers.Count != model.questions.Count)
            {
                string validation = "Je moet alles invullen!";
                ViewData["validationMessage"] = validation;
                return View(model);
            }

            List<int> questionValues = model.Answers;
            List<AnswerModel> answers = new List<AnswerModel>();;

            for (int i = 0; i < questionValues.Count; i++)
            {
                AnswerModel answer = new AnswerModel
                {
                    QuestionId = model.questions[i].Question_ID,
                    UserId = user_ID, // temprary for test
                    Answer = questionValues[i],
                    Comment = "" // for now empty
                };
                setColors(model, answer.Answer);
                answers.Add(answer);
            }

            _homeService.SubmitAnswers(answers, id);
            model.Guid = id;
            return RedirectToAction("BedanktScherm", "Home", model);

        }
        return RedirectToAction(nameof(UserError));

    }
    public IActionResult BedanktScherm(FormSubmissionModel model)
    {

        model.questions = GetQuestionsBy(model.Guid);
        return View(model);
    }

    [NonAction]
    public List<Question> GetQuestionsBy(string id)
    {
        List<Question> questions = new List<Question>();

        if (!string.IsNullOrEmpty(id))
        {
            var survey = _homeService.GetSurveyBy(id);

            questions.AddRange(survey.Questions);
            return questions;
        }
        return null;
    }

    [NonAction]
    public FormSubmissionModel setColors(FormSubmissionModel model, int questionValues)
    {
        if (questionValues == 0)
        {
            model.questionTextColors.Add("text-green");
            model.questionBackgroundColors.Add("result-green");
        }
        else if (questionValues == 1)
        {
            model.questionTextColors.Add("text-orange");
            model.questionBackgroundColors.Add("result-orange");
        }
        else if (questionValues == 2)
        {
            model.questionTextColors.Add("text-red");
            model.questionBackgroundColors.Add("result-red");
        }
        return model;
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