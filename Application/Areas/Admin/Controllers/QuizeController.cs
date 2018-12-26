using Application.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Application.Areas.Admin.Controllers
{
    public class QuizeController : Controller
    {
        // GET: Admin/Quize
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateCategory(QuizeCategoryViewModel model)
        {
            if (QuizeCategoryDao.Add(model))
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult CreateType(QuizeTypeViewModel model)
        {
            if (QuizeTypeDao.Add(model))
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult CreateQuestion(QuestionViewModel model,string Choice1,string Choice2,string Choice3,string Choice4,int IsRight)
        {
            if (QuestionDao.Add(model,Choice1,Choice2,Choice3,Choice4,IsRight))
            {
                return Json("Success");
            }
            return Json("Failed");
        }

    }
}