using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace israAppExam.Models
{
    public class GItHubList
    {
        public string id { get; set; }
        public string name { get; set; }
        public string url { get; set; }
        public string login { get; set; }
        public string description { get; set; }
        public string watchers { get; set; }
        public string language { get; set; }
    }
}