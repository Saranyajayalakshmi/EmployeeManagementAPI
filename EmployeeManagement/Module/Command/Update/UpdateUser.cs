using EmployeeManagementAPI.Model;
using MediatR;
using static EmployeeManagementAPI.ExceptionHandling.ExceptionModel;

namespace EmployeeManagementAPI.Data.Command.Update
{
    /// <summary>
    /// Update user
    /// </summary>
    public class UpdateUser : IRequest<ResultResponse>
    {
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


        // Database connection for UpdateEmployee

        public UpdateEmployeeHandler(DataDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        //It occures changes in the EmployeeDetails 
        public Task<ResultResponse> Handle(UpdateUser request, CancellationToken cancellationToken)
        {
            ResultResponse Result = new();

            // checks with EmployeeId

            var result = _dbContext.managementApplications.Where(x => x.EmployeeID==request.EmployeeID).FirstOrDefault();

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

                Result.ResponseValue= request.EmployeeID;
                Result.additionalInfo="EmployeeDetails Updated";
                return Task.FromResult(Result);
            }
            else
            {
                throw new EmployeeNotFoundException();
            }
        }
    }
}
