using EmployeeManagementAPI.Controllers;
using EmployeeManagementAPI.Model;
using MediatR;

namespace EmployeeManagementAPI.Data.Command
{
    public class DeleteEmployee :IRequest<int>
    {
        public int Id { get; set; }
    }
}
