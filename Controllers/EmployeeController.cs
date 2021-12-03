using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesApp.Models;

namespace SalesApp.Controllers
{
    public class EmployeeController : Controller
    {
        public Repository<Employee> data { get; set; }

        public EmployeeController(SalesAppContext ctx)
        {
            this.data = new Repository<Employee>(ctx);
        }

        public IActionResult Index()
        {
            return RedirectToAction("Index", "Home");
        }        

        [HttpGet]
        public ViewResult AddEmployee()
        {
            ViewBag.Employees = data.List(new QueryOptions<Employee> { OrderBy = e => e.FirstName});
            return View();
        }
        
        
        public IActionResult AddEmployee(Employee employee)
        {
            string message = Validate.ValidateEmployee(data, employee);
            if(!string.IsNullOrEmpty(message))
            {
                ModelState.AddModelError(nameof(Employee.DOB), message);
            }

            message = Validate.EmployeeManagerMatch(data, employee);
            if (!string.IsNullOrEmpty(message))
            {
                ModelState.AddModelError(nameof(Employee.ManagerId), message);
            }

            if(ModelState.IsValid)
            {
                data.Insert(employee);
                data.Save();

                TempData["message"] = $"Added {employee.FullName}";
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Employees = data.List(new QueryOptions<Employee> { OrderBy = e => e.FirstName });
                return View();
            }
        }
    }
}
