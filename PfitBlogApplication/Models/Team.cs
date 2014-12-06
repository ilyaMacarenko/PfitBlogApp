using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PfitBlogApplication.Models
{
    public class Team
    {
        public int TeamId { get; set; }
        public string Name { get; set; }

        public ICollection<Player> Players { get; set; }
    }
}