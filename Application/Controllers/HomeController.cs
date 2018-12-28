using Application.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Application.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ViewAllJobs()
        {
            return View(JobDao.Gets());
        }

        [HttpGet]
        public ActionResult NewsDetail(int id)
        {
            return View(NewsDao.Get(id));
        }
    }
}