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

        public async Task<EmployeeManage> AddEmployeeAsync(EmployeeManage AddEmployee)
        {
            var result= _dbContext.EmployeeManages.Add(AddEmployee);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<int> DeleteEmployeeAsync(int Id)
        {
            var result= _dbContext.EmployeeManages.Where(x=>x.Id==Id).FirstOrDefault();
            _dbContext.EmployeeManages.Remove(result);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<EmployeeManage> GetEmployeeManageByIdAsync(int Id)
        {
            var EmployeeId = await _dbContext.EmployeeManages.Where(x=>x.Id==Id).FirstOrDefaultAsync();
            return  EmployeeId;
        }

        public async Task<List<EmployeeManage>> GetEmployeeManagesListAsync() 
        {
            var EmployeeList= await _dbContext.EmployeeManages.ToListAsync();
            return  EmployeeList;
        }

        public async Task<int> UpdateEmployeeAsync(EmployeeManage updateEmployee)
        {
            _dbContext.EmployeeManages.Update(updateEmployee);
            return await _dbContext.SaveChangesAsync();
        }
    }
}
