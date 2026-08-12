using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeTask
{
    internal class PartTimeEmployee : Employee, IPayable
    {
        private decimal _hourlyRate;

        private decimal _workingHour;

        public decimal HourlyRate
        {
            get { return _hourlyRate; }
            set
            {
                if (value < 0) throw new Exception("Hours Rate must be Greater than Zero");
                else _hourlyRate = value;
            }
        }
        public decimal WorkingHour
        {
            get { return _workingHour; }
            set { _workingHour = value; }

        }

        public PartTimeEmployee(string name, string email, EmployeeType type, Department dept, decimal hourlyRate, decimal workingHour) : base(name, email, type, dept)
        {
            HourlyRate = hourlyRate;
            WorkingHour = workingHour;
        }

        public decimal CalculateSalary()
        {
            this.Salary = _hourlyRate * _workingHour;
            return this.Salary;
        }

        public void GenerateSalarySlip()
        {
            Console.WriteLine("Salary Slip : ");
            base.AccountHolder();
            Console.WriteLine($"Hourly Salary :{_hourlyRate} \nWorking Hours : {_workingHour} \nSalary : {this.Salary} \n");

        }

    }
}
