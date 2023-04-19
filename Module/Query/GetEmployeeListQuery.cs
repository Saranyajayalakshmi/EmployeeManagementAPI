using EmployeeManagementAPI.Model;
using MediatR;

namespace EmployeeManagementAPI.Data.Query
{
    /// <summary>
    /// Query EmployeeManagement Record
    /// </summary>
    public class GetEmployeeListQuery : IRequest<List<EmployeeManagementApplication>>
    {
    }

}
