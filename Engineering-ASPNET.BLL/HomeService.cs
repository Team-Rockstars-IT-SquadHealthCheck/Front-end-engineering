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
    }
}