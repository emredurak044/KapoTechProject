using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KapoTechProject.Models
{
    public class Project
    {
        public int ProjectID { get; set; }
        public string ProjectName { get; set; }
        public string ProjectImage { get; set; }
        public string ProjectURL { get; set; }
        public bool Status { get; set; }
    }
}