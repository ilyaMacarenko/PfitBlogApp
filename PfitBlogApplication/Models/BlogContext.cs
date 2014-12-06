using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PfitBlogApplication.Models
{
    public class BlogContext : DbContext
    {
        public DbSet<LoginModel> loginSet { get; set; }
        public DbSet<AdvertisementModel> adSet { get; set; }
        public DbSet<PostModel> postSet { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Team> Teams { get; set; }

        public DbSet<Org> OrgSet { get; set; }
        public DbSet<Time> TimeSet { get; set; }
        public DbSet<User> UserSet { get; set; }
        public DbSet<Way> WaySet { get; set; }
        public DbSet<Order> OrderSet { get; set; }
    }
}