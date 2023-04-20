using FluentValidation.Validators;
using System.Text.RegularExpressions;

namespace EmployeeManagementAPI.Fluent_Validation
{
    /// <summary>
    /// Validate for Emoplyee EmailId
    /// </summary>
    public class EmailValidator : PropertyValidator
    {
        public EmailValidator() : base("InVaild  EmailId")
        {

        }
        /// <summary>
        /// Validation using Regular Expression method
        /// </summary>
        /// <param name="contect"></param>
        /// <returns></returns>
        protected override bool IsValid(PropertyValidatorContext contect)
        {
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", RegexOptions.IgnoreCase);
            return regex.IsMatch((string)contect.PropertyValue);
             

        }
    }


}
