using EmployeeManagementAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementAPI.Data
{
    public class DataDbContext : DbContext
    {
        public DataDbContext(DbContextOptions options) : base(options)
        {
        }
        /// <summary>
        /// DatabaseSet for EmployeeManage class
        /// </summary>
        public DbSet<EmployeeManage> EmployeeManages { get; set; }
    }
}
