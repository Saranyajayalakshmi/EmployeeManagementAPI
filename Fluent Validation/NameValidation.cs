using FluentValidation.Resources;
using FluentValidation.Validators;
using System.Text.RegularExpressions;

namespace EmployeeManagementAPI.Fluent_Validation
{
    public class NameValidation : PropertyValidator
    {
        public NameValidation() : base("Check the Name")
        {
        }

        protected override bool IsValid(PropertyValidatorContext context)
        {
            Regex regex = new Regex(@"^[a-zA-Z''-'\s]{1,40}$", RegexOptions.IgnoreCase);
            if (context.PropertyValue != null)
            {
                return regex.IsMatch((string)context.PropertyValue);
            }
            else
            {
                return false;
            }
        }
    }
}
