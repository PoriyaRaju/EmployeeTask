using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeTask
{
    internal class PayrollService : IPayable
    {
        List<Employee> _employeeList = new List<Employee>();


        public void AddEmployee()
        {
            Console.Write("Name : ");
            string name = Console.ReadLine();

            Console.Write("Email : ");
            string email = Console.ReadLine();

            Console.WriteLine("Select Departmet : HR_Dept = 1 \tMarketing_Dept = 2 \tBA_Dept = 3");
            bool processA = false;
            int dept;
            do
            {
                Console.Write("Select option : ");
                dept = Convert.ToInt32(Console.ReadLine());

                if (dept > 3 || dept < 1)
                {
                    Console.WriteLine("Invalid input");
                    processA = true;
                }

            } while (processA);

            Console.WriteLine("Select Type of an Employee : FULL_TIME = 1 \tPART_TIME = 2 \tCONTRACT_BASE = 3");
            bool processB = false;
            int empType;
            do
            {
                Console.Write("Select option : ");
                empType = Convert.ToInt32(Console.ReadLine());

                if (empType > 3 || empType < 1)
                {
                    Console.WriteLine("Invalid input");
                    processB = true;
                }

            } while (processB);

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

                    emp = new PartTimeEmployee(name, email, (Employee.EmployeeType)empType, (Employee.Department)dept,hourlyRate,wprkingHour);
                    _employeeList.Add(emp);
                    break;
                
                case 3:
                    Console.Write("Enter Fixed Amount : ");
                    decimal fixedAmount = Convert.ToDecimal(Console.ReadLine());

                    emp = new ContractEmployee(name, email, (Employee.EmployeeType)empType, (Employee.Department)dept,fixedAmount);
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
                    e.AccountHolder();
                }
            }
            else
            {
                Console.WriteLine("There is no data Found");
            }
        }

        public Employee GetPaybleEmployee(int id)
        {
            if(_employeeList.Count == 0) throw new Exception("Empty List");

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

            return GetPaybleEmployee(employeeId).CalculateSalary();
            //switch (empType)
            //{
            //    case 1:

            //        foreach (FullTimeEmployee e in _fullTimeEmployees)
            //        {
            //            if (e.EmployeeId == employeeId)
            //            {
            //                Console.Write("Enter Monthly Salary : ");
            //                e.MonthlySalary = Convert.ToInt32(Console.ReadLine());

            //                Console.Write("Do you want to add addional Bonus");
            //                try
            //                {
            //                    char c = Convert.ToChar(Console.ReadLine().ToUpper());
            //                    if (c == 'Y')
            //                    {
            //                        Console.Write("Enter Bonus : ");
            //                        int bonus = Convert.ToInt32(Console.ReadLine());
            //                        e.CalculateSalary(bonus);
            //                    }
            //                    else
            //                    {
            //                        e.CalculateSalary();
            //                    }
            //                }
            //                catch (Exception)
            //                {
            //                    Console.WriteLine("Enter valid Charectore");

            //                }

            //                e.CalculateSalary();
            //                e.GenerateSalarySlip();
            //                break;
            //            }
            //        }
            //        break;
            //    case 2:
            //        break;
            //    case 3:
            //        break;
            //    default:
            //        Console.WriteLine("Invalid type selections");
            //        break;
            //        //}
            //}
            //return 100m;
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

            } while (true);

            GetPaybleEmployee(employeeId).GenerateSalarySlip();

        }

    }
}
