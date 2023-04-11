using EmployeeManagementAPI.Data;
using EmployeeManagementAPI.Model;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementAPI.Services
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly DataDbContext  _dbContext;

        public EmployeeRepository(DataDbContext dbContext)
        {
            _dbContext= dbContext;
        }

        public async Task<EmployeeManage> AddEmployeeAsync(EmployeeManage employeeManage)
        {
            var result= _dbContext.EmployeeManages.Add(employeeManage);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<int> DeleteEmployeeAsync(int Id)
        {
            var res= _dbContext.EmployeeManages.Where(x=>x.Id==Id).FirstOrDefault();
            _dbContext.EmployeeManages.Remove(res);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<EmployeeManage> GetEmployeeManageByIdAsync(int Id)
        {
            var data = await _dbContext.EmployeeManages.Where(x=>x.Id==Id).FirstOrDefaultAsync();
            return data;
        }

        public async Task<List<EmployeeManage>> GetEmployeeManagesListAsync() 
        {
            var data= await _dbContext.EmployeeManages.ToListAsync();
            return data;
        }

        public async Task<int> UpdateEmployeeAsync(EmployeeManage employeeManage)
        {
            _dbContext.EmployeeManages.Update(employeeManage);
            return await _dbContext.SaveChangesAsync();
        }
    }
}
