using Application.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Application.Areas.Admin.Controllers
{
    [MyAuthorize(Roles ="Admin")]
    public class SyllabusController : Controller
    {
        // GET: Admin/Syllabus
        public ActionResult Index()
        {
            return View(SyllabusDao.Gets());
        }

        [HttpPost]
        public ActionResult Create(SyllabusViewModel model)
        {
            if (SyllabusDao.Add(model))
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}