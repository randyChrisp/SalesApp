using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesApp.Models
{
    public static class Validate
    {
        public static string ValidateEmployee(Repository<Employee> data, Employee employee)
        {
            var options = new QueryOptions<Employee>
            {
                Where = e => e.FirstName == employee.FirstName
                && e.LastName.ToLower() == employee.LastName.ToLower() && e.DOB == employee.DOB
            };

            Employee confirmEmployee = data.Get(options);

            return confirmEmployee == null ? 
                string.Empty 
                : $"{confirmEmployee.FullName} (DOB: {confirmEmployee.DOB?.ToShortDateString()}) is already in the database.";
        }

        public static string EmployeeManagerMatch(Repository<Employee> data, Employee employee)
        {
            Employee manager = data.Get(employee.ManagerId);

            if(manager != null && manager.FirstName.ToLower() == employee.FirstName.ToLower()
                && manager.LastName.ToLower() == employee.LastName.ToLower() && manager.DOB == employee.DOB)
            {
                return $"Manager and employee cannot be the same person";
            }

            return string.Empty;
        }

        public static string ConfirmSales(IUnitOfWork data, Sales sale)
        {
            var options = new QueryOptions<Sales>
            {
                Where = s => s.EmployeeId == sale.EmployeeId
                && s.Year == sale.Year && s.Quarter == sale.Quarter
            };

            Sales sales = data.Sales.Get(options);

            if(sales == null)
            {
                return string.Empty;
            }

            Employee employee = data.Employees.Get(sale.EmployeeId);
            return $"Sales for {employee.FullName} for {sale.Year} Q{sale.Quarter} are already in the database.";
        }
    }
}
