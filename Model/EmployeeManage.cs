using FluentValidation;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementAPI.Model
{
    public class EmployeeManage
    {
       
        public int Id { get; set; } 
       /// <summary>
       /// Employee Details 
       /// </summary>
        public string FirstName { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string Phone { get; set; }
       
        public string Address { get; set; }
        public string Maritalstatus { get; set; }
        public DateTime DOJ { get; set; }
        
    }
    public class employeValdite : AbstractValidator<EmployeeManage>
    {
        public employeValdite() {
        
            RuleFor(model => model.Address).MaximumLength(8);
          

        }
    }
}
