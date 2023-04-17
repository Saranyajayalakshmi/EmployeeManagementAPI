using EmployeeManagementAPI.Controllers;
using EmployeeManagementAPI.Model;

using MediatR;

namespace EmployeeManagementAPI.Data.Command.Delete
{
    /// <summary>
    /// DeleteUser by EmployeeId
    /// </summary>
    public class DeleteUser : IRequest<ResultResponse>
    {
        public int EmployeeId { get; set; }
    }

    /// <summary>
    /// Delete Reuest & Handler
    /// </summary>

    public class DeleteEmployeeHandler : IRequestHandler<DeleteUser, ResultResponse>
    {
        private readonly DataDbContext _dbContext;

        public DeleteEmployeeHandler(DataDbContext dataContext)
        {
            _dbContext = dataContext;
        }
        /// <summary>
        /// Delete Employee Details by EmployeeId
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>If EmployeeId is null or not exists returns InvalidId</returns>

        public async Task<ResultResponse> Handle(DeleteUser request, CancellationToken cancellationToken)
        {
            var result = _dbContext.managementApplications.Where(x => x.EmployeeID==request.EmployeeId).FirstOrDefault();
            ResultResponse Entity = new();
            // If EmployeeId is Invalid returns null
            if (result != null)
            {
                _dbContext.managementApplications.Remove(result);
               var value= await _dbContext.SaveChangesAsync();
                Entity.id=value;
                Entity.additionalInfo="1 Row Affected";

                return Entity;
            }
            else
            {
                Entity.id=0;
                Entity.additionalInfo="InvalidEmployeeId";
                return Entity;
            }
        }
    }
}
