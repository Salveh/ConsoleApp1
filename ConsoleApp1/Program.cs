using System;
using EmployeeBL;
using EmployeeModels;

namespace EmployeeUI
{
    class Program
    {
        static void Main(string[] args)
        {
            EmployeeGetServices getServices = new EmployeeGetServices();

            // Test the database connection
            if (!getServices.TestConnection())
            {
                Console.WriteLine("Failed to connect to the database.");
                return;
            }

            Console.Write("Enter username: ");
            string username = Console.ReadLine();

            Console.Write("Enter password: ");
            string password = Console.ReadLine();

            if (getServices.ValidateUser(username, password))
            {
                Console.WriteLine("Employee Information System:");
                var employeeList = getServices.GetAllEmployees();

                // Display Employees
                Console.WriteLine("Employee List:");
                foreach (var employee in employeeList)
                {
                    Console.WriteLine($"ID: {employee.EmployeeId}, Name: {employee.Name}, Job Title: {employee.JobTitle}, Address: {employee.Address}, Salary: {employee.Salary}, Age: {employee.Age}");
                }

                while (true)
                {
                    Console.WriteLine("Options:");
                    Console.WriteLine("1. Add New Employee");
                    Console.WriteLine("2. Update Employee Details");
                    Console.WriteLine("3. Delete Employee");
                    Console.WriteLine("4. Exit");
                    Console.Write("Choose an option: ");
                    string option = Console.ReadLine();

                    switch (option)
                    {
                        case "1":
                            // Add New Employee
                            Console.Write("Enter Name: ");
                            string name = Console.ReadLine();
                            Console.Write("Enter Job Title: ");
                            string jobTitle = Console.ReadLine();
                            Console.Write("Enter Address: ");
                            string address = Console.ReadLine();
                            Console.Write("Enter Salary: ");
                            decimal salary = decimal.Parse(Console.ReadLine());
                            Console.Write("Enter Age: ");
                            int age = int.Parse(Console.ReadLine());

                            Employee newEmployee = new Employee
                            {
                                Name = name,
                                JobTitle = jobTitle,
                                Address = address,
                                Salary = salary,
                                Age = age
                            };

                            getServices.AddNewEmployee(newEmployee);
                            Console.WriteLine("Employee added successfully.");
                            break;

                        case "2":
                            // Update Employee Details
                            Console.Write("Enter Employee ID to update: ");
                            int employeeIdToUpdate = int.Parse(Console.ReadLine());
                            var employeeToUpdate = getServices.GetAllEmployees().Find(e => e.EmployeeId == employeeIdToUpdate);

                            if (employeeToUpdate != null)
                            {
                                Console.Write($"Enter new Name (current: {employeeToUpdate.Name}): ");
                                employeeToUpdate.Name = Console.ReadLine();
                                Console.Write($"Enter new Job Title (current: {employeeToUpdate.JobTitle}): ");
                                employeeToUpdate.JobTitle = Console.ReadLine();
                                Console.Write($"Enter new Address (current: {employeeToUpdate.Address}): ");
                                employeeToUpdate.Address = Console.ReadLine();
                                Console.Write($"Enter new Salary (current: {employeeToUpdate.Salary}): ");
                                employeeToUpdate.Salary = decimal.Parse(Console.ReadLine());
                                Console.Write($"Enter new Age (current: {employeeToUpdate.Age}): ");
                                employeeToUpdate.Age = int.Parse(Console.ReadLine());

                                getServices.UpdateEmployee(employeeToUpdate);
                                Console.WriteLine("Employee updated successfully.");
                            }
                            else
                            {
                                Console.WriteLine("Employee not found.");
                            }
                            break;

                        case "3":
                            // Delete Employee
                            Console.Write("Enter Employee ID to delete: ");
                            int employeeIdToDelete = int.Parse(Console.ReadLine());
                            getServices.DeleteEmployee(employeeIdToDelete);
                            Console.WriteLine("Employee deleted successfully.");
                            break;

                        case "4":
                            return;

                        default:
                            Console.WriteLine("Invalid option. Please try again.");
                            break;
                    }

                    // Refresh Employee List
                    employeeList = getServices.GetAllEmployees();
                    Console.WriteLine("Updated Employee List:");

                    foreach (var employee in employeeList)
                    {
                        Console.WriteLine($"ID: {employee.EmployeeId}, Name: {employee.Name}, Job Title: {employee.JobTitle}, Address: {employee.Address}, Salary: {employee.Salary}, Age: {employee.Age}");
                    }
                }
            }
            else
            {
                Console.WriteLine("Invalid username or password.");
            }
        }
    }
}
