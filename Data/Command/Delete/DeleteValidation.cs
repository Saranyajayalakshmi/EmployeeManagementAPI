using EmployeeManagementAPI.Data.Command;
using FluentValidation;

namespace EmployeeManagementAPI.Data.Command.Delete
{
    public class DeleteValidation : AbstractValidator<DeleteEmployee>
    {
        public DeleteValidation()
        {
            RuleFor(m => m.Id).NotNull().NotEmpty().OverridePropertyName("Invalid Id");
        }
    }
}
