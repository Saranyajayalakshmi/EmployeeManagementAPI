using EmployeeManagementAPI.Model;

namespace EmployeeManagementAPI.Services
{
    public interface IEmployeeRepository
    {
        public Task<List<EmployeeManage>> GetEmployeeManagesListAsync();
        public Task<EmployeeManage> GetEmployeeManageByIdAsync(int Id);
        public Task<EmployeeManage> AddEmployeeAsync(EmployeeManage employeeManage);
        public Task<int> UpdateEmployeeAsync(EmployeeManage employeeManage);
        public Task<int> DeleteEmployeeAsync(int Id);
    }
}
