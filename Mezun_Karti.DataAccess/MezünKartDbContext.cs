using Mezun_Karti.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mezun_Karti.DataAccess
{
   public class MezünKartDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=.; Database=MezünKartDb;uid=emresen;pwd=1234");
            // optionsBuilder.UseSqlServer("server=EMRE;Database=HotelDb;integrated security=true");
        }

        public DbSet<person> persons { get; set; }

        public DbSet<user> users { get; set; }

    }
}
