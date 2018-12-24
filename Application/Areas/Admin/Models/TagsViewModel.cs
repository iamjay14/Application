using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Application.Areas.Admin.Models
{
    public class TagsViewModel
    {
        public int Id { get; set; }
        public int TypeId { get; set; }
        public string Type { get; set; }
        public int TagId { get; set; }
    }
}