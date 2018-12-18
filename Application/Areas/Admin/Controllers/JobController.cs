﻿using Application.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Application.Areas.Admin.Controllers
{
    public class JobController : Controller
    {
        // GET: Admin/Job
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(JobViewModel model)
        {
            if (JobDao.Add(model))
            {
                return View();
            }
            return View();
        }

    }
}