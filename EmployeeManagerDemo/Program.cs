using EmployeeManagerDemo;
using System.Text.RegularExpressions;

Console.WriteLine("Hello, Let is Create an Employee");

string employeeName = GetEmployeeName();

string employeeId = GetEmployeeId();

double hoursWorked = GetHoursWorked();

Employee employee = new Employee(employeeId, employeeName, hoursWorked);

double weeklyWage = employee.CalculateWage();

Console.WriteLine($"{employee.EmployeeId} \n {employee.Name}");
Console.WriteLine($"The weekly wage is £{weeklyWage:F2}");

double GetHoursWorked()
{
    while (true)
    {
        var hours = GetUserInput("Hours Worked: ");
        var valid = double.TryParse(hours, out double hoursWorked);
        if (valid)
        {
            //double hourlyRate = 9.50; // Example hourly rate, change to your actual rate
            //double weeklyWage = hoursWorked * hourlyRate;

            //Console.WriteLine($"The weekly wage is £{weeklyWage:F2}");
            return hoursWorked;
        }
        else
        {
            Console.WriteLine("Invalid input for Hours Worked.");
        }
    }
}

string GetEmployeeName()
{
    while (true)
    {
        string employeeName = GetUserInput("Enter Employee Name: ");

        if (string.IsNullOrEmpty(employeeName))
        {
            Console.WriteLine("Please provide a Valid Name");
        }
        else
        {
            return employeeName;
        }
    }
}

string GetEmployeeId()
{
    while (true)
    {
        string employeeId = GetUserInput("Enter Employee Id (a letter followed by two digits): ");
        string pattern = @"^[A-Za-z][0-9]{2}$";

        if (Regex.IsMatch(employeeId, pattern))
        {
            return employeeId;
        }
        else
        {
            Console.WriteLine("Employee Id does not match the pattern (a letter followed by two digits).");
        }
    }
}

string GetUserInput(string prompt)
{
    Console.Write(prompt);
    return Console.ReadLine();
}

//static double CalcWage(double hoursWorked)
//{
//    double hourlyRate = 9.50; // Example hourly rate, change to your actual rate
//    double weeklyWage = hoursWorked * hourlyRate;
//    return weeklyWage;
//}



//Employee employee = new Employee("D65", "James", 10.0); // no rate?
//Console.WriteLine(employee);
//Console.WriteLine("Wage is £" + employee.CalculateWage() + "\n");

//Employee employee2 = new Employee("D88", "Barry", 15.0, 13.45); // no rate?
//Console.WriteLine(employee2);
//Console.WriteLine("Wage is £" + employee2.CalculateWage() + "\n");


//string myInput = Console.ReadLine();
//try
//{
//    int myInt = Convert.ToInt32(myInput);
//    Console.WriteLine("print myInt " + myInt);
//}
//catch (Exception ex)
//{
//    Console.WriteLine("A number you fool!");
//}

//int length = "Some String".Length;