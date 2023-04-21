using EmployeeManagementAPI.Data.Handlers;
using FluentValidation;

namespace EmployeeManagementAPI.Module.Query
{
    public class GetEmployeeIdValidator : AbstractValidator<GetEmployeeDetail>
    {
        public GetEmployeeIdValidator()
        {
            RuleFor(x => x.Id).NotEmpty().NotNull().GreaterThan(0);
        }
    }
}
