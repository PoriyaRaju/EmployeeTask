using System.Transactions;

namespace EmployeeTask;

public class Program
{
    public static void Main(string[] args)
    {
        //Console.WriteLine("THis is Payroll Service");
        List<Employee> _employeeList = new List<Employee>();
        List<PartTimeEmployee> _partTimeEmployees = new List<PartTimeEmployee>();
        List<FullTimeEmployee> _fullTimeEmployees = new List<FullTimeEmployee>();
        List<ContractEmployee> _contractBaseEmployees = new List<ContractEmployee>();

        int choich = 1;
        //bool flag = true;
        do
        {
            Console.WriteLine("Welcom to Payout Services");
            Console.WriteLine("Menu Options \n1.Add Employee \n2.Display Employees \n3.Calculate Salary \n4.Generate Pay-slip \n5.Exit");

            Console.Write("Enter Your Choich : ");
            choich = Convert.ToInt32(Console.ReadLine());

            switch (choich)
            {
                case 1:

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

                    switch (empType)
                    {
                        case 1:
                            //Employee e7 = new Employee(name,  , (Employee.EmployeeType)1, Employee.Department.BA_Dept);
                            FullTimeEmployee fl = new FullTimeEmployee(name, email, (Employee.EmployeeType)empType, (Employee.Department)dept);
                            _fullTimeEmployees.Add(fl);
                            _employeeList.Add(fl);
                            break;
                        case 2:
                            PartTimeEmployee pe = new PartTimeEmployee(name, email, (Employee.EmployeeType)empType, (Employee.Department)dept);
                            _partTimeEmployees.Add(pe);
                            _employeeList.Add(pe);
                            break;
                        case 3:
                            ContractEmployee ce = new ContractEmployee(name, email, (Employee.EmployeeType)empType, (Employee.Department)dept);
                            _contractBaseEmployees.Add(ce);
                            _employeeList.Add(ce);
                            break;
                        default:
                            Console.WriteLine("Invalid type selections");
                            break;
                    }

                    break;

                case 2:

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
                    break;

                case 3:
                    Console.WriteLine("Select Type of an Employee : FULL_TIME = 1 \tPART_TIME = 2 \tCONTRACT_BASE = 3");

                    bool processC = false;
                    do
                    {
                        Console.Write("Select option : ");
                        empType = Convert.ToInt32(Console.ReadLine());

                        if (empType > 3 || empType < 1)
                        {
                            Console.WriteLine("Invalid input");
                            processB = true;
                        }

                    } while (processC);

                    Console.Write("Enter Employee Id : ");
                    int employeeId = Convert.ToInt32(Console.ReadLine());

                    if (employeeId > Employee.Id || employeeId < 0)
                    {
                        Console.WriteLine("Enter valid Employee Id");
                        break;
                    }

                    switch (empType)
                    {
                        case 1:

                            foreach (FullTimeEmployee e in _fullTimeEmployees)
                            {
                                if (e.EmployeeId == employeeId)
                                {
                                    Console.Write("Enter Monthly Salary : ");
                                    e.MonthlySalary = Convert.ToInt32(Console.ReadLine());

                                    Console.Write("Do you want to add addional Bonus");
                                    try
                                    {
                                        char c = Convert.ToChar(Console.ReadLine().ToUpper());
                                        if (c == 'Y') {
                                            Console.Write("Enter Bonus : ");
                                            int bonus = Convert.ToInt32(Console.ReadLine());
                                            e.CalculateSalary(bonus);
                                        }
                                        else
                                        {
                                            e.CalculateSalary();
                                        }
                                    }
                                    catch (Exception)
                                    {
                                        Console.WriteLine("Enter valid Charectore");

                                    }

                                    e.CalculateSalary();
                                    e.GenerateSalarySlip();
                                    break;
                                }
                            }
                            break;
                        case 2:
                            break;
                        case 3:
                            break;
                        default:
                            Console.WriteLine("Invalid type selections");
                            break;
                    }

                    break;

                case 4:

                    break;

                case 5:
                    Console.WriteLine("Thanks for Your Response....");
                    //flag = false; 
                    break;

                default:
                    Console.WriteLine("Enter valid Choich...!!!");
                    break;
            }



        } while (choich != 5);

        //FullTimeEmployee e1 = new FullTimeEmployee("Raju", "rajuporiya@gmail.com", (Employee.EmployeeType)1, Employee.Department.BA_Dept);
        //e1.Bonus = 200;
        //e1.MonthlySalary = 1000;
        //e1.CalculateSalary();
        //// This method Overloading;
        //e1.CalculateSalary(500);
        //e1.GenerateSalarySlip();
        //list.Add(e1);

        //PartTimeEmployee e2 = new PartTimeEmployee("Sumit", "sumit@google.com", (Employee.EmployeeType)1, Employee.Department.Marketing_Dept);
        //e2.WorkingHour = 2m;
        //e2.HourlyRate = 100;
        //e2.CalculateSalary();
        //e2.GenerateSalarySlip();


        //ContractEmployee e3 = new ContractEmployee("Harsh", "harsh@google.com", (Employee.EmployeeType)1, Employee.Department.Marketing_Dept);
        //e3.FixedAmount = 1000;
        //e3.CalculateSalary();
        //e3.GenerateSalarySlip();

    }
}