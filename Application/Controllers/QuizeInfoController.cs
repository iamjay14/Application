using Application.Areas.Admin.Models;
using Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Application.Controllers
{
    public class QuizeInfoController : Controller
    {
        // GET: Quize
        public ActionResult Index()
        {
            return View();
        }

        [CookieAuthorize(Roles = "User")]
        public ActionResult GetQuize(int id)
        {
            return View(QuestionDao.GetsQuize(id));
        }

        public ActionResult Test()
        {
            return View();
        }
    }
}