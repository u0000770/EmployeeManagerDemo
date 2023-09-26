using System.Text.RegularExpressions;

namespace EmployeeManagerDemo
{
    public class Employee /*: Wage*/
    {
        public Employee() { }

        public Employee(string employeeId, 
            string name, 
            double hoursWorked, 
            double hourlyRate = 9.5)
        {
            EmployeeId = employeeId;
            Name = name;
            HoursWorked = hoursWorked;
            HourlyRate = hourlyRate;
        }

        public string EmployeeId { get; set; }

        public string Name { get; set; }

        public double HoursWorked { get; set; }

        public double HourlyRate { get; set; }

        public static bool IsNameValid(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return false;
            }

            int nameLength = name.Length;

            if (nameLength >= 1 && nameLength <= 50)
            {
                // Name length is within the valid range (1 to 50 characters).
                return true;
            }
            else
            {
                // Name length is outside the valid range.
                return false;
            }
            }

        public override string? ToString()
        {
            return EmployeeId + ": " +
                Name + " - " +
                HoursWorked + " £" +
                HourlyRate;
        }

        public  static bool IdIsValid(string employeeId)
        {
            string pattern = @"^[A-Za-z][0-9]{2}$";

            if (Regex.IsMatch(employeeId, pattern))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
