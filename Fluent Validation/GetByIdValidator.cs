using FluentValidation.Resources;
using FluentValidation.Validators;
using System.Text.RegularExpressions;

namespace EmployeeManagementAPI.Fluent_Validation
{
    public class GetByIdValidator : PropertyValidator
    {
        public GetByIdValidator() : base("InvalidId")
        {
        }

        protected override bool IsValid(PropertyValidatorContext context)
        {
            int ID = (int)context.PropertyValue;
            Regex regex = new Regex("^[0-9]+$");
            return regex.Equals(ID);
        }
    }
}
