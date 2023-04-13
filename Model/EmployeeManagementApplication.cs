using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementAPI.Model
{
    public class EmployeeManagementApplication : IValidatableObject
    {
        [Key]
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeEmailId { get; set; }
        [EmailAddress]
        public string EmployeeMobileNumber { get; set; }
        public string EmployeeAddress { get; set; }
        public string EmployeeMaritalStatus { get; set; }
        public DateTime EmployeeDateOfJoining { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
         if(EmployeeDateOfJoining == DateTime.MinValue) { yield break; }
        }

      
    }
}
