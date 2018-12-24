using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Application.Areas.Admin.Models
{
    public class TagViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreateDate { get; set; }
        public int CreateBy { get; set; }
    }
}