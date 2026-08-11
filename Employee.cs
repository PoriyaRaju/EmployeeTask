using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeTask
{
    internal abstract class Employee
    {
        public static int Id { get; private set; }

        public int EmployeeId { get; private set; }
        
        public string Name { get; set; }
        
        public string Email { get; set; }

        public EmployeeType Type { get; set; }
        
        public enum EmployeeType
        {
            FULL_TIME = 1,
            PART_TIME = 2,
            CONTRACT_BASE =3
        }

        public Department Dept { get; set; }

        //protected decimal Salary {  get; set; }

        public enum Department { 
            HR_Dept = 1,    
            Marketing_Dept = 2,
            BA_Dept = 3
        }

        public Employee() { }
        public Employee(string name, string email, EmployeeType type,Department dept)
        {
            Id++;
            EmployeeId = Id;
            //if(String.IsNullOrEmpty(name) || String.IsNullOrEmpty(email)) { throw new Exception("All fields mustbe Required"); }
            Name = name;
            Email = email;
            Dept = dept;
        }

        public void AccountHolder()
        {
            Console.WriteLine($"{EmployeeId} | {Name} | {Email} | {Type} |{Dept}");
        }
    }
}
