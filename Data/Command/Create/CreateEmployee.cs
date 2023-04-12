using EmployeeManagementAPI.Data.Command;
using EmployeeManagementAPI.Model;
using EmployeeManagementAPI.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Numerics;

namespace EmployeeManagementAPI.Data.Command.Create
{
    public class CreateEmployee : IRequest<ResultResponse>
    { 
    public CreateEmployee(string firstName, string eMail, string phone, string address, string marritalstatus, DateTime dOJ)
    {
        FirstName = firstName;
        Email = eMail;
        Phone = phone;
        Address = address;
        Marritalstatus = marritalstatus;
        DOJ = dOJ;
    }

    public string FirstName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; }
    public string Marritalstatus { get; set; }
    public DateTime DOJ { get; set; }
}
public class CreateEmployeeHandler : IRequestHandler<CreateEmployee, ResultResponse>
    {
        private readonly DataDbContext _dbContext;
        


        public CreateEmployeeHandler( DataDbContext dbContext)
        {
          _dbContext = dbContext;
        }

        public async Task<ResultResponse> Handle(CreateEmployee request, CancellationToken cancellationToken)
        {
            ResultResponse result = new ResultResponse();

            try
            {
                var EmployeeDetails = new EmployeeManage();

                EmployeeDetails.FirstName = request.FirstName;
                EmployeeDetails.Email = request.Email;
                EmployeeDetails.Phone = request.Phone;
                EmployeeDetails.Address = request.Address;
                EmployeeDetails.MarritalStatus = request.Marritalstatus;
                EmployeeDetails.DOJ = request.DOJ;

                _dbContext.EmployeeManages.Add(EmployeeDetails);
                await _dbContext.SaveChangesAsync();
                if (EmployeeDetails != null)
                {
                    result.id = EmployeeDetails.Id;
                    result.additionalInfo = "Employee Details Added";
                }

                return result;
            }
            catch (FormatException)
            {
                result.additionalInfo = "NotFound";
            }
            return result;
        }

    }
}
