using EmployeeTask.abstracts;
using EmployeeTask.exceptions;
using EmployeeTask.Services;
namespace EmployeeTask;

public class Program
{
    public static void Main(string[] args)
    {

        PayrollService _payrollService = new PayrollService(new List<Employee>());

        int choich=1;
        do
        {
            try
            {
                Console.WriteLine("Welcom to Payout Services");
                Console.WriteLine("Menu Options \n1.Add Employee \n2.Display Employees \n3.Calculate Salary \n4.Generate Pay-slip \n5.Exit");

                Console.Write("Enter Your Choich : ");
                choich = Convert.ToInt32(Console.ReadLine());

                switch (choich)
                {
                    case 1:
                        _payrollService.AddEmployee();
                        break;

                    case 2:
                        _payrollService.DisplayEmployeeList();
                        break;

                    case 3:
                        decimal salary = _payrollService.CalculateSalary();
                        Console.WriteLine($"Calculated Salary : {salary}");
                        break;

                    case 4:
                        _payrollService.GenerateSalarySlip();
                        break;

                    case 5:
                        Console.WriteLine("Thanks for Your Response....");
                        break;

                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Enter valid Choich...!!!");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                }

            }
            catch (FormatException e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e.Message);
                Console.ForegroundColor = ConsoleColor.White;
            }
            catch (ArgumentNullException e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e.Message);
                Console.ForegroundColor = ConsoleColor.White;

            }catch(InvalidSalaryException e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e.Message);
                Console.ForegroundColor = ConsoleColor.White;
            
            }catch(EmployeeNotFoundException e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e.Message);
                Console.ForegroundColor = ConsoleColor.White;
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e.Message);
                Console.ForegroundColor = ConsoleColor.White;
            }

            Console.WriteLine("\n\n");


        } while (choich != 5);


        //Employee e1 = new FullTimeEmployee("Raju", "rajuporiya@gmail.com", (Employee.EmployeeType)1, Employee.Department.BA_Dept,);
        //e1.Bonus = 200;
        //e1.MonthlySalary = 1000;
        //e1.CalculateSalary();
        // This method Overloading;
        //e1.CalculateSalary(500);
        //e1.GenerateSalarySlip();
        //list.Add(e1);


        //IPayable payable = (IPayable) e1;
        //payable.GenerateSalarySlip();

        //PartTimeEmployee e2 = new PartTimeEmployee("Sumit", "sumit@google.com", (Employee.EmployeeType)1, Employee.Department.Marketing_Dept,1000,90);
        //e2.AccountHolder();
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