using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace OnlinePlanner.Models
{
    public class OnlinePlannerContext : DbContext
    {
        public OnlinePlannerContext (DbContextOptions<OnlinePlannerContext> options)
            : base(options)
        {
        }

        public DbSet<OnlinePlanner.Models.Tasks> Tasks { get; set; }
    }
}
