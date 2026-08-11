using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeTask
{
    internal class FullTimeEmployee : Employee
    {
        private decimal _mothlySalary;
        private decimal _bouns;

        public decimal MonthlySalary { 
            get { return _mothlySalary; } 
            set{
                if (value <= 0) throw new Exception("Monthly Salary must be greater than 0");
                else _mothlySalary = value;
            } 
        }

        public decimal Bonus { get { return _bouns; } set {
                if (value < 0) throw new Exception("Bouns must be greater than 0");
                else _bouns = value;
            } 
        }

        public FullTimeEmployee(string name, string email, Department dept) : base(name,email,dept) { }

    }
}
