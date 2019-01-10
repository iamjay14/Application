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
            var attempt = QuizeResultDao.GetsByUser(id, CookieWrapper.UserId);
            ViewBag.one = attempt.Any(x => x.Attempt == 1) ? attempt.FirstOrDefault(x => x.Attempt == 1).Result.ToString():"-";
            ViewBag.two = attempt.Any(x => x.Attempt == 2) ? attempt.FirstOrDefault(x => x.Attempt == 2).Result.ToString() : "-";
            ViewBag.three = attempt.Any(x => x.Attempt == 3) ? attempt.FirstOrDefault(x => x.Attempt == 3).Result.ToString() : "-";
            ViewBag.flag = attempt.Any(x => x.Attempt == 3) ? false : true;
            return View(QuestionDao.GetsQuize(id));
        }

        public ActionResult Test()
        {
            return View();
        }
    }
}