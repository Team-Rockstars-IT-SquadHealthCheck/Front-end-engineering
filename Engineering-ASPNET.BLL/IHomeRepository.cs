using Engineering_ASPNET.DAL;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engineering_ASPNET.BLL
{
    public interface IHomeRepository
    {
        Task<HelloWorld> HelloWorld();
        void SubmitAnswers(IEnumerable<AnswerModel> answers);
        Task<string> GetSurveys();
        Task<string> ValidateID(string id);
        Task<string> GetAnswersBy(string id);
        void PostStatus(string id);
        Task<string> GetSurveyBy(string id);
    }
}
