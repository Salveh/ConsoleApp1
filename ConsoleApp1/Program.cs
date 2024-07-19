using System;
using EmployeeBL;
using EmployeeDL;
using EmployeeModels;

namespace EmployeeUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Employee Management System");

            string name;
            string id;

            do
            {
                Console.WriteLine("\nPlease enter your employee name:");
                name = Console.ReadLine();

                Console.WriteLine("Please enter your employee ID:");
                id = Console.ReadLine();
            } while (!ValidateCredentials(name, id));

            EmployeeService employeeService = new EmployeeService(new EmployeeDataService());
            Employee employee = employeeService.GetEmployee(name, id);

            if (employee != null)
            {
                DisplayEmployeeInfo(employee);
            }
            else
            {
                Console.WriteLine("\nInvalid employee credentials.");
            }
        }

        static bool ValidateCredentials(string name, string id)
        {
            return name.Equals("SALVE", StringComparison.OrdinalIgnoreCase) && id.Equals("salve001", StringComparison.OrdinalIgnoreCase);
        }

        static void DisplayEmployeeInfo(Employee employee)
        {
            Console.WriteLine("\nEmployee Information:");
            Console.WriteLine($"Name: {employee.Name}");
            Console.WriteLine($"ID Number: {employee.IdNumber}");
            Console.WriteLine($"Job Title: {employee.JobTitle}");
            Console.WriteLine($"Address: {employee.Address}");
            Console.WriteLine($"Salary: {employee.Salary:C2}");
            Console.WriteLine($"Age: {employee.Age}");
            
            
        }
    }
}
