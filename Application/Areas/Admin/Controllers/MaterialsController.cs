using Application.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Application.Areas.Admin.Controllers
{
    [MyAuthorize(Roles ="Admin")]
    public class MaterialsController : Controller
    {
        // GET: Admin/Materials
        public ActionResult Index()
        {
            return View(MaterialsDao.Gets());
        }

        [HttpPost]
        public ActionResult Create(MaterialsViewModel model)
        {
            if (MaterialsDao.Add(model))
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}