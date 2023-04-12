using EmployeeManagementAPI.Controllers;
using EmployeeManagementAPI.Model;
using EmployeeManagementAPI.Services;
using MediatR;

namespace EmployeeManagementAPI.Data.Command.Delete
{
    public class DeleteEmployee : IRequest<int>
    {
        public int Id { get; set; }
    }
    public class DeleteEmployeeHandler : IRequestHandler<DeleteEmployee, int>
    {
        private readonly DataDbContext _dbContext;

        public DeleteEmployeeHandler(DataDbContext dataContext)
        {
            _dbContext = dataContext;
        }

        public async Task<int> Handle(DeleteEmployee request, CancellationToken cancellationToken)
        {
            var result = _dbContext.EmployeeManages.Where(x => x.Id==request.Id).FirstOrDefault();
            if (result != null) 
            {
                 _dbContext.EmployeeManages.Remove(result);
                await _dbContext.SaveChangesAsync();
            }
            
            return 1;
        }
    }
}
