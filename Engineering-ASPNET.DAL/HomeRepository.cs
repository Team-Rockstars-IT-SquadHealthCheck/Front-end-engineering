using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Engineering_ASPNET.DAL
{
    public class HomeRepository
    {
        public async Task<HelloWorldDto> HelloWorld()
        {
            HttpClient httpClient = new();
            HelloWorldDto helloWorldDto = new HelloWorldDto();
            helloWorldDto.httpResponseMessage = await httpClient.GetStringAsync("https://localhost:32770/HelloWorld");
            return helloWorldDto;
        }

        public async void SubmitAnswers(IEnumerable<AnswerDto> answers)
        {
            HttpClient httpClient = new();
            string json = JsonConvert.SerializeObject(answers);
            var stringContent = new StringContent(json);

            await httpClient.PostAsync("http://40.113.119.8:80/Answer", stringContent);
        }

        public async Task<string> GetSurveys()
        {
            HttpClient httpClient = new();
            string surveys = await httpClient.GetStringAsync("http://40.113.119.8:80/surveys");
            return surveys;
        }
    }
}