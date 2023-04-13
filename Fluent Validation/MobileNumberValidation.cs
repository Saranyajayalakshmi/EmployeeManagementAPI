using FluentValidation.Validators;
using System.Numerics;
using System.Text.RegularExpressions;

namespace EmployeeManagementAPI.Fluent_Validation
{
    public class MobileNumberValidation : PropertyValidator
    {
        public MobileNumberValidation() : base("Enter Vaild MobileNumber")
        {
        }

        protected override bool IsValid(PropertyValidatorContext context)
        {
           var data = context.PropertyValue.ToString();
            if (data.Length>= 9)
            {
                
              return true;
            }
            else return false;
        }
    }
}
