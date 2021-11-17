using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesApp.Models;
using SalesApp.Models.Validation;

namespace SalesApp.Controllers
{
    public class EmployeeController : Controller
    {
        private SalesAppContext context { get; set; }

        public EmployeeController(SalesAppContext ctx)
        {
            context = ctx;
        }

        public IActionResult Index()
        {
            return RedirectToAction("Index", "Home");
        }        

        [HttpGet]
        public ViewResult AddEmployee()
        {
            ViewBag.Employees = context.Employees.OrderBy(e => e.LastName).ThenBy(e => e.FirstName).ToList();
            return View();
        }
        
        
        public IActionResult AddEmployee(Employee employee)
        {
            string message = Validate.ValidateEmployee(context, employee);
            if(!string.IsNullOrEmpty(message))
            {
                ModelState.AddModelError(nameof(Employee.DOB), message);
            }

            message = Validate.EmployeeManagerMatch(context, employee);
            {
                ModelState.AddModelError(nameof(Employee.ManagerId), message);
            }

            if(ModelState.IsValid)
            {
                context.Employees.Add(employee);
                context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Employees = context.Employees.OrderBy(e => e.LastName).ThenBy(e => e.FirstName).ToList();
                return View();
            }
        }
    }
}
