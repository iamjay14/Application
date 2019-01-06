using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Application.Models
{
    public class QuizeResultViewModel
    {
        public int Id { get; set; }
        public int QuizeTypeId { get; set; }
        public int UserId { get; set; }
        public int Attempt { get; set; }
        public decimal Result { get; set; }
    }
}