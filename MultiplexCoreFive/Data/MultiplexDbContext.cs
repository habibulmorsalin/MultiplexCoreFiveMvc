using Microsoft.EntityFrameworkCore;
using MultiplexCoreFive.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultiplexCoreFive.Data
{
    public class MultiplexDbContext : DbContext
    {
        public MultiplexDbContext(DbContextOptions<MultiplexDbContext> options) :base(options)
        {

        }

        public DbSet<Country> Country { get; set; }
    }
}
