using EmployeeManagementAPI.Data.Command;
using EmployeeManagementAPI.ExceptionHandling;
using EmployeeManagementAPI.Model;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Numerics;
using static EmployeeManagementAPI.ExceptionHandling.UpdateException;

namespace EmployeeManagementAPI.Data.Command.Create
{
    /// <summary>
    /// Creating Request For CreateUser
    /// </summary>
    public class CreateUser : IRequest<ResultResponse>
    {
        /// <summary>
        /// Adding Employee Record List
        /// </summary>
        /// <param name="employeeName"></param>
        /// <param name="employeeEmailId"></param>
        /// <param name="employeeMobileNumber"></param>
        /// <param name="employeeAddress"></param>
        /// <param name="employeeMaritalStatus"></param>
        /// <param name="employeeDateOfJoining"></param>
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


    public class CreateEmployeeHandler : IRequestHandler<CreateUser, ResultResponse>
    {
        private readonly DataDbContext _dbContext;

        public CreateEmployeeHandler(DataDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        /// <summary>
        /// Handle the request and Add the EmployeeDetails
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>Add the EmployeeDetails in tables</returns>
        /// <exception cref="ArgumentException"></exception>

        public async Task<ResultResponse> Handle(CreateUser request, CancellationToken cancellationToken)
        {
            ResultResponse result = new ResultResponse();

            try
            {
                var EmployeeDetails = new EmployeeManagementApplication();

                //assignining values to Employeetables using LINQ

                IList<EmployeeManagementApplication> Items = new List<EmployeeManagementApplication>();

                var query = from s in _dbContext.managementApplications select s; //stores data in s
                var listdata = query.ToList();

                // list the Data
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
                        result.additionalInfo = "Added";
                    }
                    return result;
                }

            }
            catch (Exception ex) // throws an error
            {
                throw new EmployeeNotFoundException();
                //result.additionalInfo="Failed To Added";
            }
            return result;


        }

    }
}
