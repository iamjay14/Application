using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Application.Areas.Admin.Models
{
    public class QuestionViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public byte IsActive { get; set; }
        public int QuizeTypeId { get; set; }

        public int QuizeTypeName { get; set; }

        public List<QuestionChoiceViewModel> Choices { get; set; }
        

        public QuestionViewModel()
        {
            Choices = new List<QuestionChoiceViewModel>();
        }
    }
}