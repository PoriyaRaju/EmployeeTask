using EmployeeTask.abstracts;
using EmployeeTask.exceptions;
using EmployeeTask.interfaces;

namespace EmployeeTask.Services
{
    internal class PayrollService : IPayable
    {
        private readonly List<Employee> _employeeList;

        public PayrollService(List<Employee> employeeList) {
            _employeeList =  employeeList;
        }

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

                    //PartTimeEmployee emp1 = new PartTimeEmployee(name, email, (Employee.EmployeeType)empType, (Employee.Department)dept, hourlyRate, wprkingHour);
                    //emp1.HourlyRate = hourlyRate;
                    //hourlyRate = emp1.HourlyRate;
                    //emp1.Salary = 100m;
                    //Console.WriteLine(emp1.Salary);
                    
                    _employeeList.Add(emp);
                    break;

                case 3:
                    Console.Write("Enter Fixed Amount : ");
                    decimal fixedAmount = Convert.ToDecimal(Console.ReadLine());

                    emp = new ContractEmployee(name, email, (Employee.EmployeeType)empType, (Employee.Department)dept, fixedAmount);

                    //ContractEmployee emp1 = new ContractEmployee(name, email, (Employee.EmployeeType)empType, (Employee.Department)dept, fixedAmount);
                    //emp1.FixedAmount = fixedAmount;
                    //fixedAmount = emp1.FixedAmount;

                    _employeeList.Add(emp);
                    break;

                default:
                    Console.WriteLine("Invalid type selections");
                    break;
            }

        }

        public void DisplayEmployeeList()
        {
            if (_employeeList.Count <= 0)
            {
                throw new EmployeeNotFoundException();
            }
            foreach (Employee e in _employeeList)
            {
                Console.WriteLine(e.ToString());

            }

        }

        public decimal CalculateSalary()
        {
            Employee e = GetPaybleEmployee();

            Console.Write("Do you want to add Extra Bonus : Then presss 'Y'  : ");
            ConsoleKeyInfo choich = Console.ReadKey();
       
            Console.WriteLine();

            if (Convert.ToChar(choich.Key) == 'Y')
            {
                Console.Write("Add Extra Bonus : ");
                decimal extraBonus = Convert.ToDecimal(Console.ReadLine());
                return e.CalculateSalary(extraBonus);
            }
            else return e.CalculateSalary();
        }

        public void GenerateSalarySlip()
        {
            Console.WriteLine("Salary Slip :");
            GetPaybleEmployee().GenerateSalarySlip();
        }

        public Employee GetPaybleEmployee()
        {
            if (_employeeList.Count <= 0)
            {
                throw new EmployeeNotFoundException();
            }
            int employeeId;
            do
            {
                Console.Write("Enter Employee Id : ");
                employeeId = Convert.ToInt32(Console.ReadLine());

                //Employee.CounterId++;
                if (employeeId <= Employee.CounterId && employeeId > 0) break;
                else
                {

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Enter Valid Employee Id");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            } while (true);

            Employee emp = _employeeList.First(emp => emp.EmployeeId == employeeId);

            return emp;
        }


    }
}
