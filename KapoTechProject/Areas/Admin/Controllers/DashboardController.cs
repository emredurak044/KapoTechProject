using KapoTechProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;

namespace KapoTechProject.Areas.Admin.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Admin/Dashboard
        private KapoTechContext _context = new KapoTechContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult WeatherPartial()
        {
            string apikey = "279ab030962429cbb21b0eaf212de199";
            string city = "Malatya";
            string Countries = "Turkey";
            string apiurl = "https://api.openweathermap.org/data/2.5/weather?q=" + city + "&mode=xml&units=metric&appid=" + apikey;
            XDocument document = XDocument.Load(apiurl);
            ViewBag.Degree = document.Descendants("temperature").ElementAt(0).Attribute("value").Value;
            ViewBag.City = city;
            ViewBag.Countries = Countries;
            return PartialView();
        }

        public ActionResult ServiceCounterPartial() 
        {
            var serviceCount = _context.Services.Count();
            ViewBag.ServiceCount = serviceCount;    
            return PartialView();
        }
        
        public ActionResult TeamCounterPartial() 
        {
            var teamCount = _context.Teams.Count();
            ViewBag.TeamCount = teamCount;
            return PartialView();
        }
        
        public ActionResult ProjectCounterPartial() 
        {
            var projectCount = _context.Projects.Count();
            ViewBag.ProjectCount = projectCount;
            return PartialView();
        } 
        
        public ActionResult ProjectListPartial() 
        {
            var projectList = _context.Projects.ToList();
            return PartialView(projectList);
        } 
        
        public ActionResult TeamsListPartial() 
        {
            var teamList = _context.Teams.ToList();
            return PartialView(teamList);
        }
    }
}