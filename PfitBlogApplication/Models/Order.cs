using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PfitBlogApplication.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public int CountPlaces { get; set; }
        public string Start { get; set; }
        public string End { get; set; }
        public string TimeStart { get; set; }
        public string Phone { get; set; }
    }
}