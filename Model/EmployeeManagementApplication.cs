using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementAPI.Model
{
    /// <summary>
    /// EmployeeManagement Properties
    /// </summary>
    public class EmployeeManagementApplication : IValidatableObject
    {
        [Key]
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeEmailId { get; set; }
        public string EmployeeMobileNumber { get; set; }
        public string EmployeeAddress { get; set; }
        public string EmployeeMaritalStatus { get; set; }
        public DateTime EmployeeDateOfJoining { get; set; }

       
        // Validate for DateOfJoining
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (EmployeeDateOfJoining == DateTime.MinValue) { yield break; }
        }

    }
}
 