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
		[JsonProperty("descGood")]
		public string? Good_Answer { get; set; }
		[JsonProperty("descAvg")]
		public string? Avg_Answer { get; set; }
		[JsonProperty("descBad")]
		public string? Bad_Answer { get; set; }

	}
}
