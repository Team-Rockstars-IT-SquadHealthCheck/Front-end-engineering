using Engineering_ASPNET.BLL;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Engineering_ASPNET.DAL
{
    public class HomeRepository : IHomeRepository
    {
        public async Task<HelloWorld> HelloWorld()
        {
            HttpClient httpClient = new();
            HelloWorld helloWorldDto = new HelloWorld();
            helloWorldDto.httpResponseMessage = await httpClient.GetStringAsync("https://localhost:32770/HelloWorld");
            return helloWorldDto;
        }

        public async void SubmitAnswers(IEnumerable<AnswerModel> answers)
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