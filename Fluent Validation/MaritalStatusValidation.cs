using FluentValidation.Validators;

namespace EmployeeManagementAPI.Fluent_Validation
{
    public class MaritalStatusValidation : PropertyValidator
    {
        public MaritalStatusValidation() : base("Invaild")
        {
        }

        protected override bool IsValid(PropertyValidatorContext context)
        {
            
          return context.PropertyValue is (object)"Married" or (object)"Single";
          
            
        }
    }
}
