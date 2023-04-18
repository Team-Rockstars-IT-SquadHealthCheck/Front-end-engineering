using Engineering_ASPNET.DAL;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Reflection.Metadata.Ecma335;

namespace Engineering_ASPNET.BLL
{
    public class HomeService
    {
        private readonly IHomeRepository _repository;
        public HomeService(IHomeRepository repository)
        {
            _repository = repository;
        }
        public HelloWorld HelloWorld()
        {
            Task<HelloWorld> taskHelloWorldDto = _repository.HelloWorld();
            taskHelloWorldDto.Wait();
            HelloWorld helloWorldDto = taskHelloWorldDto.Result;
            HelloWorld helloWorld = new HelloWorld
            {
                httpResponseMessage = helloWorldDto.httpResponseMessage
            };
            return helloWorld;
        }

        public void SubmitAnswers(IEnumerable<AnswerModel> answers)
        {
            List<AnswerModel> answerDtos = new List<AnswerModel>();

            foreach (var answer in answers)
            {
                AnswerModel answerDto = new AnswerModel
                {
                    QuestionId = answer.QuestionId,
                    UserId = answer.UserId,
                    Answer = answer.Answer,
                    Comment = answer.Comment
                };
                answerDtos.Add(answerDto);
            }
            _repository.SubmitAnswers(answerDtos);

        }
        public IEnumerable<Survey> GetSurveys()
        {
            Task<string> surveysString = _repository.GetSurveys();
            List<Survey> surveyDtos = new List<Survey>();
            surveysString.Wait();
            string surveysJson = surveysString.Result;
            JObject obj = JObject.Parse(surveysJson);
            var surveys = obj["surveys"];
            foreach (var survey in surveys)
            {
                var QuestionsArray = survey["questions"].Value<JArray>();

                Survey surveyDto = new Survey
                {
                    Survey_ID = (int)survey["id"],
                    Description = (string)survey["name"],
                    Name = (string)survey["description"],
                    Questions = QuestionsArray.ToObject<List<Question>>()
                };
                surveyDtos.Add(surveyDto);
            };
            return surveyDtos;
        }

        public string ValidateID(string id)
        {
            Task<string> user_ID = _repository.ValidateID(id);
            user_ID.Wait();
            string User_ID = user_ID.Result;
            return User_ID;
        }
    }
}
