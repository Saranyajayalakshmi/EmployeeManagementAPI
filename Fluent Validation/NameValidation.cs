using FluentValidation.Validators;
using System.Text.RegularExpressions;

namespace EmployeeManagementAPI.Fluent_Validation
{
    /// <summary>
    /// Validation for EmployeeName
    /// </summary>
    public class NameValidation : PropertyValidator
    {
        public NameValidation() : base("Invaild")
        {
        }
        /// <summary>
        /// Validate with RegularExpression method
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        protected override bool IsValid(PropertyValidatorContext context)
        {
           Regex regex = new Regex(@"^[a-zA-Z''-'\s]{1,40}$", RegexOptions.IgnoreCase);
           return regex.IsMatch((string)context.PropertyValue);
            
        }
    }
}
