namespace EmployeeManagerDemo
{
    public class Wage
    {
        /// <summary>
        /// Calculates the wage based on hours worked and hourly rate.
        /// </summary>
        /// <param name="hoursWorked">The number of hours worked.</param>
        /// <param name="hourlyRate">The hourly rate of pay.</param>
        /// <returns>
        /// The calculated wage that complies with 
        /// HoursWorked Rule
        /// HourlyRate Rate
        /// Otherwise 0
        /// </returns>
        public static double CalculateWage(double HoursWorked,double HourlyRate)
        {
            if (HoursWorkedRule(HoursWorked) && HourlyRateRule(HourlyRate))
            {
                return HoursWorked * HourlyRate;
            }
            else { return 0; }
        }

     

        private static bool HourlyRateRule(double HourlyRate)
        {
            if (HourlyRate > 0)
            { return true; }
            else { return false; }
        }

        public static bool HoursWorkedRule(double HoursWorked)
        {
            if (HoursWorked > 0 && HoursWorked <= 100)
            { return true; }
            else { return false; }
        }
    }
}