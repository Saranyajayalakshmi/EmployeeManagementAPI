using EmployeeManagementAPI.Data.Command;
using EmployeeManagementAPI.Model;

using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Numerics;

namespace EmployeeManagementAPI.Data.Command.Create
{
    /// <summary>
    /// Creating Request For CreateUser
    /// </summary>
    public class CreateUser : IRequest<ResultResponse>
    {
        public CreateUser(string employeeName, string employeeEmailId, string employeeMobileNumber, string employeeAddress, string employeeMaritalStatus, DateTime employeeDateOfJoining)
        {

            EmployeeName=employeeName;
            EmployeeEmailId=employeeEmailId;
            EmployeeMobileNumber=employeeMobileNumber;
            EmployeeAddress=employeeAddress;
            EmployeeMaritalStatus=employeeMaritalStatus;
            EmployeeDateOfJoining=employeeDateOfJoining;
        }

        public string EmployeeName { get; set; }
        public string EmployeeEmailId { get; set; }
        public string EmployeeMobileNumber { get; set; }
        public string EmployeeAddress { get; set; }
        public string EmployeeMaritalStatus { get; set; }
        public DateTime EmployeeDateOfJoining { get; set; }
    }

    /// <summary>
    /// CreateUser Handler Process
    /// </summary>


    public class CreateEmployeeHandler : IRequestHandler<CreateUser, ResultResponse>
    {
        private readonly DataDbContext _dbContext;

        public CreateEmployeeHandler(DataDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ResultResponse> Handle(CreateUser request, CancellationToken cancellationToken)
        {
            ResultResponse result = new ResultResponse();

            try
            {
                var EmployeeDetails = new EmployeeManagementApplication();

                //assignining values to Employeetables using LINQ

                IList<EmployeeManagementApplication> Items = new List<EmployeeManagementApplication>();

                var query = from s in _dbContext.managementApplications select s;
                var listdata = query.ToList();

                foreach (var item in listdata)
                {
                    Items.Add(new EmployeeManagementApplication());
                    {

                        EmployeeDetails.EmployeeName = request.EmployeeName;
                        EmployeeDetails.EmployeeEmailId = request.EmployeeEmailId;
                        EmployeeDetails.EmployeeMobileNumber = request.EmployeeMobileNumber;
                        EmployeeDetails.EmployeeAddress = request.EmployeeAddress;
                        EmployeeDetails.EmployeeMaritalStatus = request.EmployeeMaritalStatus;
                        EmployeeDetails.EmployeeDateOfJoining = request.EmployeeDateOfJoining;

                        _dbContext.managementApplications.Add(EmployeeDetails);
                        await _dbContext.SaveChangesAsync();
                    }

                    //Employee Details not null Add table to database

                    if (EmployeeDetails != null)
                    {
                        result.id = EmployeeDetails.EmployeeID;
                        result.additionalInfo = "EmployeeManagement Details Added";
                    }
                    return result;
                }

            }
            catch (Exception)
            {
                throw new ArgumentException("EmployeeDetails Not Added");
                //result.additionalInfo="Failed To Added";
            }
            return result;


        }

    }
}
