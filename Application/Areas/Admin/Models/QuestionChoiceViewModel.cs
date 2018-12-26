using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Application.Areas.Admin.Models
{
    public class QuestionChoiceViewModel
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public string Choice { get; set; }
        public byte IsRight { get; set; }
    }
}