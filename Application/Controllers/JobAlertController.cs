using Application.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Application.Controllers
{
    public class JobAlertController : Controller
    {
        // GET: JobAlert
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult JobDetail(int id)
        {
            return View(JobDao.Get(id));
        }
    }
}