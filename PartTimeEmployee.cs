using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeTask
{
    internal class PartTimeEmployee : Employee,IPayable {

        public PartTimeEmployee(string name, string email, Department dept) : base(name, email, dept) { }

        private decimal _hourlyRate;

        private decimal _workingHour;

        public decimal HourlyRate { get { return _hourlyRate; } set { 
                if(value < 0) throw new Exception("Hours Rate must be Greater than Zero");
                else _hourlyRate = value;
            }  
        }
        public decimal WorkingHour
        {
            get { return _workingHour; }
            set { _workingHour = value; }

        }

        public decimal CalculateSalary()
        {
            return _hourlyRate * _workingHour;
        }

        public void GenerateSalarySlip()
        {
            Console.WriteLine("Salary Slip : ");
            base.AccountHolder();
            Console.WriteLine($"Hourly Salary :{_hourlyRate} \nWorking Hours : {_workingHour} \nSalary : {this.CalculateSalary()} \n");

        }

    }
}
