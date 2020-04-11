using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnlinePlanner.Models;

namespace OnlinePlanner.Models
{
    public class OnlinePlannerContext : DbContext
    {
        public OnlinePlannerContext (DbContextOptions<OnlinePlannerContext> options)
            : base(options)
        {
        }

        public DbSet<Tasks> Tasks { get; set; }

        public DbSet<Classes> Classes { get; set; }

        public DbSet<SignIn> SignIn { get; set; }

        public DbSet<Notes> Notes { get; set; }
    }
}
