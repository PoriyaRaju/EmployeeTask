namespace EmployeeTask;

public class Program
{
    public static void Main(string[] args)
    {
        //Console.WriteLine("THis is Payroll Service");

        FullTimeEmployee e1 = new FullTimeEmployee("Raju", "rajuporiya@gmail.com", Employee.Department.BA_Dept);
        e1.Bonus = 200;
        e1.MonthlySalary = 1000;
        e1.CalculateSalary();
        e1.GenerateSalarySlip();


        PartTimeEmployee e2 = new PartTimeEmployee("Sumit", "sumit@google.com", Employee.Department.Marketing_Dept);
        e2.WorkingHour = 2m;
        e2.HourlyRate = 100;
        e2.CalculateSalary();
        e2.GenerateSalarySlip();


        ContractEmployee e3 = new ContractEmployee("Harsh", "harsh@google.com", Employee.Department.Marketing_Dept);
        e3.FixedAmount = 1000;
        e3.CalculateSalary();
        e3.GenerateSalarySlip();

    }
}