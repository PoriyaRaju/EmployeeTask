Task 2 — Employee Payroll System

Requirements

1 Create an abstract Employee class with Id, Name, Email, and Department.
2 Create FullTimeEmployee, PartTimeEmployee, and ContractEmployee classes that inherit from Employee.
3 Each employee type must calculate salary differently.
4 Create an IPayable interface containing CalculateSalary() and GeneratePayslip().
5 All employee types should implement IPayable.
6 Create a PayrollService that works with employees through the IPayable interface.
7 Salary rules: Full-time = Monthly Salary + Bonus; Part-time = Hourly Rate × Hours Worked; Contract = Fixed
  Contract Amount.
8 Salary-related values must not be directly modified from outside the employee class.
9 Use method overloading with CalculateSalary() and CalculateSalary(bonus).
10 Use a static counter to automatically generate employee IDs.
11 Create a console menu: Add Employee, Display Employees, Calculate Salary, Generate Payslip, Exit.
12 Validate that name and email are not empty, salary is not negative, and working hours are not negative.
13 Create a custom exception such as InvalidSalaryException.
14 Override ToString() for employee information.


OOP Concepts: Class, Object, Encapsulation, Inheritance, Abstraction, Interface, Polymorphism, Method
Overloading, Method Overriding, Static Members, Composition, Exception Handling, Access Modifiers.