using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeTask
{
    internal class PayrollService : IPayable
    {

        public decimal CalculateFullTimeSalary(FullTimeEmployee e)
        {
            return e.MonthlySalary + e.Bonus;
        }

        public decimal CalculatePartTimeSalary(PartTimeEmployee e)
        {
            return e.HourlyRate * e.WorkingHour;

        }

        public decimal CalculateContractBaseSalary(ContractEmployee e)
        {
            return e.FixedAmount;
        }

        public void GenerateFullTimeSalarySlip(FullTimeEmployee e)
        {
            Console.WriteLine("Salary Slip : ");
            e.AccountHolder();
            Console.WriteLine($"Monthly Salary :{e.MonthlySalary} \nBouns : {e.Bonus} \nSalary : {this.CalculateFullTimeSalary(e)} \n");
        }

        public void GeneratePartTimeSalarySlip(PartTimeEmployee e)
        {
            Console.WriteLine("Salary Slip : ");
            e.AccountHolder();
            Console.WriteLine($"Hourly Salary :{e.HourlyRate} \nWorking Hours : {e.WorkingHour} \nSalary : {this.CalculatePartTimeSalary(e)} \n");
        }

        public void GenerateContractBaseSalarySlip(ContractEmployee e)
        {
            Console.WriteLine("Salary Slip : ");
            e.AccountHolder();
            Console.WriteLine($"Contact Amount :{e.FixedAmount} \nSalary : {this.CalculateContractBaseSalary(e)} \n");
        }
    }
}
