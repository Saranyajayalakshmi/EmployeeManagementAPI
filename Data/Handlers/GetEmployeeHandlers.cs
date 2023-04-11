using EmployeeManagementAPI.Model;
using EmployeeManagementAPI.Services;
using MediatR;

namespace EmployeeManagementAPI.Data.Handlers
{
    public class GetEmployeeHandlers : IRequestHandler<GetEmployeeByIdQuery, EmployeeManage>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public GetEmployeeHandlers(IEmployeeRepository employeeRepository)
        {
            _employeeRepository=employeeRepository;
        }

        //public async Task<int> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
        //{
        //    return await _employeeRepository.GetEmployeeManageByIdAsync(request.Id);
        //}

        public async Task<EmployeeManage> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
        {
            return await _employeeRepository.GetEmployeeManageByIdAsync(request.Id);
        }
    }
}

