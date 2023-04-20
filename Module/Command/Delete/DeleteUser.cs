using EmployeeManagementAPI.Model;
using MediatR;
using static EmployeeManagementAPI.ExceptionHandling.ExceptionModel;

namespace EmployeeManagementAPI.Data.Command.Delete
{

    // DeleteUser by EmployeeId

    public class DeleteUser : IRequest<ResultValue>
    {
        public int EmployeeId { get; set; }
    }

    
    // Delete Request & Handler
  

    public class DeleteEmployeeHandler : IRequestHandler<DeleteUser, ResultValue>
    {
        private readonly DataDbContext _dbContext;
        

        public DeleteEmployeeHandler(DataDbContext dataContext)
        {
            _dbContext = dataContext;
            
        }
        
        // Delete EmployeeDetails by EmployeeId
        
        public async Task<ResultValue> Handle(DeleteUser request, CancellationToken cancellationToken)
        {
            ResultValue Entity = new();

            var result = _dbContext.managementApplications.Where(x => x.EmployeeID==request.EmployeeId).FirstOrDefault();
           
                

                // If EmployeeId is Invalid returns null
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
