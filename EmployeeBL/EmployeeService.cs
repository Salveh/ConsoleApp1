using EmployeeDL;
using EmployeeModels;

namespace EmployeeBL
{
    public class EmployeeService
    {
        private readonly EmployeeDataService _employeeDataService;

        public EmployeeService(EmployeeDataService employeeDataService)
        {
            _employeeDataService = employeeDataService;
        }

        public Employee GetEmployee(string name, string id)
        {
            return _employeeDataService.GetEmployee(name, id);
        }
    }
}
