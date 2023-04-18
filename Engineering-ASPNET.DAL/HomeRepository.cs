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
            helloWorldDto.httpResponseMessage = await httpClient.GetStringAsync("http://138.201.52.251:8081/HelloWorld ");
            return helloWorldDto;
        }

        public async void SubmitAnswers(IEnumerable<AnswerModel> answers)
        {
            HttpClient httpClient = new();
            string json = JsonConvert.SerializeObject(answers);
            var stringContent = new StringContent(json);

            await httpClient.PostAsync("http://138.201.52.251:8081/Answer", stringContent);
        }

        public async Task<string> GetSurveys()
        {
            HttpClient httpClient = new();
            string surveys = await httpClient.GetStringAsync("http://138.201.52.251:8081/surveys");
            return surveys;
        }

        public async Task<string> ValidateID(string id)
        {
            HttpClient httpClient = new();
            string json = JsonConvert.SerializeObject(id);
            var stringContent = new StringContent(json);

            string user_ID = await httpClient.GetStringAsync("http://138.201.52.251:8081/Validate/{id}");
            return user_ID;
        }
    }
}