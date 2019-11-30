using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace israAppExam.Models
{
    public class GitHubRipo
    {
        public List<GItHubList> gItHubList { get; set; }
        public GitHubRipo()
        {
            gItHubList = new List<GItHubList>();
        }
    }
}