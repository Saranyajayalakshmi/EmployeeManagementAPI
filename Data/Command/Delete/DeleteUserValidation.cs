using EmployeeManagementAPI.Data.Command;
using FluentValidation;

namespace EmployeeManagementAPI.Data.Command.Delete
{
    public class DeleteUserValidation : AbstractValidator<DeleteUser>
    {
        /// <summary>
        /// Validation for Deleteuser By EmployeeId
        /// </summary>
        public DeleteUserValidation()
        {
            RuleFor(m => m.EmployeeId).NotNull().NotEmpty().OverridePropertyName("Invalid Id");
        }
    }
}
