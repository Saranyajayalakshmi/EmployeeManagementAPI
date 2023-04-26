using FluentValidation.Validators;

namespace EmployeeManagementAPI.Fluent_Validation
{
    /// <summary>
    /// Validation for MobileNumber
    /// </summary>
    public class MobileNumberValidator : PropertyValidator
    {
        public MobileNumberValidator() : base("Invaild MobileNumber")
        {
        }
        
        // validation by Length of MobileNumber
      
        protected override bool IsValid(PropertyValidatorContext context)
        {
           var phonenumber = context.PropertyValue.ToString();
            if (phonenumber.Length<= 10)
              return true;
            else 
                return false;
        }
    }
}
