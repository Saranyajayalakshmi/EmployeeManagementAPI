using EmployeeManagementAPI.Data.Query;
using EmployeeManagementAPI.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;
using static EmployeeManagementAPI.ExceptionHandling.ExceptionModel;

namespace EmployeeManagementAPI.Data.Handlers
{
    /// <summary>
    /// EmployeeManagementListHandlers
    /// </summary>
    public class GetEmployeeByList : IRequestHandler<GetEmployeeListQuery,List<EmployeeManagementApplication>>
    {

        private readonly DataDbContext _dbContext;

       /// <summary>
       /// DataBaseConnection for Handlers Process
       /// </summary>
       /// <param name="dbContext"></param>

        public GetEmployeeByList(DataDbContext dbContext)
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
            if (emp.Count != 0)
            {
                return emp;
            }
            else if(emp.Count == 0) 
            {
                throw new EmployeeBadRequestException();

            }
            else
            {
                throw new Exception();
            }
        }
    }
}
