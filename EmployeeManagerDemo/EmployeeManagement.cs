namespace EmployeeManagerDemo
{
    public class EmployeeManagement
    {
        private readonly IInputOutput inputOutput;
        private Company company { get; set; }

       public EmployeeManagement(IInputOutput inputOutput,Company company) {
            this.inputOutput = inputOutput;
            this.company = company;
        }

        public void AddEmployee()
        {
            var employee = new Employee();
            inputOutput.WriteOutput("Enter the employee details ->");
            employee.Name = GetEmployeeName();
            employee.EmployeeId = GetEmployeeId();
            employee.HoursWorked = GetHoursWorked();
            employee.HourlyRate = 9.5;
            if (company.AddEmployee(employee))
            {
                inputOutput.WriteOutput("Employee added successfully.");
            }
            else
            {
                inputOutput.WriteOutput("Employee NOT added - dupicate id?");
            }

        }

        public void ListEmployees()
        {
            inputOutput.WriteOutput("List of Employees:");
            var employees = company.GetAllEmployees();
            if (employees.Count > 0)
            {
                foreach (var person in employees)
                {

                    inputOutput.WriteOutput(person.ToString());
                    var wage = Wage.CalculateWage(HoursWorked: person.HoursWorked, HourlyRate: person.HourlyRate);
                    inputOutput.WriteOutput($"Their weekly wage is £{wage:F2}");

                }
            }
            else
            {
                inputOutput.WriteOutput("is Zero");
            }
        }

        public void RemoveEmployee()
        {
            inputOutput.WriteOutput("Enter the id of the employee to remove: ");
            var employee = company.GetEmployeeById(GetEmployeeId());
            if (employee != null)
            {
                company.RemoveEmployee(employee);
            }
            else
            {
                inputOutput.WriteOutput("Employee does not exist");
            }


        }

        private double GetHoursWorked()
        {
            while (true)
            {
                string hours = inputOutput.ReadInput("Hours Worked: ");
                bool valid = double.TryParse(hours, out double hoursWorked);
                if (valid && hoursWorked > 0 && hoursWorked <= 100)
                {
                    return hoursWorked;
                }
                else
                {
                    inputOutput.WriteOutput("Invalid input for Hours Worked between 1 and 100 hours");
                }
            }
        }

        private string GetEmployeeName()
        {
            while (true)
            {
                string employeeName = inputOutput.ReadInput("Enter Employee Name: ");

                if (Employee.IsNameValid(employeeName))
                {
                    return employeeName;

                }
                else
                {
                    inputOutput.WriteOutput("Please provide a Valid Name");
                }
            }
        }

        private string GetEmployeeId()
        {
            while (true)
            {
                string employeeId = inputOutput.ReadInput("Enter Employee Id (a letter followed by two digits): ");
                bool isValid = Employee.IdIsValid(employeeId);

                if (isValid)
                {
                    return employeeId;
                }
                else
                {
                    inputOutput.WriteOutput("Employee Id does not match the pattern (a letter followed by two digits).");
                }
            }
        }

    }
}