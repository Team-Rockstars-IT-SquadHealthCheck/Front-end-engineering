using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engineering_ASPNET.DAL
{
    public class Question
    {
        [JsonProperty("id")]
        public int Question_ID { get; set; }
        [JsonProperty("surveyId")]
        public int Survey_ID { get; set; }
        [JsonProperty("description")]
        public string? Description { get; set;}
        [JsonProperty("title")]
        public string? Title { get; set;}
    }
}
