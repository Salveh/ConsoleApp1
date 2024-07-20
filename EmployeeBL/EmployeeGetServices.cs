using System;
using EmployeeDL;
using EmployeeModels;
using System.Collections.Generic;

namespace EmployeeBL
{
    public class EmployeeGetServices
    {
        private SqlDbData sqlData = new SqlDbData();

   
        public bool TestConnection()
        {
            return sqlData.TestConnection();
        }

        
        public List<Employee> GetAllEmployees()
        {
            return sqlData.GetAllEmployees();
        }

        
        public void AddNewEmployee(Employee newEmployee)
        {
            sqlData.AddNewEmployee(newEmployee);
        }

       
        public void UpdateEmployee(Employee updatedEmployee)
        {
            sqlData.UpdateEmployee(updatedEmployee);
        }

        
        public void DeleteEmployee(int employeeId)
        {
            sqlData.DeleteEmployee(employeeId);
        }

        public bool ValidateUser(string username, string password)
        {
            return sqlData.ValidateUser(username, password);
        }
    }
}
