using EmployeeManagementAPI.Fluent_Validation;
using FluentValidation;

namespace EmployeeManagementAPI.Data.Command.Create
{
    /// <summary>
    /// Validation for CreateUser 
    /// </summary>
    public class CreateUserValidation : AbstractValidator<CreateUser>
    {
        public CreateUserValidation()
        {
            RuleFor(m => m.EmployeeName).NotNull().NotEmpty().SetValidator(new NameValidation());
            RuleFor(m => m.EmployeeAddress).NotNull().NotEmpty().MaximumLength(23).Must(a => a.ToLower().Contains("street") == true).WithMessage("Mention with StreetName");
            RuleFor(m => m.EmployeeMaritalStatus).NotNull().NotEmpty().SetValidator(new MaritalStatusValidation());
            RuleFor(m => m.EmployeeEmailId).NotNull().NotEmpty().WithMessage("Invaild MailId").SetValidator(new EmailValidation());
            RuleFor(m => m.EmployeeMobileNumber).NotNull().Length(9).WithMessage("Invalid MobileNumber").SetValidator(new MobileNumberValidation());
            RuleFor(m => m.EmployeeDateOfJoining).NotNull().NotEmpty();

        }

    }
}
