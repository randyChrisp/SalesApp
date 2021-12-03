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
                },

                new Employee
                {
                    EmployeeId = 2,
                    FirstName = "Stan",
                    LastName = "Smith",
                    DOB = new DateTime(1982, 4, 10),
                    HireDate = new DateTime(1996, 6, 19),
                    ManagerId = 1
                },

                new Employee
                {
                    EmployeeId = 3,
                    FirstName = "Sue",
                    LastName = "Chen",
                    DOB = new DateTime(2000, 9, 4),
                    HireDate = new DateTime(1999, 1, 1),
                    ManagerId = 2
                }
                );

            modelBuilder.Entity<Sales>().HasData(
                new Sales
                {
                    SalesId = 1,
                    Quarter = 1,
                    Year = 2020,
                    Amount = 375987,
                    EmployeeId = 2
                },

                new Sales
                {
                    SalesId = 2,
                    Quarter = 2,
                    Year = 2020,
                    Amount = 420357,
                    EmployeeId = 2
                },

                new Sales
                {
                    SalesId = 3,
                    Quarter = 3,
                    Year = 2020,
                    Amount = 741258,
                    EmployeeId = 3
                },

                new Sales
                {
                    SalesId = 4,
                    Quarter = 4,
                    Year = 2020,
                    Amount = 529183,
                    EmployeeId = 3
                }
                ); ;
        }
    }
}
