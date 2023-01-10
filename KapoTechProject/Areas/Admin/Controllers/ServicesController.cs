using KapoTechProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KapoTechProject.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]

    public class ServicesController : Controller
    {
        // GET: Admin/Services
        private KapoTechContext _context = new KapoTechContext();

        // GET: Admin/Projects
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ServicesList()
        {
            var result = _context.Services.ToList();
            return View(result);
        }
        [HttpGet]
        public ActionResult ServicesAdd()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ServicesAdd(Service service)
        {
            if (ModelState.IsValid)
            {
                _context.Services.Add(service);
                _context.SaveChanges();
                return RedirectToAction("ServicesList");
            }
            return View();
        }

        public ActionResult ServicesDeleted(int id)
        {
            if (id != null)
            {
                Service service = _context.Services.Find(id);
                _context.Services.Remove(service);
                _context.SaveChanges();
                return RedirectToAction("ServicesList");
            }
            return View();
        }


        [HttpGet]
        public ActionResult ServicesUpdated(int id)
        {
            var result = _context.Services.FirstOrDefault(x => x.ServiceID == id);
            Service service = new Service
            {
                ServiceID = id,
                ServiceName = result.ServiceName,
                Status = result.Status,
                ImageUrl = result.ImageUrl
            };
            return View(result);
        }

        [HttpPost]
        public ActionResult ServicesUpdated(Service service)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(service).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("ServicesList");
            }
            return View();
        }
    }
}