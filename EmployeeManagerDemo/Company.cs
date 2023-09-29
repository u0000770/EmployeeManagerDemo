using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagerDemo
{
    public class Company
    {
        private  List<Employee> employees { get; set; }

        public Company() {
            var employees = new List<Employee>();
            this.employees = employees;
        }

        /// <summary>
        /// Will not Add if ID already exists
        /// </summary>
        /// <param name="employee"></param>
        /// <returns>True</returns>
        public bool AddEmployee(Employee employee)
        {
            var thisEmployee = FindById(employee.EmployeeId);
            if (thisEmployee == null)
            {
                this.employees.Add(employee);
                return true;

            } else { return  false; }
        }


        public void RemoveEmployee(Employee employee)
        {
            var thisEmployee = FindById(employee.EmployeeId);
            if (thisEmployee != null)
            {
                this.employees.Remove(employee);
            }
        }

        public Employee GetEmployeeById(string id)
        {
            return FindById(id);
        }

        public List<Employee> GetAllEmployees()
        {
            return this.employees;
        }

        private Employee FindById(string id)
        {
            var thisEmployee = employees.FirstOrDefault(e => e.EmployeeId == id);
            if (thisEmployee != null)
            {
                return thisEmployee;
            }
            else
            {
                return null;
            }
        }

    
    }
}
