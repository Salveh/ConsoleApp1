using System;
using System.Data.SqlClient;
using EmployeeModels;

namespace EmployeeDL
{
    public class EmployeeDataService
    {
        private string connectionString = "Data Source=LAPTOP-2V85TBH6\\SQLEXPRESS01;Initial Catalog=EmployeeInfo;Integrated Security=True;";

        public Employee GetEmployee(string name, string id)
        {
            Employee employee = null;
            string query = "SELECT * FROM Employee WHERE Name = @Name AND IdNumber = @IdNumber";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@IdNumber", id);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    employee = new Employee
                    {
                        Name = reader["Name"].ToString(),
                        IdNumber = reader["IdNumber"].ToString(),
                        Address = reader["Address"].ToString(),
                        Age = Convert.ToInt32(reader["Age"]),
                        JobTitle = reader["Job_Title"].ToString(),  // Corrected to match 
                        Salary = reader.GetDecimal(reader.GetOrdinal("Salary"))
                    };
                }
            }

            return employee;
        }
    }
}
