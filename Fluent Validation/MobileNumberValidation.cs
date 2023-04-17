using FluentValidation.Validators;
using System.Numerics;
using System.Text.RegularExpressions;

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
        /// <summary>
        /// validation by Length of Mobilenumber
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
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
