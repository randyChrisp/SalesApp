using System.ComponentModel.DataAnnotations;
using SalesApp.Models.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesApp.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "Please enter a first name.")]
        [Display(Name = "First Name")]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter a last name.")]
        [Display(Name = "Last Name")]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter a date of birth.")]
        [PastDate(ErrorMessage = "Please enter a date of birth in the past.")]
        [Range(typeof(DateTime), "1/1/1900", "12/31/9999", ErrorMessage = "Date of birth must be after 1/1/1900.")]
        [Display(Name = "Birth Date")]
        public DateTime? DOB { get; set; }

        [Required(ErrorMessage = "Please enter a hire date.")]
        [PastDate(ErrorMessage = "Please enter a hire date in the past.")]
        [AfterDate("1/1/1995", ErrorMessage = "Hire date must be after 1/1/1995.")]
        [Display(Name = "Hire Date")]
        public DateTime? HireDate { get; set; }

        [AfterDate(0, ErrorMessage = "Please choose a manager.")]
        [Display(Name = "Manager")]
        public int ManagerId { get; set; }

        public string FullName => $"{FirstName } {LastName }";
    }
}
