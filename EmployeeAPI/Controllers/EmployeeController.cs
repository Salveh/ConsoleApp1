using EmployeeBL;
using EmployeeModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace EmployeeAPI.Controllers
{
    [ApiController]
    [Route("api/employee")]
    public class EmployeeController : Controller
    {
        private readonly EmployeeGetServices _employeeGetServices;

        public EmployeeController()
        {
            _employeeGetServices = new EmployeeGetServices();
        }

        [HttpGet]
        public IEnumerable<Employee> GetAllEmployees()
        {
            return _employeeGetServices.GetAllEmployees();
        }

        [HttpPost]
        public JsonResult AddNewEmployee(Employee request)
        {
            _employeeGetServices.AddNewEmployee(request);
            return new JsonResult("Employee added successfully.");
        }

        [HttpPatch]
        public JsonResult UpdateEmployee(Employee request)
        {
            _employeeGetServices.UpdateEmployee(request);
            return new JsonResult("Employee updated successfully.");
        }

        [HttpDelete("{id}")]
        public JsonResult DeleteEmployee(int id)
        {
            _employeeGetServices.DeleteEmployee(id);
            return new JsonResult("Employee deleted successfully.");
        }

        [HttpPost("validate")]
        public JsonResult ValidateUser(User request)
        {
            bool isValid = _employeeGetServices.ValidateUser(request.Username, request.Password);
            return new JsonResult(isValid);
        }
    }
}
  