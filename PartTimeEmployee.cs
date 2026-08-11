using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeTask
{
    internal class PartTimeEmployee : Employee {

        public PartTimeEmployee(string name, string email, Department dept) : base(name, email, dept) { }

        private decimal _hourlyRate;

        private decimal _workingHour;

        public decimal HourlyRate { get { return _hourlyRate; } set { 
                if(value < 0) throw new Exception("Hours Rate must be Greater than Zero");
                else _hourlyRate = value;
            }  
        }
        public decimal WorkingHour
        {
            get { return _workingHour; }
            set { _workingHour = value; }

        }

    }
}
