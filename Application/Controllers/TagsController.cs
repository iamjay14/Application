using Application.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Application.Controllers
{
    public class TagsController : Controller
    {
        // GET: Tags
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetsDetail(int id,string name)
        {
            ViewBag.tag = name;
            return View(TagsDao.GetsByTag(id));
        }
    }
}