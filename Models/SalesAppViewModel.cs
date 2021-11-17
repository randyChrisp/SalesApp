using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesApp.Models;

namespace SalesApp.Models
{
    public class SalesAppViewModel
    {
        public List<Employee> Employee { get; set; }

        public List<Sales> Sales { get; set; }

        public int EmployeeId { get; set; }
    }
}
