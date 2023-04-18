using FluentValidation.Validators;

namespace EmployeeManagementAPI.Fluent_Validation
{
    /// <summary>
    /// Validation for MobileNumber
    /// </summary>
    public class MobileNumberValidation : PropertyValidator
    {
        public MobileNumberValidation() : base("Invaild")
        {
        }
        
        // validation by Length of MobileNumber
      
        protected override bool IsValid(PropertyValidatorContext context)
        {
           var phonenumber = context.PropertyValue.ToString();
            if (phonenumber.Length<= 9)
              return true;
            else 
                return false;
        }
    }
}
