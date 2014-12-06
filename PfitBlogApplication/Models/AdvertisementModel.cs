using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PfitBlogApplication.Models
{
    public class AdvertisementModel
    {
        [Key]
        public int AdId { get; set; }
        public string StoreName { get; set; }
        public string ObjectType { get; set; }
        public int Sale { get; set; }
    }
}