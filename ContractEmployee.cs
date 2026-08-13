using EmployeeTask.abstracts;
using EmployeeTask.exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeTask
{
    internal class ContractEmployee : Employee
    {
        private decimal _fixedAmount;

        public decimal FixedAmount
        {
            get { return _fixedAmount; }
            private set {
                if (value <= 0) throw new InvalidSalaryException("Fixed Amount must be greater than Zero.");
                else { _fixedAmount = value; }
            }

        }

        public ContractEmployee(string name, string email, EmployeeType type ,Department dept, decimal fixedAmount) : base(name, email,type,dept) { 
            FixedAmount = fixedAmount;
            EmployeeId = ++CounterId;
        }

        public override decimal CalculateSalary() { 
            Salary = FixedAmount;
            return Salary; 
        
        }

        public override decimal CalculateSalary(decimal extBonus)
        {
            ExtraBonus = extBonus;
            Salary = _fixedAmount + extBonus;
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
            Console.WriteLine($"Contact Amount :{FixedAmount}");
            if (ExtraBonus != 0) Console.WriteLine($"Extra Bonus : {ExtraBonus}");
            Console.WriteLine($"Salary : {this.Salary}");
        }
    }
}
