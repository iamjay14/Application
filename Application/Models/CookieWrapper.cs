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
                if (HttpContext.Current.Request.Cookies["UserId"] != null)
                {
                    return Convert.ToInt32(HttpContext.Current.Request.Cookies["UserId"].Value);
                }
                else
                {
                    return 0;
                }
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
                if (HttpContext.Current.Request.Cookies["Name"]!= null)
                {
                    return HttpContext.Current.Request.Cookies["Name"].Value;
                }
                else
                {
                    return "";
                }
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
                if (HttpContext.Current.Request.Cookies["Role"] != null)
                {
                    return HttpContext.Current.Request.Cookies["Role"].Value;
                }
                else
                {
                    return "";
                }
            }
        }

        public static void CreateCookie(string key,string value)
        {
            HttpCookie cookies = new HttpCookie(key);
            cookies.Value = value;
            cookies.Expires = DateTime.Now.AddDays(15);
            HttpContext.Current.Response.SetCookie(cookies);
            HttpContext.Current.Response.Cookies.Add(cookies);
        }
    }
}