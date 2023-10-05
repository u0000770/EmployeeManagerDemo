using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagerDemo
{
    public class myApp 
    {
        private readonly IInputOutput inputOutput;
        private Company company;

        public myApp(IInputOutput inputOutput)
        {
            this.inputOutput = inputOutput; 
            this.company = new Company();
        }

        public void Execute()
        {
            EmployeeManagement employeeManagement = new EmployeeManagement(inputOutput,company);
            while (true)
            {
                inputOutput.WriteOutput("Employee Management System");
                inputOutput.WriteOutput("1. Add Employee");
                inputOutput.WriteOutput("2. List Employees");
                inputOutput.WriteOutput("3. Remove Employee");
                inputOutput.WriteOutput("4. Exit");
                inputOutput.WriteOutput("Enter your choice: ");

                string choice = inputOutput.ReadInput("");

                switch (choice)
                {
                    case "1":
                        employeeManagement.AddEmployee();
                        break;
                    case "2":
                        employeeManagement.ListEmployees();
                        break;
                    case "3":
                        employeeManagement.RemoveEmployee();
                        break;
                    case "4":
                        Environment.Exit(0);
                        break;
                    default:
                        inputOutput.WriteOutput("Invalid choice. Please try again.");
                        break;
                }

                inputOutput.WriteOutput(""); // Add a blank line for readability
            }
        }


    }
}
