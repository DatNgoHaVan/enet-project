using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace enson_be.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<DatabaseContext>();
            context.Database.EnsureCreated();
            if (!context.Roles.Any())
            {
                context.Roles.Add(new Role() { Type = "Admin" });
                context.Roles.Add(new Role() { Type = "User" });
                context.SaveChanges();
            }
        }
    }
}
