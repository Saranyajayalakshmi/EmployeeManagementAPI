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
            RuleFor(m => m.EmployeeName).NotEmpty().SetValidator(new NameValidator()).When(x=>x.EmployeeName!=null);
            RuleFor(m => m.EmployeeAddress).NotEmpty().MaximumLength(23).SetValidator(new AddressValidator()).When(x => x.EmployeeAddress!=null);
            RuleFor(m => m.EmployeeMaritalStatus).NotEmpty().SetValidator(new MaritalStatusValidator()).When(x=>x.EmployeeMaritalStatus!=null);
            RuleFor(m => m.EmployeeEmailId).SetValidator(new EmailValidator()).When(x=>x.EmployeeEmailId!=null);
            RuleFor(m => m.EmployeeMobileNumber).Length(9).WithMessage("Invalid MobileNumber").SetValidator(new MobileNumberValidator()).When(x=>x.EmployeeMobileNumber!=null);
            RuleFor(m => m.EmployeeDateOfJoining).NotNull().NotEmpty();

        }

    }
}
