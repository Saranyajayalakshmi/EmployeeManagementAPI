using EmployeeManagementAPI.Model;
using MediatR;
using static EmployeeManagementAPI.ExceptionHandling.ExceptionModel;

namespace EmployeeManagementAPI.Data.Command.Delete
{

    // DeleteUser by EmployeeId

    public class DeleteUser : IRequest<ResultResponse>
    {
        public int EmployeeId { get; set; }
    }

    
    // Delete Request & Handler
  

    public class DeleteEmployeeHandler : IRequestHandler<DeleteUser, ResultResponse>
    {
        private readonly DataDbContext _dbContext;
        

        public DeleteEmployeeHandler(DataDbContext dataContext)
        {
            _dbContext = dataContext;
            
        }
        
        // Delete EmployeeDetails by EmployeeId
        
        public async Task<ResultResponse> Handle(DeleteUser request, CancellationToken cancellationToken)
        {
            ResultResponse Entity = new ResultResponse();

            var result = _dbContext.managementApplications.Where(x => x.EmployeeID==request.EmployeeId).FirstOrDefault();
                           
                // Returns Additionalinfo and ResponseValue
                if (result != null)
                {
                    _dbContext.managementApplications.Remove(result);
                    var value = await _dbContext.SaveChangesAsync();
                    Entity.ResponseValue=value;
                    Entity.additionalInfo="1 Row Affected";
                    return Entity;
                }
                else
                { 
                     throw new EmployeeBadRequestException();
                }
            
        }
    }
}
