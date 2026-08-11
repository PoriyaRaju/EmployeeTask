using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeTask
{
    internal interface IPayable
    {
        public decimal CalculateSalary();
        public void GenerateSalarySlip();

    }
}
