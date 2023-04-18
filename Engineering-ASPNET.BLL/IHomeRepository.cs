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
        void ValidateID(Link link);
    }
}
