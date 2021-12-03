using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesApp.Models
{
    public class UnitOfWork : IUnitOfWork
    {
        private SalesAppContext context { get; set; }
        public UnitOfWork(SalesAppContext ctx) => this.context = ctx;

        private Repository<Employee> employees;
        public Repository<Employee> Employees
        {
            get
            {
                if(this.employees == null)
                {
                    this.employees = new Repository<Employee>(this.context);
                }

                return employees;
            }
        }

        private Repository<Sales> sales;
        public Repository<Sales> Sales
        {
            get
            {
                if (this.sales == null)
                {
                    this.sales = new Repository<Sales>(this.context);
                }

                return sales;
            }
        }

        public void Save() => context.SaveChanges();
    }
}
