using Engineering_ASPNET.DAL;
using System.Net.Http;

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
    }
}