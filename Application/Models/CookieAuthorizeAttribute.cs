using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Application.Models
{
    public class CookieAuthorizeAttribute:AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            string[] array = Roles.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            return array.Contains(CookieWrapper.Role);
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            HttpContext.Current.Response.Redirect("~/Home/Login");
        }
    }
}