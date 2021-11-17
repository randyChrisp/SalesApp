using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesApp.Models
{
    public class SalesAppContext : DbContext
    {
        public SalesAppContext (DbContextOptions<SalesAppContext> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Sales> SalesDb { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    EmployeeId = 1,
                    FirstName = "Katie",
                    LastName = "Travis",
                    DOB = new DateTime(1979, 12, 4),
                    HireDate = new DateTime(1995, 1, 1),
                    ManagerId = 0
                }
                );

            modelBuilder.Entity<Sales>().HasData(
                new Sales
                {
                    SalesId = 1,
                    Quarter = 1,
                    Year = 2020,
                    Amount = 375987,
                    EmployeeId = 1
                },

                new Sales
                {
                    SalesId = 2,
                    Quarter = 2,
                    Year = 2020,
                    Amount = 420357,
                    EmployeeId = 1
                },

                new Sales
                {
                    SalesId = 3,
                    Quarter = 3,
                    Year = 2020,
                    Amount = 741258,
                    EmployeeId = 1
                },

                new Sales
                {
                    SalesId = 4,
                    Quarter = 4,
                    Year = 2020,
                    Amount = 529183,
                    EmployeeId = 1
                }
                ); ;
        }
    }
}
