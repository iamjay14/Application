using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Application.Areas.Admin.Models
{
    public class JobViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        [AllowHtml]
        public string Description { get; set; }
        public int TagId { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime ApplyStartDate { get; set; }
        public DateTime ApplyEndDate { get; set; }
        public decimal Fees { get; set; }
        public DateTime ExamDate { get; set; }
    }
}