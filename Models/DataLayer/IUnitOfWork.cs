using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesApp.Models
{
    public interface IUnitOfWork
    {
        Repository<Employee> Employees { get; }
        Repository<Sales> Sales { get; }

        void Save();
    }
}
