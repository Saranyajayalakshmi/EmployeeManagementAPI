using EmployeeManagementAPI.Fluent_Validation;
using FluentValidation;

namespace EmployeeManagementAPI.Data.Command.Update
{
    /// <summary>
    /// UpdateUser Validation by SetValidator
    /// </summary>
    public class UpdateUserValidation : AbstractValidator<UpdateUser>
    {
        //SetValidator for EmployeeName,EmailId,MaritalStatus,mobileNumber
        public UpdateUserValidation()
        {
            RuleFor(m => m.EmployeeName).NotEmpty().SetValidator(new NameValidator()).When(x=>x.EmployeeName!=null);
            RuleFor(m => m.EmployeeAddress).NotEmpty().SetValidator(new AddressValidator()).When(x => x.EmployeeAddress!=null); ;
            RuleFor(m => m.EmployeeMaritalStatus).NotEmpty().SetValidator(new MaritalStatusValidator()).When(x => x.EmployeeMaritalStatus!=null);
            RuleFor(m => m.EmployeeEmailId).NotNull().SetValidator(new EmailValidator()).When(x=>x.EmployeeEmailId!=null);
            RuleFor(m => m.EmployeeMobileNumber).NotNull().NotEmpty().SetValidator(new MobileNumberValidator()).When(x=>x.EmployeeMobileNumber!=null);
            RuleFor(m => m.EmployeeDateOfJoining).NotNull().NotEmpty();

        }
    }
}
