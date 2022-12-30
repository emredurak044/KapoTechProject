using KapoTechProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KapoTechProject.Controllers
{
    public class ProjectController : Controller
    {
        // GET: Project
        private readonly KapoTechContext _context = new KapoTechContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ProjectList()
        {
            try
            {
                var result = _context.Projects.ToList().Take(3).ToList();
                return PartialView(result);
            }
            catch
            {

                return PartialView();
            }

        }
    }
}