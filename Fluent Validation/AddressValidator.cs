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
            Regex regex = new Regex("^[0-9]{5}(?:-[0-9]{4})?$", RegexOptions.IgnoreCase);
            return regex.IsMatch((string)context.PropertyValue);



        }
    }
}
