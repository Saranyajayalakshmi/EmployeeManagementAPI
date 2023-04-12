using FluentValidation.Validators;

namespace EmployeeManagementAPI.Fluent_Validation
{
    public class MaritalStatusValidation : PropertyValidator
    {
        public MaritalStatusValidation() : base("Enter proper Status")
        {
        }

        protected override bool IsValid(PropertyValidatorContext context)
        {
            
          return context.PropertyValue is (object)"Married" or (object)"Single";
            
        }
    }
}
