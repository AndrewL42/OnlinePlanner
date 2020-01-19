using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace OnlinePlanner.Models
{
    public static class Tasks_SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new OnlinePlannerContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<OnlinePlannerContext>>()))
            {
                // Look for any Tasks.
                if (context.Tasks.Any())
                {
                    return;   // DB has been seeded
                }

                context.Tasks.AddRange(
                    new Tasks
                    {
                        Class_Name = "N/A",
                        DueDate = DateTime.Parse("1/1/2000"),
                        Task_Name = "N/A",
                    }
                );
                context.SaveChanges();
            }
        }
    }
}