using FluentValidation.Validators;

namespace EmployeeManagementAPI.Fluent_Validation
{
    public class MaritalStatusValidator : PropertyValidator
    {
        public MaritalStatusValidator() : base("Invaild MaritalStatus")
        {
        }

        protected override bool IsValid(PropertyValidatorContext context)
        {
            
          return context.PropertyValue is (object)"Married" or (object)"Single";
          
            
        }
    }
}
