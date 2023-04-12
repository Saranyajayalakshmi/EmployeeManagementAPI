using FluentValidation;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementAPI.Model
{
    public class EmployeeManage : IValidatableObject
    {
        /// <summary>
        /// Employee Details
        /// </summary>

        public int Id { get; set; }
        public string FirstName { get; set; }

        public string Email { get; set; }
        [Required(ErrorMessage = "Please enter phone number")]
        public string Phone { get; set; }
        public string Address { get; set; }
        public string MarritalStatus { get; set; }

        public DateTime DOJ { get; set; }

        public IEnumerable<ValidationResult> Validate(System.ComponentModel.DataAnnotations.ValidationContext validationContext)
        {
            if (DOJ.Year<2022)
                yield return new ValidationResult("Date is Incorrect");
        }
    }
}
