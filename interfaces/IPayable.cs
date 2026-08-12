using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeTask.interfaces
{
    internal interface IPayable
    {
        public decimal CalculateSalary();

        //public decimal CalculateSalary(decimal extBouns);
        public void GenerateSalarySlip();

    }
}
