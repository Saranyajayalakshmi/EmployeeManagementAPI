using EmployeeManagementAPI.Model;
using MediatR;
using static EmployeeManagementAPI.ExceptionHandling.UpdateException;

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
            try
            {
                

                // If EmployeeId is Invalid returns null
                if (result != null)
                {
                    _dbContext.managementApplications.Remove(result);
                    var value = await _dbContext.SaveChangesAsync();
                    Entity.id=value;
                    Entity.additionalInfo="1 Row Affected";
                    return Entity;
                }
                else
                {
                    Entity.additionalInfo="0 Rows Affected";
                    
                    throw new Exception();
                }
            }
            catch(Exception) 
            {
                throw new EmployeeBadRequestException();
            }
        }
    }
}
