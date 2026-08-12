using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeTask
{
    internal class FullTimeEmployee : Employee
    {
        private decimal _mothlySalary;
        private decimal _bouns = 100;

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

        //public FullTimeEmployee() { };
        public FullTimeEmployee(string name, string email, EmployeeType type, Department dept, decimal monthlySalary,decimal bonus) : base(name, email, type, dept) { 
            MonthlySalary = monthlySalary;
            Bonus = bonus;
        }

        public override decimal CalculateSalary()
        {
            this.Salary = _mothlySalary + _bouns;
            return this.Salary;
        }

        public  decimal CalculateSalary(decimal bouns)
        {
            Bonus = bouns;
            Console.WriteLine("Updated Bonus : " + _bouns);
            return _mothlySalary + _bouns;
        }


        public override void GenerateSalarySlip()
        {
            Console.WriteLine("Salary Slip : ");
            base.AccountHolder();
            Console.WriteLine($"Monthly Salary :{_mothlySalary} \nBouns : {_bouns} \nSalary : {this.Salary} \n");

        }
    }
}
