using FluentValidation;
using EmployeeManagementAPI.Model;
using FluentValidation.Results;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using EmployeeManagementAPI.Data.Command;

namespace EmployeeManagementAPI.Data.Command.Create
{
    /// <summary>
    /// Validation for CreateUser 
    /// </summary>
    public class CreateUserValidation : AbstractValidator<CreateUser>
    {
        public CreateUserValidation()
        {
            RuleFor(m => m.EmployeeName).NotNull().NotEmpty();
            RuleFor(m => m.EmployeeAddress).NotNull().MaximumLength(8);
            RuleFor(m => m.EmployeeAddress).Must(a => a.ToLower().Contains("street") == true).WithMessage("Mention with StreetName");
            RuleFor(m => m.EmployeeMaritalStatus).NotNull().NotEmpty();
            RuleFor(m => m.EmployeeEmailId).NotNull().WithMessage("Invaild MailId");
            RuleFor(m => m.EmployeeMobileNumber).NotNull().Length(9).WithMessage("Invalid MobileNumber");

        }

    }
}
