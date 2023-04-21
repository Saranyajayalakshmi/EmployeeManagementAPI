using FluentValidation.Validators;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace EmployeeManagementAPI.Fluent_Validation
{
    public class DateValidator : PropertyValidator
    {
        public DateValidator() : base("InvaildDate")
        {
        }

        protected override bool IsValid(PropertyValidatorContext context)
        {
            Regex regex = new Regex("^[0-9]{1,2}\\/[0-9]{1,2}\\/[0-9]{4}$", RegexOptions.IgnoreCase);
            return regex.IsMatch((string)context.PropertyValue);
        }
    }
}
