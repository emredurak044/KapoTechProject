using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KapoTechProject.Models
{
    public class Service
    {
        public int ServiceID { get; set; }
        public string ServiceName { get; set; }
        public string ImageUrl { get; set; }
        public bool Status { get; set; }
    }
}