using EmployeeManagementAPI.Model;
using EmployeeManagementAPI.Services;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementAPI.Data.Command.Update
{
    public class UpdateEmployee : IRequest<int>
    {
        public UpdateEmployee(int id, string firstName, string eMail, string phone, string address, string marritalstatus, DateTime dOJ)
        {
            Id = id;
            FirstName = firstName;
            Email = eMail;
            Phone = phone;
            Address = address;
            Marritalstatus = marritalstatus;
            DOJ = dOJ;
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string Phone { get; set; }

        public string Address { get; set; }
        public string Marritalstatus { get; set; }
        public DateTime DOJ { get; set; }
    }
    public class UpdateEmployeeHandler : IRequestHandler<UpdateEmployee, int>
    {
        private readonly DataDbContext _dbContext;

        public UpdateEmployeeHandler(DataDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Handle(UpdateEmployee request, CancellationToken cancellationToken)
        {
            var result = _dbContext.EmployeeManages.Where(x => x.Id==request.Id).FirstOrDefault();
            

            if (result != null)
            {
                result.FirstName = request.FirstName;
                result.Email = request.Email;
                result.Phone = request.Phone;
                result.Address = request.Address;
                result.MarritalStatus = request.Marritalstatus;
                result.DOJ = request.DOJ;
                _dbContext.EmployeeManages.Update(result);
                _dbContext.SaveChanges();
                return result.Id;
            }
            else
            {
                throw new Exception();
            }

            

        }
    }
}
