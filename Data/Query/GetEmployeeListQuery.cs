using EmployeeManagementAPI.Model;
using MediatR;

namespace EmployeeManagementAPI.Data.Query
{
    /// <summary>
    /// Query Employee List
    /// </summary>
    public class GetEmployeeListQuery : IRequest<List<EmployeeManage>>
    {
    }
}
