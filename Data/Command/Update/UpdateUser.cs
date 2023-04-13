using EmployeeManagementAPI.Model;

using MediatR;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementAPI.Data.Command.Update
{
    /// <summary>
    ///Creating Updateuser
    /// </summary>
    public class UpdateUser : IRequest<ResultResponse>
    {
        public UpdateUser(int employeeID, string employeeName, string employeeEmailId, string employeeMobileNumber, string employeeAddress, string employeeMaritalStatus, DateTime employeeDateOfJoining)
        {
            EmployeeID=employeeID;
            EmployeeName=employeeName;
            EmployeeEmailId=employeeEmailId;
            EmployeeMobileNumber=employeeMobileNumber;
            EmployeeAddress=employeeAddress;
            EmployeeMaritalStatus=employeeMaritalStatus;
            EmployeeDateOfJoining=employeeDateOfJoining;
        }

        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeEmailId { get; set; }
        public string EmployeeMobileNumber { get; set; }
        public string EmployeeAddress { get; set; }
        public string EmployeeMaritalStatus { get; set; }
        public DateTime EmployeeDateOfJoining { get; set; }
    }
    /// <summary>
    /// Request And Handler for EmployeeManagement Updation
    /// </summary>
    public class UpdateEmployeeHandler : IRequestHandler<UpdateUser, ResultResponse>
    {
        private readonly DataDbContext _dbContext;

        public UpdateEmployeeHandler(DataDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ResultResponse> Handle(UpdateUser request, CancellationToken cancellationToken)
        {
            var result = _dbContext.managementApplications.Where(x => x.EmployeeID==request.EmployeeID).FirstOrDefault();
            ResultResponse Result = new();

            if (result != null)
            {
                result.EmployeeName = request.EmployeeName;
                result.EmployeeEmailId= request.EmployeeEmailId;
                result.EmployeeMobileNumber = request.EmployeeMobileNumber;
                result.EmployeeAddress = request.EmployeeAddress;
                result.EmployeeMaritalStatus = request.EmployeeMaritalStatus;
                result.EmployeeDateOfJoining = request.EmployeeDateOfJoining;
                _dbContext.managementApplications.Update(result);
                _dbContext.SaveChanges();
                Result.id= request.EmployeeID;
                Result.additionalInfo="EmployeeManagementDetails Updated";
                return Result;
            }
            else
            {
                throw new Exception();
            }



        }
    }
}
