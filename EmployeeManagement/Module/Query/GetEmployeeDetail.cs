using EmployeeManagementAPI.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;
using static EmployeeManagementAPI.ExceptionHandling.ExceptionModel;

namespace EmployeeManagementAPI.Data.Handlers
{
    public class GetEmployeeDetail : IRequest<EmployeeManagementApplication>
    {
        public int Id { get; set; }//Id Property
    }
    /// <summary>
    /// Getting EmployeeManagement Details by EmployeeId
    /// </summary>

    public class GetEmployeeById : IRequestHandler<GetEmployeeDetail, EmployeeManagementApplication>
    {
        private readonly DataDbContext _dbContext;

        public GetEmployeeById()
        {
        }

        /// <summary>
        /// DataBaseConnection for EmployeeHandlers
        /// </summary>
        /// <param name="dbContext"></param>

        public GetEmployeeById(DataDbContext dbContext)
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
        public Task<EmployeeManagementApplication> Handle(GetEmployeeDetail request, CancellationToken cancellationToken)
        {
            var EmployeeIdresult = _dbContext.managementApplications.Where(x => x.EmployeeID==request.Id).FirstOrDefaultAsync();
            if (EmployeeIdresult.Result==null)
            {
                throw new IdNotFoundException();
            }
            else
            {
                return EmployeeIdresult;
            }
        }
    }
}

