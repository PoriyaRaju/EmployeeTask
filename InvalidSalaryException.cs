using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeTask
{
    internal class InvalidSalaryException : Exception
    {
        public InvalidSalaryException(string message) : base(message) { }
    }
}
