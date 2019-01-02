using Application.Areas.Admin.Models;
using Application.Models;
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

        [HttpPost]
        public ActionResult Signup(UserInfoViewModel model)
        {
            if (UserInfoDao.Add(model))
            {
                if (model.Role == "Admin")
                {
                    SessionWrapper.UserId = model.Id;
                    SessionWrapper.Name = model.FirstName + " " + model.LastName;
                    SessionWrapper.Role = model.Role;
                    return RedirectToAction("Index", "Dashboard", new { area = "Admin" });
                }
                else if (model.Role == "User")
                {
                    CookieWrapper.UserId = model.Id;
                    CookieWrapper.Name = model.FirstName + " " + model.LastName;
                    CookieWrapper.Role = model.Role;
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Login");
        }

        [HttpPost]
        public ActionResult Login(string email,string password)
        {
            var obj = UserInfoDao.IsLogin(email, password);
            if (obj != null)
            {
                if (obj.Role == "Admin")
                {
                    SessionWrapper.UserId = obj.Id;
                    SessionWrapper.Name = obj.FirstName + " " + obj.LastName;
                    SessionWrapper.Role = obj.Role;
                    return RedirectToAction("Index", "Dashboard", new { area = "Admin" });
                }
                else if (obj.Role == "User")
                {
                    CookieWrapper.UserId = obj.Id;
                    CookieWrapper.Name = obj.FirstName + " " + obj.LastName;
                    CookieWrapper.Role = obj.Role;
                    return RedirectToAction("Index");
                }
            }
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

        [HttpPost]
        public ActionResult CheckQuestion(int[] ids,int qId)
        {
            var list = QuestionDao.GetsQuizeChoiceData(qId);
            int count = 0;
            for(int i = 0; i < ids.Length; i++)
            {
                byte obj = list.FirstOrDefault(x => x.Id == ids[i]).IsRight;
                if (obj==1)
                {
                    count++;
                }
            }
            return Json(new { re=count,typeId=qId,data=list });
        }
    }
}