﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Application.Controllers
{
    public class QuizeController : Controller
    {
        // GET: Quize
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetQuize()
        {
            return View();
        }

        public ActionResult Test()
        {
            return View();
        }
    }
}