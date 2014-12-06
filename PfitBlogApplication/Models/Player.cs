﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PfitBlogApplication.Models
{
    public class Player
    {
        public int PlayerId { get; set; }
        public string Name { get; set; }

        public int TeamId { get; set; }
        public virtual Team Team { get; set; }
    }
}