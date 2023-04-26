using FluentValidation.Validators;
using System.Text.RegularExpressions;

namespace EmployeeManagementAPI.Fluent_Validation
{
    public class AddressValidator : PropertyValidator
    {
        public AddressValidator() : base("Invalid Address")
        {
        }

        protected override bool IsValid(PropertyValidatorContext context)
        {
            Regex regex = new Regex(@"^[A-Za-z0-9]+(?:\s[A-Za-z0-9'_-]+)+$", RegexOptions.IgnoreCase);
            return regex.IsMatch((string)context.PropertyValue);



        }
    }
}
