using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MultiplexCoreFive.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultiplexCoreFive.Data
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MultiplexDbContext(serviceProvider.GetRequiredService<DbContextOptions<MultiplexDbContext>>()))
            {
                //Look for Country
                if (context.Country.Any()) { return; }

                List<Country> countries = new List<Country>()
                {
                    new Country(){ Name = "Bangladesh", ShortName = "BD"},
                    new Country(){ Name = "India", ShortName = "IND"},
                    new Country(){ Name = "Canada", ShortName = "CAN"}
                };

                context.Country.AddRange(countries);
                context.SaveChanges();
            }
        }
    }
}
