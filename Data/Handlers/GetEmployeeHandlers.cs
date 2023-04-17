using EmployeeManagementAPI.Data.Query;
using EmployeeManagementAPI.Model;

using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementAPI.Data.Handlers
{
    /// <summary>
    /// Getting EmployeeManagement Details by EmployeeId
    /// </summary>

    public class GetEmployeeHandlers : IRequestHandler<GetEmployeeByIdQuery, EmployeeManagementApplication>
    {
        private readonly DataDbContext _dbContext;
        /// <summary>
        /// DataBaseConnection for EmployeeHandlers
        /// </summary>
        /// <param name="dbContext"></param>
       
        public GetEmployeeHandlers(DataDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Request Handling Process by EmployeeManageId
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
      
        //EmployeeDetails by using EmployeeID
        public async Task<EmployeeManagementApplication> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
        {
            var EmployeeIdresult = await _dbContext.managementApplications.Where(x => x.EmployeeID==request.Id).FirstOrDefaultAsync();
            return EmployeeIdresult; 
        }
    }
}

