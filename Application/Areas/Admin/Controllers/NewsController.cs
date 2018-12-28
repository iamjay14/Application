using Application.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Application.Areas.Admin.Controllers
{
    [MyAuthorize(Roles = "Admin")]
    public class NewsController : Controller
    {
        // GET: Admin/News
        public ActionResult Index()
        {
            return View(NewsDao.Gets());
        }

        
        [HttpPost]
        public ActionResult Create(NewsViewModel model)
        {
            if (NewsDao.Add(model))
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}