using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class RentCarDBContext:DbContext
    {
     protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=RentCarDB;Trusted_Connection=true");


        }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Rentals> Rentals { get; set; }

        public DbSet<CarImages> CarImages { get; set; }

        public DbSet<OperationClaims> OperationClaims { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<UserOperationClaims> UserOperationClaims { get; set; }


    }
}
