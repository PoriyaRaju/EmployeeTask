using EmployeeTask.abstracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeTask.utils
{
    internal class EmployeeComparator : IComparer<Employee>
    {
        public int Compare(Employee x, Employee y)
        {
            int priorityName = string.Compare(x.Name, y.Name);

            if (priorityName == 0)
            {
                int priorityEmail = string.Compare(x.Email, y.Email);
                if(priorityEmail == 0)
                {
                    if ((int)x.Type == (int)y.Type) return 0;
                    else if((int)x.Type < (int)y.Type) return -1;
                    return 1;
                    
                }
                return priorityEmail;
            }

            return priorityName;
        }
    }
}
