using System;
using System.Collections.Generic;

namespace adapter
{
    class Program
    {
        static void Main(string[] args)
        {
            IEmployeeService employeeService = new EmployeeService();
            var emp = employeeService.GetEmployee(1);
            Console.WriteLine(emp.ToString());
        }
    }

    class Employee
    {
        public int Id { get; set; }
        public string FullName { get; set; }

        public override string ToString()
        {
            return Id.ToString() + " " + FullName;
        }
    }

    class ThirdPartyService
    {
        List<Employee> employees = null;

        public ThirdPartyService()
        {
            employees = new List<Employee>()
            {
                new Employee()
                {
                    Id = 1,
                    FullName = "Krishna Sarigopula"
                },
                new Employee()
                {
                    Id = 2,
                    FullName = "Manasa Sarigopula"
                },
                 new Employee()
                {
                     Id = 3,
                    FullName = "Kaveri Sarigopula"
                }
            };
        }

        public List<Employee> GetEmployees()
        {
            return employees;
        }
    }

    interface IEmployeeService
    {
        Employee GetEmployee(int employeeId);
    }

    class EmployeeService : IEmployeeService
    {
        ThirdPartyService thirdPartyService = new ThirdPartyService();
        public Employee GetEmployee(int employeeId)
        {
            return thirdPartyService.GetEmployees().Find(x => x.Id == employeeId);
        }
    }
}