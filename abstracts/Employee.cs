using EmployeeTask.exceptions;
using EmployeeTask.interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeTask.abstracts
{
    internal abstract class Employee : IPayable
     {
        public static int _counterId { get; private set; }
        private decimal _salary;
        private decimal _extraBonus;

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

        protected decimal Salary {
            get { return _salary; } 
            set { 
                if (value <= 0) throw new InvalidSalaryException("Salary must be greater than Zero"); 
                _salary = value; 
            } 
        }

        protected decimal ExtraBonus { 
            get { return _extraBonus; } 
            set { 
                if (value < 0) throw new InvalidSalaryException("Extra Bonus must be greater than Zero"); 
                _extraBonus = value; 
            } 
        }

        public enum Department { 
            HR_Dept = 1,    
            Marketing_Dept = 2,
            BA_Dept = 3
        }

        public Employee(string name, string email, EmployeeType type,Department dept)
        {
            if (String.IsNullOrEmpty(name) || String.IsNullOrEmpty(email)) { 
                throw new ArgumentNullException("All argument Must be required"); 
            }
            Type = type;
            Name = name;
            Email = email;
            Dept = dept;
            EmployeeId = ++_counterId;
        }


        public abstract decimal CalculateSalary();

        public abstract decimal CalculateSalary(decimal extBouns);

        public  abstract void GenerateSalarySlip();

        public override string ToString()
        {
            return  $"{EmployeeId} | {Name} | {Email} | {Type} |{Dept}";
        }
    }
}
