using EmployeeManagementAPI.Model;
using MediatR;

namespace EmployeeManagementAPI.Data
{
    public class GetEmployeeByIdQuery:IRequest<EmployeeManage>
    {
        public int Id { get;set; }
    }


}
