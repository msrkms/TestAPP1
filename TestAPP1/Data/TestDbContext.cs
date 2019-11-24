using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestAPP1.Models;

namespace TestAPP1.Data
{
    public class TestDbContext:DbContext
    {
        public TestDbContext(DbContextOptions<TestDbContext> options)
            : base(options)
        {
        }

       public DbSet<Doctor> Doctors { get; set; }

       public DbSet<Bmi> bmis { get; set; }
    }
}
