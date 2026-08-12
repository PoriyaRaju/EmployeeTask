using EmployeeTask.abstracts;
using EmployeeTask.exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeTask
{
    internal class PartTimeEmployee : Employee
    {
        private decimal _hourlyRate;
        private decimal _workingHour;

        public decimal HourlyRate
        {
            get { return _hourlyRate; }
            set
            {
                if (value < 0) throw new InvalidSalaryException("Hours Rate must be Greater than Zero");
                else _hourlyRate = value;
            }
        }
        public decimal WorkingHour
        {
            get { return _workingHour; }
            set {
                if (value <= 0) throw new InvalidSalaryException("Working Hour must be greater than Zero");
                else{ _workingHour = value; }
            }

        }

        public PartTimeEmployee(string name, string email, EmployeeType type, Department dept, decimal hourlyRate, decimal workingHour) : base(name, email, type, dept)
        {
            HourlyRate = hourlyRate;
            WorkingHour = workingHour;
        }

        public override decimal CalculateSalary()
        {
            Salary = _hourlyRate * _workingHour;
            Console.WriteLine($" Estimated Salary : {Salary}");
            return Salary;
        } 

        public override decimal CalculateSalary(decimal extBonus)
        {
            ExtraBonus =  extBonus;
            Salary = _hourlyRate * _workingHour + extBonus;
            return Salary;
        }

        public override void GenerateSalarySlip()
        {
            Console.WriteLine("Salary Slip : ");
            Console.WriteLine(base.ToString());

            if (this.Salary == 0)
            {

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("First you Should Calculate Salary");
                Console.ForegroundColor = ConsoleColor.White;
            }

            Console.WriteLine($"Hourly Salary :{_hourlyRate} \nWorking Hours : {_workingHour}");
            if (ExtraBonus != 0) Console.WriteLine($"Extra Bonus : {ExtraBonus}");
            Console.WriteLine($"Salary : {this.Salary}");
        }

    }
}
