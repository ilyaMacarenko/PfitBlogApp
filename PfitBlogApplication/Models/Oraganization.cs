using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PfitBlogApplication.Models
{
    public class Org
    {
        [Key]
        [Required]
        public int OrgId { get; set; }
        [Required]
        public string Name { get; set; }
        public int CountCar { get; set; }
        public int CountPeople { get; set; }
        public string PhoneMTC { get; set; }
        public string PhoneVelcom { get; set; }
    }
}