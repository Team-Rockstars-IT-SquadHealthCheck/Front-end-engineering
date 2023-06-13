using Engineering_ASPNET.DAL;
using Newtonsoft.Json;
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

        public void SubmitAnswers(IEnumerable<AnswerModel> answers, string id)
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
            _repository.PostStatus(id);
        }
        public IEnumerable<Survey> GetSurveys()
        {
            Task<string> surveysString = _repository.GetSurveys();
            surveysString.Wait();
            string surveysJson = surveysString.Result;
            List<Survey> surveys = JsonConvert.DeserializeObject<List<Survey>>(surveysJson);
            return surveys;
        }

        public Survey GetSurveyBy(string id)
        {
            Task<string> surveysString = _repository.GetSurveyBy(id);
            surveysString.Wait();
            string surveysJson = surveysString.Result;
            Survey survey = JsonConvert.DeserializeObject<Survey>(surveysJson);
            return survey;
        }

        public Url ValidateID(string id)
        {
            Task<string> urlString = _repository.ValidateID(id);

            urlString.Wait();
            string urlJson = urlString.Result;

            Url url = JsonConvert.DeserializeObject<Url>(urlJson);
            return url;
        }
        public List<AnswerModel> GetAnswersBy(string id)
        { 
            Task<string> answersString = _repository.GetAnswersBy(id);
            answersString.Wait();
            string answerJson = answersString.Result;
            List<AnswerModel> answers = JsonConvert.DeserializeObject<List<AnswerModel>>(answerJson);
            return answers;
        }
    }
}
