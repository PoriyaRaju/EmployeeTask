using EmployeeTask.abstracts;
using EmployeeTask.interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeTask
{
    internal class PayrollService : IPayable
    {
        private readonly List<Employee> _employeeList = new List<Employee>();


        public void AddEmployee()
        {
            Console.Write("Name : ");
            string? name = Console.ReadLine();

            Console.Write("Email : ");
            string? email = Console.ReadLine();

            if (String.IsNullOrEmpty(name) || String.IsNullOrEmpty(email))
            {
                throw new ArgumentNullException("Name and Email must be required");
            }

            Console.WriteLine("Select Departmet : HR_Dept = 1 \tMarketing_Dept = 2 \tBA_Dept = 3");
            int dept;
            do
            {
                Console.Write("Select option : ");
                dept = Convert.ToInt32(Console.ReadLine());

                if (dept <= 3 && dept >= 1) break;

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input");
                Console.ForegroundColor = ConsoleColor.White;

            } while (true);

            Console.WriteLine("Select Type of an Employee : FULL_TIME = 1 \tPART_TIME = 2 \tCONTRACT_BASE = 3");
            int empType;
            do
            {
                Console.Write("Select option : ");
                empType = Convert.ToInt32(Console.ReadLine());

                if (empType <= 3 && empType >= 1) break;

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input");
                Console.ForegroundColor = ConsoleColor.White;


            } while (true);

            Employee emp;

            switch (empType)
            {
                case 1:
                    Console.Write("Enter Monthly Salary : ");
                    decimal monthlySalary = Convert.ToDecimal(Console.ReadLine());

                    Console.Write("Enter Bonus : ");
                    decimal bonus = Convert.ToDecimal(Console.ReadLine());

                    emp = new FullTimeEmployee(name, email, (Employee.EmployeeType)empType, (Employee.Department)dept, monthlySalary, bonus);
                    _employeeList.Add(emp);

                    break;

                case 2:
                    Console.Write("Enter Hourly Rate : ");
                    decimal hourlyRate = Convert.ToDecimal(Console.ReadLine());

                    Console.Write("Enter Working Hour : ");
                    decimal wprkingHour = Convert.ToDecimal(Console.ReadLine());

                    emp = new PartTimeEmployee(name, email, (Employee.EmployeeType)empType, (Employee.Department)dept, hourlyRate, wprkingHour);
                    _employeeList.Add(emp);
                    break;

                case 3:
                    Console.Write("Enter Fixed Amount : ");
                    decimal fixedAmount = Convert.ToDecimal(Console.ReadLine());

                    emp = new ContractEmployee(name, email, (Employee.EmployeeType)empType, (Employee.Department)dept, fixedAmount);
                    _employeeList.Add(emp);
                    break;

                default:
                    Console.WriteLine("Invalid type selections");
                    break;
            }

        }

        public void DisplayEmployeeList()
        {
            if (_employeeList.Count > 0)
            {
                foreach (Employee e in _employeeList)
                {
                    Console.WriteLine(e.ToString());
                }
            }
            else
            {
                Console.WriteLine("There is no data Found");
            }
        }

        public Employee GetPaybleEmployee(int id)
        {
            if (_employeeList.Count == 0) throw new Exception("Empty List");

            Employee emp = _employeeList.First(emp => emp.EmployeeId == id);

            //FullTimeEmployee e1 = new FullTimeEmployee("Raju", "rajuporiya@gmail.com", (Employee.EmployeeType)1, Employee.Department.BA_Dept,100,100);

            return emp;
        }

        public decimal CalculateSalary()
        {
            int employeeId;
            do
            {
                Console.Write("Enter Employee Id : ");
                employeeId = Convert.ToInt32(Console.ReadLine());

                if (employeeId <= Employee._counterId && employeeId > 0) break;

            } while (true);

            Employee e = GetPaybleEmployee(employeeId);

            Console.Write("Do you want to add Extra Bonus : Then presss 'Y'  : ");
            char choich = Convert.ToChar(Console.ReadLine().ToUpper());

            if (choich == 'Y')
            {
                Console.Write("Add Extra Bonus : ");
                decimal extraBonus = Convert.ToDecimal(Console.ReadLine());
                return e.CalculateSalary(extraBonus);
            }
            else return e.CalculateSalary();
        }

        public void GenerateSalarySlip()
        {
            Console.WriteLine("Salary Slip");
            int employeeId;
            do
            {
                Console.Write("Enter Employee Id : ");
                employeeId = Convert.ToInt32(Console.ReadLine());

                if (employeeId <= Employee._counterId && employeeId > 0) break;
                else
                {

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Enter Valid Employee Id");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            } while (true);

            Console.WriteLine();
            GetPaybleEmployee(employeeId).GenerateSalarySlip();

        }

    }
}
