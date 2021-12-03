using System;
using Microsoft.AspNetCore.Http;

namespace SalesApp.Models
{
    public class SalesGridBuilder : GridBuilder
    {
        public SalesGridBuilder(ISession sess) : base(sess) { }

        public SalesGridBuilder(ISession sess, SalesGridDTO values, string defaultSortField) 
            : base(sess, values, defaultSortField)
        {
            routes.EmployeeFilter = values.Employee;
            routes.YearFilter = values.Year;
            routes.QuarterFilter = values.Quarter;
        }

        public void LoadFilterSegments(string[] filter, Employee employee)
        {
            if (employee == null)
            {
                routes.EmployeeFilter = filter[0];                
            }
            else
            {
                routes.EmployeeFilter = filter[0] + "-" + employee.FullName.Slug();
            }
            routes.YearFilter = filter[1];
            routes.QuarterFilter = filter[2];
        }

        public void ClearFilterSegments() => routes.ClearFilters();

        public bool IsFilterByEmployee => routes.EmployeeFilter != SalesGridDTO.DefaultFilter;
        public bool IsFilterByYear => routes.YearFilter != SalesGridDTO.DefaultFilter;
        public bool IsFilterByQuarter => routes.QuarterFilter != SalesGridDTO.DefaultFilter;

        public bool IsSortByQuarter => routes.SortField.Equals(nameof(Sales.Quarter), StringComparison.InvariantCultureIgnoreCase);
        public bool IsSortByYear => routes.SortField.Equals(nameof(Sales.Year), StringComparison.InvariantCultureIgnoreCase);
        public bool IsSortByEmployee => routes.SortField.Equals(nameof(Employee), StringComparison.InvariantCultureIgnoreCase);
        public bool IsSortByAmount => routes.SortField.Equals(nameof(Sales.Amount), StringComparison.InvariantCultureIgnoreCase);
    }
}
