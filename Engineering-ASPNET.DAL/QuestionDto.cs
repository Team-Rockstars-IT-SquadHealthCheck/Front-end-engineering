using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engineering_ASPNET.DAL
{
    public class QuestionDto
    {
        public int Question_ID { get; set; }
        public int Survey_ID { get; set; } 
        public string? Description { get; set;}
        public string? Title { get; set;}
    }
}
