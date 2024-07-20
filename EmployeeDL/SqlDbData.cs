using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using EmployeeModels;

namespace EmployeeDL
{
    public class SqlDbData
    {
        private string connectionString = "Server=tcp:20.189.120.234,1433;Database=EmployeeDetails;User Id=sa;Password=Salve.bsit21;";

        public SqlDbData()
        {
        }

        // Test Database Connection
        public bool TestConnection()
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    sqlConnection.Open();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Connection test failed: {ex.Message}");
                return false;
            }
        }

        // User Authentication
        public bool ValidateUser(string username, string password)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                string selectStatement = "SELECT COUNT(*) FROM Users WHERE Username = @username AND Password = @password";
                SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection);
                selectCommand.Parameters.AddWithValue("@username", username);
                selectCommand.Parameters.AddWithValue("@password", password);

                sqlConnection.Open();
                int userCount = (int)selectCommand.ExecuteScalar();
                return userCount > 0;
            }
        }

        // Get All Employees
        public List<Employee> GetAllEmployees()
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                string selectStatement = "SELECT EmployeeId, Name, JobTitle, Address, Salary, Age FROM Employees";
                SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection);

                sqlConnection.Open();
                List<Employee> employees = new List<Employee>();
                SqlDataReader reader = selectCommand.ExecuteReader();

                while (reader.Read())
                {
                    Employee employee = new Employee
                    {
                        EmployeeId = (int)reader["EmployeeId"],
                        Name = reader["Name"].ToString(),
                        JobTitle = reader["JobTitle"].ToString(),
                        Address = reader["Address"].ToString(),
                        Salary = (decimal)reader["Salary"],
                        Age = (int)reader["Age"]
                    };

                    employees.Add(employee);
                }

                return employees;
            }
        }

        // Add New Employee
        public void AddNewEmployee(Employee newEmployee)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                string insertStatement = "INSERT INTO Employees (Name, JobTitle, Address, Salary, Age) VALUES (@Name, @JobTitle, @Address, @Salary, @Age)";
                SqlCommand insertCommand = new SqlCommand(insertStatement, sqlConnection);
                insertCommand.Parameters.AddWithValue("@Name", newEmployee.Name);
                insertCommand.Parameters.AddWithValue("@JobTitle", newEmployee.JobTitle);
                insertCommand.Parameters.AddWithValue("@Address", newEmployee.Address);
                insertCommand.Parameters.AddWithValue("@Salary", newEmployee.Salary);
                insertCommand.Parameters.AddWithValue("@Age", newEmployee.Age);

                sqlConnection.Open();
                insertCommand.ExecuteNonQuery();
            }
        }

        // Update Employee
        public void UpdateEmployee(Employee updatedEmployee)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                string updateStatement = "UPDATE Employees SET Name = @Name, JobTitle = @JobTitle, Address = @Address, Salary = @Salary, Age = @Age WHERE EmployeeId = @EmployeeId";
                SqlCommand updateCommand = new SqlCommand(updateStatement, sqlConnection);
                updateCommand.Parameters.AddWithValue("@EmployeeId", updatedEmployee.EmployeeId);
                updateCommand.Parameters.AddWithValue("@Name", updatedEmployee.Name);
                updateCommand.Parameters.AddWithValue("@JobTitle", updatedEmployee.JobTitle);
                updateCommand.Parameters.AddWithValue("@Address", updatedEmployee.Address);
                updateCommand.Parameters.AddWithValue("@Salary", updatedEmployee.Salary);
                updateCommand.Parameters.AddWithValue("@Age", updatedEmployee.Age);

                sqlConnection.Open();
                updateCommand.ExecuteNonQuery();
            }
        }

        // Delete Employee
        public void DeleteEmployee(int employeeId)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                string deleteStatement = "DELETE FROM Employees WHERE EmployeeId = @EmployeeId";
                SqlCommand deleteCommand = new SqlCommand(deleteStatement, sqlConnection);
                deleteCommand.Parameters.AddWithValue("@EmployeeId", employeeId);

                sqlConnection.Open();
                deleteCommand.ExecuteNonQuery();
            }
        }
    }
}
