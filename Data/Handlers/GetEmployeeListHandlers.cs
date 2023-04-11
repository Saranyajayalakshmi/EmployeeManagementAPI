using EmployeeManagementAPI.Model;
using EmployeeManagementAPI.Services;
using MediatR;

namespace EmployeeManagementAPI.Data.Handlers
{
    public class GetEmployeeListHandlers : IRequestHandler<GetEmployeeListQuery,List<EmployeeManage>>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public GetEmployeeListHandlers(IEmployeeRepository employeeRepository)
        {
            _employeeRepository=employeeRepository;
        }

        public async Task<List<EmployeeManage>> Handle(GetEmployeeListQuery request, CancellationToken cancellationToken)
        {
            return await _employeeRepository.GetEmployeeManagesListAsync();
        }
    }
}
