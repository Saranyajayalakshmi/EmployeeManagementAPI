using EmployeeManagementAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementAPI.Data
{
    public class DataDbContext : DbContext
    {
        public DataDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<EmployeeManage> EmployeeManages { get; set; }
    }
}
