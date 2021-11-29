using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesApp.Models.Validation
{
    public static class Validate
    {
        public static string ValidateEmployee(SalesAppContext context, Employee employee)
        {
            Employee confirmEmployee = context.Employees.FirstOrDefault(e=> e.FirstName.ToLower() == employee.FirstName.ToLower() 
            && e.LastName.ToLower() == employee.LastName.ToLower() && e.DOB == employee.DOB);

            return confirmEmployee == null ? 
                string.Empty 
                : $"{confirmEmployee.FullName} (DOB: {confirmEmployee.DOB?.ToShortDateString()}) is already in the database.";
        }

        public static string EmployeeManagerMatch(SalesAppContext context, Employee employee)
        {
            Employee manager = context.Employees.Find(employee.ManagerId);

            if(manager != null && manager.FirstName.ToLower() == employee.FirstName.ToLower()
                && manager.LastName.ToLower() == employee.LastName.ToLower() && manager.DOB == employee.DOB)
            {
                return $"Manager and employee cannot be the same person";
            }

            return string.Empty;
        }

        public static string ConfirmSales(SalesAppContext context, Sales sale)
        {
            Sales sales = context.SalesDb.FirstOrDefault(
                s => s.EmployeeId == sale.EmployeeId && s.Year == sale.Year && s.Quarter == sale.Quarter);

            if(sales == null)
            {
                return string.Empty;
            }

            Employee employee = context.Employees.Find(sale.EmployeeId);
            return $"Sales for {employee.FullName} for {sale.Year} Q{sale.Quarter} are already in the database.";
        }
    }
}
