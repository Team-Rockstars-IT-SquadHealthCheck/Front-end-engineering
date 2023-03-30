using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engineering_ASPNET.BLL
{
    public class AnswerModel
    {
        public int QuestionId { get; set; }
        public int UserId { get; set; }
        public int Answer { get; set; }
        public string Comment { get; set; } = "";
    }

}
