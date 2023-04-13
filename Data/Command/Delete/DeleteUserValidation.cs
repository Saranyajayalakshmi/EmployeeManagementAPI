using EmployeeManagementAPI.Data.Command;
using FluentValidation;

namespace EmployeeManagementAPI.Data.Command.Delete
{
    public class DeleteUserValidation : AbstractValidator<DeleteUser>
    {
        public DeleteUserValidation()
        {
            RuleFor(m => m.EmployeeId).NotNull().NotEmpty().OverridePropertyName("Invalid Id");
        }
    }
}
