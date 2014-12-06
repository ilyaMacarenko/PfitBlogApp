using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PfitBlogApplication.Models
{
    public class Way
    {
        [Key]
        [Required]
        public int WayId { get; set; }
        [Required]
        public string StartWay { get; set; }
        [Required]
        public string IntervalStation { get; set; }
        [Required]
        public string EndWay { get; set; }
        [Required]
        public int Destination { get; set; }
        [Required]
        public int Cost { get; set; }
    }
}