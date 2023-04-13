using EmployeeManagementAPI.Data.Command;
using FluentValidation;
using System.Text.RegularExpressions;
using EmployeeManagementAPI.Model;
using EmployeeManagementAPI.Fluent_Validation;

namespace EmployeeManagementAPI.Data.Command.Update
{
    public class UpdateUserValidation : AbstractValidator<UpdateUser>
    {
        public UpdateUserValidation()
        {
            RuleFor(m => m.EmployeeName).NotEmpty().SetValidator(new NameValidation());
            RuleFor(m => m.EmployeeMaritalStatus).NotNull().NotEmpty().SetValidator(new MaritalStatusValidation());
            RuleFor(m => m.EmployeeEmailId).NotNull().SetValidator(new EmailValidation());
            RuleFor(m => m.EmployeeMobileNumber).NotNull().SetValidator(new MobileNumberValidation());

        }
    }
}
