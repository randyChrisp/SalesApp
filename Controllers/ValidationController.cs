using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesApp.Models;

namespace SalesApp.Controllers
{
    public class ValidationController : Controller
    {
        private UnitOfWork data { get; set; }
        public ValidationController(SalesAppContext ctx)
        {
            this.data = new UnitOfWork(ctx);
        }

        public JsonResult ValidateEmployee(string firstName, string lastName, DateTime dob)
        {
            Employee employee = new Employee
            {
                FirstName = firstName,
                LastName = lastName,
                DOB = dob
            };

            string message = Validate.ValidateEmployee(data.Employees, employee);
            if (string.IsNullOrEmpty(message))
            {
                return Json(true);
            }

            return Json(message);
        }

        public JsonResult EmployeeManagerMatch(int managerId, string firstName, string lastName, DateTime dob)
        {
            Employee employee = new Employee
            {
                ManagerId = managerId,
                FirstName = firstName,
                LastName = lastName,
                DOB = dob
            };

            string message = Validate.EmployeeManagerMatch(data.Employees, employee);
            if (string.IsNullOrEmpty(message))
            {
                return Json(true);
            }

            return Json(message);
        }

        public JsonResult ConfirmSales(int employeeId, int year, int quarter)
        {
            Sales sale = new Sales
            {
                EmployeeId = employeeId,
                Year = year,
                Quarter = quarter
            };

            string message = Validate.ConfirmSales(data, sale);
            if (string.IsNullOrEmpty(message))
            {
                return Json(true);
            }

            return Json(message);
        }
    }
}
