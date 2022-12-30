using KapoTechProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KapoTechProject.Controllers
{
    public class InfoController : Controller
    {
        // GET: Info
        private readonly KapoTechContext _context = new KapoTechContext();

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult InfoList()
        {
            var result = _context.Infos.ToList();
            return PartialView(result);
        }
    }
}