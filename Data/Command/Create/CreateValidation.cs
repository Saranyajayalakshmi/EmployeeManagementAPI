using FluentValidation;
using EmployeeManagementAPI.Model;
using FluentValidation.Results;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using EmployeeManagementAPI.Data.Command;

namespace EmployeeManagementAPI.Data.Command.Create
{
    public class EmployeeManageClass : AbstractValidator<CreateEmployee>
    {
        public EmployeeManageClass()
        {
            RuleFor(u => u.FirstName).NotNull().NotEmpty();
            RuleFor(model => model.Address).NotNull().MaximumLength(8);
            RuleFor(model => model.Address).Must(a => a.ToLower().Contains("street") == true).WithMessage("Please Mention the Correct Address");
            RuleFor(m => m.Marritalstatus).NotNull().NotEmpty();
            RuleFor(m => m.Email).NotNull().WithMessage("Invalid MailId");
            RuleFor(m => m.Phone).NotNull().Length(9).WithMessage("Invalid Number");

        }

    }
}
