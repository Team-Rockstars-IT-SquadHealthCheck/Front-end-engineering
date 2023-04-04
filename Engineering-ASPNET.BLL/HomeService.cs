using Engineering_ASPNET.DAL;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Net.Http;
using System.Reflection.Metadata.Ecma335;

namespace Engineering_ASPNET.BLL
{
    public class HomeService
    {
        private readonly HomeRepository _repository;
        public HomeService()
        {
            _repository = new HomeRepository();
        }
        public HelloWorld HelloWorld()
        {
            Task<HelloWorldDto> taskHelloWorldDto = _repository.HelloWorld();
            taskHelloWorldDto.Wait();
            HelloWorldDto helloWorldDto = taskHelloWorldDto.Result;
            HelloWorld helloWorld = new HelloWorld
            {
                httpResponseMessage = helloWorldDto.httpResponseMessage
            };
            return helloWorld;
        }

        public void SubmitAnswers(IEnumerable<AnswerModel> answers)
        {
            List<AnswerDto> answerDtos = new List<AnswerDto>();

            foreach (var answer in answers)
            {
                AnswerDto answerDto = new AnswerDto
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
        public IEnumerable<SurveyDto> GetSurveys()
        {
            Task<string> surveysString = _repository.GetSurveys();
            List<SurveyDto> surveyDtos = new List<SurveyDto>();
            surveysString.Wait();
            string surveysJson = surveysString.Result;
            JObject obj = JObject.Parse(surveysJson);
            var surveys = obj["surveys"];
            foreach (var survey in surveys)
            {
                var QuestionsArray = survey["questions"].Value<JArray>();

                SurveyDto surveyDto = new SurveyDto
                {
                    Survey_ID = (int)survey["id"],
                    Description = (string)survey["name"],
                    Name = (string)survey["description"],
                    Questions = QuestionsArray.ToObject<List<QuestionDto>>()
                };
                surveyDtos.Add(surveyDto);
            };
            return surveyDtos;
        }

    }
}
