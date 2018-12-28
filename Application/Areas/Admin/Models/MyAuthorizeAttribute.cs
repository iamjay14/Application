using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Application.Areas.Admin.Models
{
    public class MyAuthorizeAttribute:System.Web.Mvc.AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            string[] array = Roles.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            return array.Contains(SessionWrapper.Role);
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            HttpContext.Current.Response.Redirect("~/Home/Login");
        }
    }
}