using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Application.Models
{
    public class CookieWrapper
    {
        public static int UserId
        {
            set
            {
                CreateCookie("UserId", value.ToString());
            }
            get
            {
                return int.Parse(HttpContext.Current.Request.Cookies["User"].Values["UserId"]);
            }
        }

        public static string Name
        {
            set
            {
                CreateCookie("Name", value.ToString());
            }
            get
            {
                return HttpContext.Current.Request.Cookies["User"].Values["Name"];
            }
        }

        public static string Role
        {
            set
            {
                CreateCookie("Role", value.ToString());
            }
            get
            {
                return HttpContext.Current.Request.Cookies["User"].Values["Role"];
            }
        }

        public static void CreateCookie(string name,string value)
        {
            HttpCookie cookies = new HttpCookie("User");
            cookies[name] = value;
            cookies.Expires = DateTime.Now.AddDays(15);
            HttpContext.Current.Response.SetCookie(cookies);
            HttpContext.Current.Response.Cookies.Add(cookies);
        }
    }
}