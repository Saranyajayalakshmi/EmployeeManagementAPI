using FluentValidation;
using EmployeeManagementAPI.Model;
using FluentValidation.Results;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace EmployeeManagementAPI.Fluent_Validation
{
    public class EmployeeManageClass : AbstractValidator<EmployeeManage>
    {
        public EmployeeManageClass()
        {
            RuleFor(u => u.FirstName).NotNull().NotEmpty();
            RuleFor(model => model.Address).NotNull().MaximumLength(8);
            RuleFor(model => model.Address).Must(a => a.ToLower().Contains("street")==true).WithMessage("Please Mention the Correct Address");
            RuleFor(m=>m.Marritalstatus).NotNull().NotEmpty().Must(IsValidStatus).WithMessage("invalid entity");
            RuleFor(m => m.Email).NotNull().Must(IsValidEmail).WithMessage("Invalid MailId");
            RuleFor(m=>m.Phone).NotNull().Must(IsValidPhone).WithMessage("Invalid MobileNumber");
            
        }
        public static bool IsValidEmail(string email)
        {
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", RegexOptions.IgnoreCase);
            return regex.IsMatch(email);
        }

        public static bool IsValidPhone(string Phone)
        {
            string regex = @"^([\+]?33[-]?|[0])?[1-9][0-9]{8}$";
            if (Phone != null)
                return Regex.IsMatch(Phone, regex);
            else return false;
        }
        private bool IsValidStatus(string MaritalStatus)
        {
            return(( MaritalStatus=="Married") || (MaritalStatus=="Single"));
        }

    }
}
