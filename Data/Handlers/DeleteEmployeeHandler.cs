using EmployeeManagementAPI.Data.Command;
using EmployeeManagementAPI.Services;
using MediatR;

namespace EmployeeManagementAPI.Data.Handlers
{
    public class DeleteEmployeeHandler : IRequestHandler<DeleteEmployee, int>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public DeleteEmployeeHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository=employeeRepository;
        }

        public async Task<int> Handle(DeleteEmployee request, CancellationToken cancellationToken)
        {
            var emp = await _employeeRepository.GetEmployeeManageByIdAsync(request.Id);
            if (emp == null) return default;
            return await _employeeRepository.DeleteEmployeeAsync(request.Id);
                 }
    }
}
