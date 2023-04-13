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
        /// DatabaseSet for EmployeeManagementApplication class
        /// </summary>
        public DbSet<EmployeeManagementApplication> managementApplications { get; set; }
    }
}
