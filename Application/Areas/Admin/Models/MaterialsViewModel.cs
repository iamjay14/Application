using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Application.Areas.Admin.Models
{
    public class MaterialsViewModel
    {
        public int Id { get; set; }
        public int ExamId { get; set; }
        public string Title { get; set; }
        public string Link { get; set; }
        public DateTime CreateDate { get; set; }
        public int CreateBy { get; set; }

        public string[] Name { get; set; }
    }
}