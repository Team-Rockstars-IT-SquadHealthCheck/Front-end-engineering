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
            var stringContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync("https://localhost:32770/Answer", stringContent);

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Data sent successfully.");
            }
            else
            {
                Console.WriteLine($"Failed to send data. Status code: {response.StatusCode}");
            }
        }

        public async Task<string> GetSurveys()
        {
            HttpClient httpClient = new();
            string surveys = await httpClient.GetStringAsync("http://138.201.52.251:8081/surveys");
            return surveys;
        }

        public async Task<string> GetSurveyBy(string id)
        {
            HttpClient httpClient = new();
            string survey = await httpClient.GetStringAsync($"https://localhost:32770/survey/{id}");
            return survey;
        }

        public async Task<string> ValidateID(string id)
        {
            HttpClient httpClient = new();
              string user_ID = await httpClient.GetStringAsync($"https://localhost:32770/Validate/{id}");
            return user_ID;
        }

        public async void PostStatus(string id)
        {
            HttpClient httpClient = new();

            string response = await httpClient.GetStringAsync($"https://localhost:32770/StatusFilled/{id}");

        }

        public async Task<string> GetAnswersBy(string id)
        {
            HttpClient httpClient = new();
            string surveys = await httpClient.GetStringAsync($"https://localhost:32770/Answer/{id}");
            return surveys;
        }
    }
}