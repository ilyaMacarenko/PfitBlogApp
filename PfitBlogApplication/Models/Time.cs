using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PfitBlogApplication.Models
{
    public class Time
    {
        [Key]
        [Required]
        public int TimeId { get; set; }
        public string TimeStart { get; set; }
        public string Day { get; set; }
        public string Direction { get; set; }
        public int OrgId { get; set; }

    }
}