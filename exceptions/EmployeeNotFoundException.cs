using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeTask.exceptions
{
    internal class EmployeeNotFoundException : Exception
    {
        public EmployeeNotFoundException() : base("Employee Not Found") { }

        public EmployeeNotFoundException(string message) : base(message) { }
    }
}
