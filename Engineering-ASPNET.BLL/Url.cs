using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engineering_ASPNET.BLL
{
    public class Url
    {
        public int Id { get; set; }
        public string? url { get; set; }
        public int userid { get; set; }
        public int status { get; set; }
    }
}
