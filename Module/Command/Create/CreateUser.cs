using EmployeeManagementAPI.Data.Command;
using EmployeeManagementAPI.ExceptionHandling;
using EmployeeManagementAPI.Model;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Numerics;
using static EmployeeManagementAPI.ExceptionHandling.ExceptionModel;

namespace EmployeeManagementAPI.Data.Command.Create
{
    /// <summary>
    /// Create User
    /// </summary>
    public class CreateUser : IRequest<ResultResponse>
    {        //Properties to Create user
       
        public string EmployeeName { get; set; }
        public string EmployeeEmailId { get; set; }
        public string EmployeeMobileNumber { get; set; }
        public string EmployeeAddress { get; set; }
        public string EmployeeMaritalStatus { get; set; }
        public DateTime EmployeeDateOfJoining { get; set; }
    }


    public class CreateEmployeeHandler : IRequestHandler<CreateUser, ResultResponse>
    {
        DataDbContext _dbContext;


        public CreateEmployeeHandler(DataDbContext dbContext)
        {
            _dbContext = dbContext;

        }


        //Add the EmployeeDetails in tables

        public async Task<ResultResponse> Handle(CreateUser request, CancellationToken cancellationToken)
        {
            ResultResponse result = new ResultResponse();

            var EmployeeDetails = new EmployeeManagementApplication();
            var MobileNumberExists = _dbContext.managementApplications.Where(x => x.EmployeeMobileNumber==request.EmployeeMobileNumber).ToList();
            if (MobileNumberExists.Count>0)
            {
                throw new Exception();
            }

            //assignining values to Employeetables

            EmployeeDetails.EmployeeName = request.EmployeeName;
            EmployeeDetails.EmployeeEmailId = request.EmployeeEmailId;
            EmployeeDetails.EmployeeMobileNumber = request.EmployeeMobileNumber;
            EmployeeDetails.EmployeeAddress = request.EmployeeAddress;
            EmployeeDetails.EmployeeMaritalStatus = request.EmployeeMaritalStatus;
            EmployeeDetails.EmployeeDateOfJoining = request.EmployeeDateOfJoining;

            _dbContext.managementApplications.Add(EmployeeDetails);

            result.ResponseValue=await _dbContext.SaveChangesAsync();
            result.additionalInfo = "Added";



            //Checks ResponseValue 

            if (result.ResponseValue==0)
            {
                throw new EmployeeBadRequestException();
            }
            return result;
        }
    }
}
