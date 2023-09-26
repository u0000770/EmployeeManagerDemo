using EmployeeManagerDemo;

namespace TestEmployeeManagement
{
    [TestClass]
    public class EmployeeTest
    {

        [TestMethod]
        public void TestCalculateWage_WithPositiveValues()
        {
            // Arrange
            Employee employee = new Employee
            {
                HoursWorked = 40.0,    // 40 hours worked
                HourlyRate = 15.0     // Hourly rate of 15
            };

            // Act
            double wage = Wage.CalculateWage(employee.HoursWorked,employee.HourlyRate);

            // Assert
            Assert.AreEqual(600.0, wage); // Expected wage: 40 * 15 = 600
        }

        [TestMethod]
        public void TestCalculateWage_WithZeroValues()
        {
            // Arrange
            Employee employee = new Employee
            {
                HoursWorked = 0.0,    
                HourlyRate = 0.0    
            };

            // Act
            double wage = Wage.CalculateWage(employee.HoursWorked, employee.HourlyRate);

            // Assert
            Assert.AreEqual(0.0, wage); 
        }

        [TestMethod]
        public void TestCalculateWage_WithFractionalValues()
        {
            // Arrange
            Employee employee = new Employee
            {
                HoursWorked = 0.5,    // 0.5 hours worked
                HourlyRate = 1.5     // Hourly rate of 1.5
            };

            // Act
            double wage = Wage.CalculateWage(employee.HoursWorked, employee.HourlyRate);

            // Assert
            Assert.AreEqual(0.75, wage); 
        }

        [TestMethod]
        public void TestCalculateWage_WithZeroHoursWorked()
        {
            // Arrange
            Employee employee = new Employee
            {
                HoursWorked = 0.0,     // 0 hours worked
                HourlyRate = 20.0     // Hourly rate of 20
            };

            // Act
            double wage = Wage.CalculateWage(employee.HoursWorked, employee.HourlyRate); 
            

            // Assert
            Assert.AreEqual(0.0, wage); // Expected wage: 0 * 20 = 0
        }

        [TestMethod]
        public void TestCalculateWage_WithNegativeHourlyRate()
        {
            // Arrange
            Employee employee = new Employee
            {
                HoursWorked = 50.0,     // 50 hours worked
                HourlyRate = -10.0     // Negative hourly rate
            };

            // Act
            double wage = Wage.CalculateWage(employee.HoursWorked, employee.HourlyRate);

            // Assert
            Assert.AreEqual(0, wage); // Expected wage: 50 * (-10) = -500
        }

        [TestMethod]
        public void TestCalculateWage_WithNegativeHoursWorked()
        {
            // Arrange
            Employee employee = new Employee
            {
                HoursWorked = -50.0,     // -50 hours worked
                HourlyRate = 10.0     // hourly rate
            };

            // Act
            double wage = Wage.CalculateWage(employee.HoursWorked, employee.HourlyRate);

            // Assert
            Assert.AreEqual(0, wage); // Expected wage: 50 * (-10) = -500
        }

        [TestMethod]
        public void TestCalculateWage_WithMax()
        {
            // Arrange
            Employee employee = new Employee
            {
                HoursWorked = double.MaxValue,
                HourlyRate = double.MaxValue   
            };

            // Act
            double wage = Wage.CalculateWage(employee.HoursWorked, employee.HourlyRate); 

            // Assert
            Assert.AreEqual(0, wage); 
        }

    }
}