using KapoTechProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KapoTechProject.Areas.Admin.Controllers
{
    public class InfosController : Controller
    {
        private KapoTechContext _context = new KapoTechContext();

        // GET: Admin/Info
        public ActionResult Index()
        {
            return View();
        } 
        
        public ActionResult InfoList()
        {
            var result = _context.Infos.ToList();
            return View(result);
        }
        [HttpGet]
        public ActionResult InfoAdd()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult InfoAdd(Info info)
        {
            if(ModelState.IsValid) 
            {
                _context.Infos.Add(info);
                _context.SaveChanges();
                return RedirectToAction("InfoList");
            }
            return View();
        }

        public ActionResult InfoDeleted(int id)
        {
            if (id != null)
            {
                Info info = _context.Infos.Find(id);
                _context.Infos.Remove(info);
                _context.SaveChanges();
                return RedirectToAction("InfoList");
            }
            return View();
        }


        [HttpGet]
        public ActionResult InfoUpdated(int id)
        {
            var result = _context.Infos.FirstOrDefault(x=> x.InfoID ==  id);
            Info info = new Info
            {
                InfoID= id,
                InfoName = result.InfoName,
                Status= result.Status,
                InfoSkill = result.InfoSkill
            };
            return View(result);
        }

        [HttpPost]
        public ActionResult InfoUpdated(Info info)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(info).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("InfoList");
            }
            return View();
        }

    }
}