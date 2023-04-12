using EmployeeManagementAPI.Data.Command;
using FluentValidation;
using System.Text.RegularExpressions;
using EmployeeManagementAPI.Model;
using EmployeeManagementAPI.Fluent_Validation;

namespace EmployeeManagementAPI.Data.Command.Update
{
    public class UpdateValidation : AbstractValidator<UpdateEmployee>
    {
        public UpdateValidation()
        {
            RuleFor(m => m.FirstName).NotEmpty().SetValidator(new NameValidation());
            RuleFor(m => m.Marritalstatus).NotNull().NotEmpty().SetValidator(new MaritalStatusValidation());
            RuleFor(m => m.Email).NotNull().SetValidator(new EmailValidation());
            RuleFor(m => m.Phone).NotNull().SetValidator(new PhoneValidation());

        }
    }
}
