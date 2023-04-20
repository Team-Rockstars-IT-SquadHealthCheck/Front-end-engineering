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
        [JsonProperty("id")]
        public int Survey_ID { get; set; }
        [JsonProperty("name")]
        public string? Name { get; set; }
        [JsonProperty("description")]
        public string? Description { get; set; }
        [JsonProperty("questions")]
        public List<Question> Questions { get; set; }
    }
}
