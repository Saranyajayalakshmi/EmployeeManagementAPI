﻿using EmployeeManagementAPI.Data.Command;
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
    /// Create User
    /// </summary>
    public class CreateUser : IRequest<ResultValue>
    {
        public CreateUser()
        {
        }

        //Properties to Create user
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


    public class CreateEmployeeHandler : IRequestHandler<CreateUser, ResultValue>
    {
         DataDbContext _dbContext;
      

        public CreateEmployeeHandler(DataDbContext dbContext)
        {
            _dbContext = dbContext;
            
        }

        
        //Add the EmployeeDetails in tables

        public async Task<ResultValue> Handle(CreateUser request, CancellationToken cancellationToken)
        {
            ResultValue result = new ResultValue();

            var EmployeeDetails = new EmployeeManagementApplication();

            try 
            {
                     //assignining values to Employeetables

                        EmployeeDetails.EmployeeName = request.EmployeeName;
                        EmployeeDetails.EmployeeEmailId = request.EmployeeEmailId;
                        EmployeeDetails.EmployeeMobileNumber = request.EmployeeMobileNumber;
                        EmployeeDetails.EmployeeAddress = request.EmployeeAddress;
                        EmployeeDetails.EmployeeMaritalStatus = request.EmployeeMaritalStatus;
                        EmployeeDetails.EmployeeDateOfJoining = request.EmployeeDateOfJoining;

                        _dbContext.managementApplications.Add(EmployeeDetails);
                        await _dbContext.SaveChangesAsync();
                   // }

                    //Employee Details not null Add table to database

                    if (EmployeeDetails != null)
                    {
                        result.id = EmployeeDetails.EmployeeID;
                        result.additionalInfo = "Added";
                    return result;
                }
                    
                //}

            }
            catch (Exception) // throws an NotFounferror
            {
                //throw new EmployeeNotFoundException();
                //result.additionalInfo="Failed To Added";
            }
            return result;


        }

    }
}