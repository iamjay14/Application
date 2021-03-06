﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Application.Areas.Admin.Models
{
    public class NewsViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        [AllowHtml]
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }

        public string[] TagName { get; set; }
    }
}