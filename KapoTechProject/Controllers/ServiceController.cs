using KapoTechProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KapoTechProject.Controllers
{
    public class ServiceController : Controller
    {
        // GET: Service
        private readonly KapoTechContext _kapoTechContext = new KapoTechContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ServiceList()
        {
            try
            {
                var result = _kapoTechContext.Services.ToList();
                return PartialView(result);
            }
            catch
            {

                return PartialView();

            }
        }
    }
}