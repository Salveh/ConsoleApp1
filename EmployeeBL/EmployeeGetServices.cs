using System;
using EmployeeDL;
using EmployeeModels;
using System.Collections.Generic;

namespace EmployeeBL
{
    public class EmployeeGetServices
    {
        private SqlDbData sqlData = new SqlDbData();

        // Test Database Connection
        public bool TestConnection()
        {
            return sqlData.TestConnection();
        }

        // Get All Employees
        public List<Employee> GetAllEmployees()
        {
            return sqlData.GetAllEmployees();
        }

        // Add New Employee
        public void AddNewEmployee(Employee newEmployee)
        {
            sqlData.AddNewEmployee(newEmployee);
        }

        // Update Employee
        public void UpdateEmployee(Employee updatedEmployee)
        {
            sqlData.UpdateEmployee(updatedEmployee);
        }

        // Delete Employee
        public void DeleteEmployee(int employeeId)
        {
            sqlData.DeleteEmployee(employeeId);
        }

        // Validate User
        public bool ValidateUser(string username, string password)
        {
            return sqlData.ValidateUser(username, password);
        }
    }
}
