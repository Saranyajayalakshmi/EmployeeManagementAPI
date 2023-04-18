using EmployeeManagementAPI.Data.Query;
using EmployeeManagementAPI.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementAPI.Data.Handlers
{
    /// <summary>
    /// EmployeeManagementListHandlers
    /// </summary>
    public class GetEmployeeListHandlers : IRequestHandler<GetEmployeeListQuery,List<EmployeeManagementApplication>>
    {

        private readonly DataDbContext _dbContext;

       /// <summary>
       /// DataBaseConnection for Handlers Process
       /// </summary>
       /// <param name="dbContext"></param>

        public GetEmployeeListHandlers(DataDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        /// <summary>
        /// Requesting Handle Process By Employee list
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>


        public async Task<List<EmployeeManagementApplication>> Handle(GetEmployeeListQuery request, CancellationToken cancellationToken)
        {
            var emp = await _dbContext.managementApplications.ToListAsync();//To Show List Of EmployeeDetails
            return emp;
        }
    }
}
