using EmployeeManagementAPI.Data.Query;
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
        /// <summary>
        /// Request Handling Process by EmployeeId
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<EmployeeManage> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
        {
            return await _employeeRepository.GetEmployeeManageByIdAsync(request.Id);
        }
    }
}

