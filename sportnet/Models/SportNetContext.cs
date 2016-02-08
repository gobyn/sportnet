using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace sportnet.Models
{
    public class SportNetContext : ApplicationDbContext
    {
        public DbSet<Team> Teams { get; set; }
    }
}