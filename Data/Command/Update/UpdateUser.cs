using EmployeeManagementAPI.ExceptionHandling;
using EmployeeManagementAPI.Model;

using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;
using System.Net.Http;
using System.Runtime.Intrinsics.X86;
using static EmployeeManagementAPI.ExceptionHandling.UpdateException;

namespace EmployeeManagementAPI.Data.Command.Update
{
    /// <summary>
    ///Creating Updateuser
    /// </summary>
    public class UpdateUser : IRequest<ResultResponse>
    {
        /// <summary>
        /// Update the Employee Records
        /// </summary>
        /// <param name="employeeID"></param>
        /// <param name="employeeName"></param>
        /// <param name="employeeEmailId"></param>
        /// <param name="employeeMobileNumber"></param>
        /// <param name="employeeAddress"></param>
        /// <param name="employeeMaritalStatus"></param>
        /// <param name="employeeDateOfJoining"></param>
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

        /// <summary>
        /// Database connection for UpdateEmployee
        /// </summary>
        /// <param name="dbContext"></param>
        public UpdateEmployeeHandler(DataDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        /// <summary>
        ///Handle the request and update the EmployeeDetails by EmployeeId
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>It occures changes in the EmployeeDetails </returns>
        /// <exception cref="Exception"></exception>
        public async Task<ResultResponse> Handle(UpdateUser request, CancellationToken cancellationToken)
        {
            ResultResponse Result = new();

            try
            {
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
                    Result.id= request.EmployeeID;
                    Result.additionalInfo="EmployeeDetails Updated";
                    return Result;
                }
                else
                {
                    throw new Exception();
                }

            }
            catch (Exception ex)
            {
                throw new EmployeeBadRequestException();
            }




        }
    }
}
