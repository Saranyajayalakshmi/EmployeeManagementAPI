using EmployeeManagementAPI.Data.Command;
using EmployeeManagementAPI.Model;
using EmployeeManagementAPI.Services;
using MediatR;

namespace EmployeeManagementAPI.Data.Handlers
{
    public class CreateEmployeeHandler : IRequestHandler<CreateEmployee, ResultResponse>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public CreateEmployeeHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository=employeeRepository;
        }

        public async Task<ResultResponse> Handle(CreateEmployee request, CancellationToken cancellationToken)
        {
            ResultResponse result = new ResultResponse();

            try
            {
                EmployeeManage empMan = new EmployeeManage
                {
                    FirstName = request.FirstName,
                    Email= request.EMail,
                    Phone = request.Phone,
                    Address = request.Address,
                    Maritalstatus= request.Marritalstatus,
                    DOJ= request.DOJ,
                };
                var resultdata = await _employeeRepository.AddEmployeeAsync(empMan);
                if (resultdata!=null)
                {
                    result.id=resultdata.Id;
                }
                else
                    result.additionalInfo="Employee Details Added";
                return result;
            }
            catch (Exception ex)
            {

            }
            return result;
        }
    }
}
