using EmployeeManagementAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementAPI.Data
{
    public class DataDbContext : DbContext
    {
        public DataDbContext(DbContextOptions<DataDbContext> options) : base(options)
        {
        }
        /// <summary>
        /// DatabaseSet for EmployeeManagementApplication class
        /// </summary>
        public virtual DbSet<EmployeeManagementApplication> managementApplications { get; set; }
    }
}
