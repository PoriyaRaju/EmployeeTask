using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeTask.exceptions
{
    internal class InvalidSalaryException : Exception
    {
        public InvalidSalaryException() : base("Salary must be Positive...") { }
        public InvalidSalaryException(string message) : base(message) { }
    }
}
