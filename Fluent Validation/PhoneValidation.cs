using FluentValidation.Validators;
using System.Numerics;
using System.Text.RegularExpressions;

namespace EmployeeManagementAPI.Fluent_Validation
{
    public class PhoneValidation : PropertyValidator
    {
        public PhoneValidation() : base("Please enter the PhoneNumber")
        {
        }

        protected override bool IsValid(PropertyValidatorContext context)
        {
            Regex regex = new Regex(@"^[0-9]$",RegexOptions.IgnoreCase);
            if (context != null)
            {
                
               return regex.IsMatch(context.PropertyName);
            }
            else return false;
        }
    }
}
