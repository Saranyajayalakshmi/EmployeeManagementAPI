using EmployeeManagementAPI.Model;
using MediatR;

namespace EmployeeManagementAPI.Data.Query
{
    /// <summary>
    /// Query Process By Using EmployeeId
    /// </summary>
    public class GetEmployeeByIdQuery : IRequest<EmployeeManagementApplication>
    {
        public int Id { get; set; }//Id Property
    }



}
