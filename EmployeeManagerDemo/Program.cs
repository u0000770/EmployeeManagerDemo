using EmployeeManagerDemo;
using System.Text.RegularExpressions;

Company company = new Company();

#region Main
while (true)
{
    SendToOutput("Employee Management System");
    SendToOutput("1. Add Employee");
    SendToOutput("2. List Employees");
    SendToOutput("3. Remove Employee");
    SendToOutput("4. Exit");
    SendToOutput("Enter your choice: ");

    string choice = GetUserInput("");

    switch (choice)
    {
        case "1":
            AddEmployee();
            break;
        case "2":
            ListEmployees();
            break;
        case "3":
            RemoveEmployee();
            break;
        case "4":
            Environment.Exit(0);
            break;
        default:
            Console.WriteLine("Invalid choice. Please try again.");
            break;
    }

    Console.WriteLine(); // Add a blank line for readability
}

#endregion

#region Employee Management 

void AddEmployee()
{
    var employee = new Employee();
    SendToOutput("Enter the employee details ->");
    employee.Name = GetEmployeeName();
    employee.EmployeeId = GetEmployeeId();
    employee.HoursWorked = GetHoursWorked();
    employee.HourlyRate = 9.5;
    if (company.AddEmployee(employee))
    { 
        SendToOutput("Employee added successfully."); 
    }
    else
    {
        SendToOutput("Employee NOT added - dupicate id?");
    }
    
}

void ListEmployees()
{
    SendToOutput("List of Employees:");
    var employees = company.GetAllEmployees();
    if (employees.Count > 0)
    { 
        foreach (var person in employees)
        {
            SendToOutput($"{person.EmployeeId} - {person.Name}");
            var wage = Wage.CalculateWage(HoursWorked: person.HoursWorked, HourlyRate: person.HourlyRate);
            SendToOutput($"The weekly wage is £{wage:F2}");
        }
    }
    else
    {
        SendToOutput("is Zero");
    }
}

void RemoveEmployee()
{
    SendToOutput("Enter the id of the employee to remove: ");
    var employee = company.GetEmployeeById(GetEmployeeId());
    if (employee != null) {
        company.RemoveEmployee(employee);
    }
    else {
        SendToOutput("Employee does not exist");
    }
    

}
#endregion

#region Employee Creation
double GetHoursWorked()
{
    while (true)
    {
        var hours = GetUserInput("Hours Worked: ");
        var valid = double.TryParse(hours, out double hoursWorked);
        if (valid && (hoursWorked >0 && hoursWorked <= 100))
        {
            
            return hoursWorked;
        }
        else
        {
            SendToOutput("Invalid input for Hours Worked between 1 and 100 hours");
        }
    }
}

string GetEmployeeName()
{
    while (true)
    {
        string employeeName = GetUserInput("Enter Employee Name: ");

        if (Employee.IsNameValid(employeeName))
        {
            return employeeName;
            
        }
        else
        {
            SendToOutput("Please provide a Valid Name");
        }
    }
}

string GetEmployeeId()
{
    while (true)
    {
        string employeeId = GetUserInput("Enter Employee Id (a letter followed by two digits): ");
        bool isValid = Employee.IdIsValid(employeeId);
      
        if (isValid)
        {
            return employeeId;
        }
        else
        {
            SendToOutput("Employee Id does not match the pattern (a letter followed by two digits).");
        }
    }
}

#endregion

#region Basic IO
string GetUserInput(string prompt)
{
    Console.Write(prompt);
    return Console.ReadLine();
}
void SendToOutput(string prompt)
{
    Console.WriteLine(prompt);
}
#endregion