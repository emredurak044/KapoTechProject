using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KapoTechProject.Models
{
    public class Team
    {
        public int TeamID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string GithubURL { get; set; }
        public string LinkedinURL { get; set; }
        public bool Status { get; set; }
    }
}