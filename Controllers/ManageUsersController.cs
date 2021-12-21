using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesApp.Models;

namespace SalesApp.Controllers
{
    public class ManageUsersController : Controller
    {
        private SalesAppContext context { get; set; }
        private UnitOfWork data { get; set; }

        public ManageUsersController(SalesAppContext ctx)
        {
            this.data = new UnitOfWork(ctx);
        }

        public IActionResult Index() => RedirectToAction("Index", "Home");

        [HttpGet]
        public ViewResult Add()
        {
            ViewBag.Employees = context.Employees.OrderBy(e => e.LastName).ThenBy(e => e.FirstName).ToList();
            return View();

        }

        public IActionResult Add(Employee employee)
        {
            string message = Validate.ValidateEmployee(data.Employees, employee);
            if (!string.IsNullOrEmpty(message))
            {
                ModelState.AddModelError(nameof(Employee.DOB), message);
            }

            message = Validate.EmployeeManagerMatch(data.Employees, employee);
            if (!string.IsNullOrEmpty(message))
            {
                ModelState.AddModelError(nameof(Employee.ManagerId), message);
            }
            if (ModelState.IsValid)
            {
                context.Employees.Add(employee);
                context.SaveChanges();
                TempData["message"] = $"Employee {employee.FullName} added";
                return RedirectToAction("Index", "Home");

            }
            else
            {
                ViewBag.Employees = context.Employees.OrderBy(e => e.LastName).ThenBy(e => e.FirstName).ToList();
            }
            return View();

        }

    }
}
