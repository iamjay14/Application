using Application.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Application.Areas.Admin.Controllers
{
    [MyAuthorize(Roles = "Admin")]
    public class DashboardController : Controller
    {

        // GET: Admin/Dashboard
        public ActionResult Index()
        {
            return View();
        }

        
    }
}