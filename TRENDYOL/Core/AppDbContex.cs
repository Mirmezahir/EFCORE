using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TRENDYOL.Models;

namespace TRENDYOL.Core
{
    public class AppDbContex:DbContext
    {

        public DbSet<Baskets> Baskets { get; set; }
         public DbSet<Products> Products { get; set; }
       public DbSet<Users> Users { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS; Database=TRENDYOL; Integrated Security=True; Trusted_Connection=True;TrustServerCertificate=true ;");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
