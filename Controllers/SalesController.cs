using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesApp.Models;

namespace SalesApp.Controllers
{
    public class SalesController : Controller
    {
        private UnitOfWork data { get; set; }

        public SalesController(SalesAppContext ctx)
        {
            this.data = new UnitOfWork(ctx);
        }

        public IActionResult Index()
        {
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ViewResult AddEmployee()
        {
            ViewBag.Employees = data.Employees.List(new QueryOptions<Employee> { OrderBy = e => e.FirstName });
            return View();
        }

        
        public IActionResult AddSales(Sales sales)
        {
            string message = Validate.ConfirmSales(data, sales);
            if (!string.IsNullOrEmpty(message))
            {
                ModelState.AddModelError(nameof(sales.EmployeeId), message);
            }

            if (ModelState.IsValid)
            {
                data.Sales.Insert(sales);
                data.Save();
                
                TempData["message"] = $"Sales added";
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Employees = data.Employees.List(new QueryOptions<Employee> { OrderBy = e => e.FirstName });
                return View();
            }
        }
    }
}
