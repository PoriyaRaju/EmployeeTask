using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeTask
{
    internal abstract class Employee
    {
        public static int Id { get; private set; }
        
        public string Name { get; set; }
        
        public string Email { get; set; }

        

        public Department Dept { get; set; }

        //protected decimal Salary {  get; set; }

        public enum Department { 
            HR_Dept,    
            Marketing_Dept,
            BA_Dept
        }

        public Employee(string name, string email, Department dept)
        {
            Id++;
            //if(String.IsNullOrEmpty(name) || String.IsNullOrEmpty(email)) { throw new Exception("All fields mustbe Required"); }
            Name = name;
            Email = email;
            Dept = dept;
        }

        public void AccountHolder()
        {
            Console.WriteLine($"{Id} | {Name} | {Email} | {Dept}");
        }
    }
}
