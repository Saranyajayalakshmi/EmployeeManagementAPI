using Azure.Messaging;
using EmployeeManagementAPI.Data.Command;
using EmployeeManagementAPI.Model;
using EmployeeManagementAPI.Services;
using MediatR;

namespace EmployeeManagementAPI.Data.Handlers
{
    public class UpdateEmployeeHandler : IRequestHandler<UpdateEmployee, int>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public UpdateEmployeeHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository=employeeRepository;
        }

        public async Task<int> Handle(UpdateEmployee request, CancellationToken cancellationToken)
        {
            var result = await _employeeRepository.GetEmployeeManageByIdAsync(request.Id);
            if (result == null) return default;
            {
                result.FirstName = request.FirstName;
                result.Email   = request.EMail;
                result.Phone = request.Phone;
                result.Address = request.Address;
                result.Maritalstatus = request.Marritalstatus;
                result.DOJ = request.DOJ;
                return await _employeeRepository.UpdateEmployeeAsync(result);
            }
           
            
        }
    }
}
