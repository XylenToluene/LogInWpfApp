using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp3.DB
{
    public class MyContext : DbContext
    {
        private string cs = "Server=localhost;Database=TetsDbApp1;Trusted_Connection=True;";

        public DbSet<User> Users { get; set; }

        public DbSet<Status> Statuses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(cs);
        }

    }
}
