using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SalesApp.Models.Validation
{
    public class AfterDateAttribute : ValidationAttribute
    {
        private object valueDate { get; set; }

        public AfterDateAttribute(object compareTo) => valueDate = compareTo;

        protected override ValidationResult IsValid(object value, ValidationContext ctx)
        {
            if (value is int)
            {
                int checkDate = (int)value;
                int dateToCompare = (int)valueDate;

                if(checkDate > dateToCompare)
                {
                    return ValidationResult.Success;
                }
            }
            else if (value is double)
            {
                double checkDate = (double)value;
                double dateToCompare = (double)valueDate;
                if (checkDate > dateToCompare)
                {
                    return ValidationResult.Success;
                }
            }
            else if (value is DateTime)
            {
                DateTime checkDate = (DateTime)value;
                DateTime dateToCompare = new DateTime();
                DateTime.TryParse(valueDate.ToString(), out dateToCompare);
                
                if (checkDate > dateToCompare)
                {
                    return ValidationResult.Success;
                }
            }
            else
            {
                return ValidationResult.Success;
            }

            string msg = base.ErrorMessage ?? $"{ctx.DisplayName} must be after {valueDate.ToString()}.";
            return new ValidationResult(msg);
        }
    }
}
