using EmployeeManagementAPI.Data.Handlers;
using EmployeeManagementAPI.Fluent_Validation;
using FluentValidation;

namespace EmployeeManagementAPI.Module.Query
{
    public class GetEmployeeIdValidator : AbstractValidator<GetEmployeeDetail>
    {
        public GetEmployeeIdValidator()
        {
            RuleFor(x => x.Id).NotNull();/*SetValidator(new GetByIdValidator()).When(x=>x.Id!=null);*/
        }
    }
}
