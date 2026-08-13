using EmployeeTask.abstracts;
using EmployeeTask.exceptions;
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
                if (value <= 0) throw new InvalidSalaryException("Monthly Salary must be greater than 0");
                else _mothlySalary = value;
            } 
        }

        public decimal Bonus { get { return _bouns; } set {
                if (value < 0) throw new InvalidSalaryException("Bouns must be greater than 0");
                else _bouns = value;
            } 
        }

        public FullTimeEmployee(string name, string email, EmployeeType type, Department dept, decimal monthlySalary,decimal bonus) : base(name, email, type, dept) { 
            MonthlySalary = monthlySalary;
            Bonus = bonus;
            EmployeeId = ++_counterId;
        }

        public override decimal CalculateSalary()
        {
            this.Salary = _mothlySalary + _bouns;
            return this.Salary;
        }

        public override decimal CalculateSalary(decimal extBouns)
        {
            ExtraBonus = extBouns;
            Salary = _mothlySalary + _bouns + extBouns;
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

            Console.WriteLine($"Monthly Salary :{_mothlySalary} \nBouns : {_bouns}");
            if (ExtraBonus != 0) Console.WriteLine($"Extra Bonus : {ExtraBonus}");
            Console.WriteLine($"Salary : {this.Salary}");

        }
    }
}
