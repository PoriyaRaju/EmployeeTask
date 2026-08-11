using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeTask
{
    internal interface IPayable
    {
        //public decimal CalculateSalary();
        public decimal CalculateFullTimeSalary(FullTimeEmployee e);
        public decimal CalculatePartTimeSalary(PartTimeEmployee e);
        public decimal CalculateContractBaseSalary(ContractEmployee e);
        public void GenerateFullTimeSalarySlip(FullTimeEmployee e);
        public void GeneratePartTimeSalarySlip(PartTimeEmployee e);
        public void GenerateContractBaseSalarySlip(ContractEmployee e);

    }
}
