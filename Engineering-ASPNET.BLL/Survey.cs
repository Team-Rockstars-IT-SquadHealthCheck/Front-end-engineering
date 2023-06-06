using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engineering_ASPNET.DAL
{
    public class Survey
    {
        [JsonProperty("Id")]
        public int Survey_ID { get; set; }
        [JsonProperty("Name")]
        public string? Name { get; set; }
        [JsonProperty("Description")]
        public string? Description { get; set; }
        [JsonProperty("Questions")]
        public List<Question> Questions { get; set; }
    }
}
