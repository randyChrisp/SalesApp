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
        private UnitOfWork data { get; set; }


        public HomeController(SalesAppContext ctx)
        {
            this.data = new UnitOfWork(ctx);
        }

        [HttpGet]
        public ViewResult Index(SalesGridDTO values)
        {
            string defaultSort = nameof(Sales.Year);
            var builder = new SalesGridBuilder(HttpContext.Session, values, defaultSort);

            var options = new SalesQueryOptions
            {
                Includes = "Employee",
                OrderByDirection = builder.CurrentRoute.SortDirection,
                PageNumber = builder.CurrentRoute.PageNumber,
                PageSize = builder.CurrentRoute.PageSize
            };

            options.SortFilter(builder);

            SalesAppViewModel viewModel = new SalesAppViewModel
            {
                Sales = data.Sales.List(options),
                Employees = data.Employees.List(new QueryOptions<Employee> { OrderBy = e => e.FirstName}),
                CurrentRoute = builder.CurrentRoute,
                TotalPages = builder.GetTotalPages(data.Sales.Count)
            };

            return View(viewModel);            
        }
        
        [HttpPost]
        public RedirectToActionResult Filter(string[] filter, bool clear = false)
        {
            var builder = new SalesGridBuilder(HttpContext.Session);

            if(clear)
            {
                builder.ClearFilterSegments();
            }
            else
            {
                var employee = data.Employees.Get(filter[0].ToInt());
                builder.LoadFilterSegments(filter, employee);
            }

            return RedirectToAction("Index", builder.CurrentRoute);
        }

        [HttpGet]
        public RedirectToActionResult Clear()
        {
            return RedirectToAction("Index", new { });
        }
    }
}
