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

    public class ProjectsController : Controller
    {
        private KapoTechContext _context = new KapoTechContext();

        // GET: Admin/Projects
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ProjectsList()
        {
            var result = _context.Projects.ToList();
            return View(result);
        }
        [HttpGet]
        public ActionResult ProjectsAdd()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ProjectsAdd(Project project)
        {
            if (ModelState.IsValid)
            {
                _context.Projects.Add(project);
                _context.SaveChanges();
                return RedirectToAction("ProjectsList");
            }
            return View();
        }

        public ActionResult ProjectsDeleted(int id)
        {
            if (id != null)
            {
                Project project = _context.Projects.Find(id);
                _context.Projects.Remove(project);
                _context.SaveChanges();
                return RedirectToAction("ProjectsList");
            }
            return View();
        }


        [HttpGet]
        public ActionResult ProjectsUpdated(int id)
        {
            var result = _context.Projects.FirstOrDefault(x => x.ProjectID == id);
            Project project = new Project
            {
                ProjectID = id,
                ProjectName = result.ProjectName,
                Status = result.Status,
                ProjectImage = result.ProjectImage,
                ProjectURL = result.ProjectURL
            };
            return View(result);
        }

        [HttpPost]
        public ActionResult ProjectsUpdated(Project project)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(project).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("ProjectsList");
            }
            return View();
        }
    }
}