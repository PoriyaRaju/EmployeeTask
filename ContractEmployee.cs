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
            set { _fixedAmount = value; }

        }

        public ContractEmployee(string name, string email, EmployeeType type ,Department dept, decimal fixedAmount) : base(name, email,type,dept) { 
            FixedAmount = fixedAmount;
        }

        public override decimal CalculateSalary() { 
            base.Salary = FixedAmount;
            return _fixedAmount; 
        
        }
        
        public override void GenerateSalarySlip()
        {
            Console.WriteLine("Salary Slip : ");
            base.AccountHolder();
            Console.WriteLine($"Contact Amount :{FixedAmount} \nSalary : {this.Salary} \n");

        }
    }
}
