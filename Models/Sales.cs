using System.ComponentModel.DataAnnotations;
using SalesApp.Models.Validation;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesApp.Models
{
    public class Sales
    {
        public int SalesId { get; set; }

        [AfterDate(0, ErrorMessage = "Please choose an employee.")]
        [Remote("ConfirmSales", "Validation", AdditionalFields = "Quarter, Year")]
        [Display(Name ="Employee")]
        public int EmployeeId { get; set; }

        public Employee Employee { get; set; }

        [Required(ErrorMessage = "Please enter a quarter.")]
        [Range(1,4, ErrorMessage = "Please enter a quarter between 1 and 4.")]
        public int? Quarter { get; set; }

        [Required(ErrorMessage = "Please enter a year.")]
        [AfterDate(2000, ErrorMessage = "The year must be after 2000.")]
        public int? Year { get; set; }

        [Required(ErrorMessage = "Please enter an amount.")]
        [AfterDate(0.0, ErrorMessage = "The amount must be greater than zero.")]
        [Range(0.1, int.MaxValue, ErrorMessage = "Please enter an amount greater than 0.")]
        public double? Amount { get; set; }
    }
}
