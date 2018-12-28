using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Application.Areas.Admin.Models
{
    public class SessionWrapper
    {
        public static int UserId
        {
            get
            {
                if (HttpContext.Current.Session["UserId"] != null)
                    return int.Parse(HttpContext.Current.Session["UserId"].ToString());
                return 0;
            }
            set
            {
                HttpContext.Current.Session["UserId"] = value;
            }
        }

        public static string Name
        {
            get
            {
                if (HttpContext.Current.Session["Name"] != null)
                    return HttpContext.Current.Session["Name"].ToString();
                return "";
            }
            set
            {
                HttpContext.Current.Session["Name"] = value;
            }
        }

        public static string Role
        {
            get
            {
                if (HttpContext.Current.Session["Role"] != null)
                    return HttpContext.Current.Session["Role"].ToString();
                return "";
            }
            set
            {
                HttpContext.Current.Session["Role"] = value;
            }
        }

        public static bool IsLogged
        {
            get
            {
                return SessionWrapper.UserId != 0;
            }
        }

        public static void Authorize(string role)
        {
            if (!SessionWrapper.Role.Equals(role))
            {
                HttpContext.Current.Response.Redirect("~/Home/Login");
            }
        }

        public static void Logout()
        {
            HttpContext.Current.Session.Abandon();
            HttpContext.Current.Response.Redirect("~/Home/Login");
        }
    }
}