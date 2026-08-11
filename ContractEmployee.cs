using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeTask
{
    internal class ContractEmployee : Employee,IPayable
    {
        public ContractEmployee(string name, string email, Department dept) : base(name, email, dept) { }

        private decimal _fixedAmount;

        public decimal FixedAmount
        {
            get { return _fixedAmount; }
            set { _fixedAmount = value; }

        }

        public decimal CalculateSalary() { return _fixedAmount; }
        
        public void GenerateSalarySlip()
        {
            Console.WriteLine("Salary Slip : ");
            base.AccountHolder();
            Console.WriteLine($"Contact Amount :{FixedAmount} \nSalary : {this.CalculateSalary()} \n");

        }
    }
}
