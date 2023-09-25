namespace EmployeeManagerDemo
{
    public class Employee
    {
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

        public double CalculateWage()
        {
            return HoursWorked * HourlyRate;
        }

        public override string? ToString()
        {
            return EmployeeId + ": " +
                Name + " - " +
                HoursWorked + " £" +
                HourlyRate;
        }
    }
}
