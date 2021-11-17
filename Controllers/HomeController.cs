using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SalesApp.Models;

namespace SalesApp.Controllers
{
    public class HomeController : Controller
    {
        private SalesAppContext context { get; set; }

        public HomeController(SalesAppContext ctx)
        {
            context = ctx;
        }

        [HttpGet]
        public ViewResult Index(int id)
        {
            IQueryable<Sales> query = context.SalesDb
                .Include(s => s.Employee)
                .OrderBy(s => s.Employee.LastName)
                .ThenBy(s => s.Employee.FirstName)
                .ThenBy(s => s.Year)
                .ThenBy(s => s.Quarter);

            if(id > 0)
            {
                query = query.Where(s => s.EmployeeId == id);
            }

            SalesAppViewModel viewModel = new SalesAppViewModel
            {
                Sales = query.ToList(),
                Employee = context.Employees
                .OrderBy(e => e.LastName)
                .ThenBy(e => e.FirstName)
                .ToList(),
                EmployeeId = id
            };

            return View(viewModel);            
        }
        
        [HttpPost]
        public RedirectToActionResult Index(Employee employee)
        {
            if(employee.EmployeeId > 0)
            {
                return RedirectToAction("Index", new { id = employee.EmployeeId });
            }
            else
            {
                return RedirectToAction("Index", new { id = string.Empty });
            }
        }
    }
}
