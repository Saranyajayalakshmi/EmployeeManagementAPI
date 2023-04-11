using EmployeeManagementAPI.Model;
using MediatR;

namespace EmployeeManagementAPI.Data
{
    public class GetEmployeeListQuery:IRequest<List<EmployeeManage>>
    {
    }
}
