/*A software company wants to automate its monthly payroll system. All employees have
common information such as Employee ID, Name, and Basic Salary, but different employee
types receive different allowances.

Requirements:
1.Create an abstract class Employee with properties EmployeeID, Name, BasicSalary; a
constructor; DisplayInfo(); and abstract CalculateSalary().
2.Create Manager(HRA = 30 %, Medical = 20 %) and SoftwareEngineer(HRA= 20 %,
Performance Bonus = 15 %) classes.
3.Override CalculateSalary().
4.In Main(), store one Manager and one SoftwareEngineer in an Employee[] array and use
runtime polymorphism to display information and calculated salary.
*/

using System;
abstract class Employee
{
    public string Name { get; set; }
    public int EmployeeId { get; set; }
    public double BasicSalary { get; set; }

    public Employee(string name, int Id, double salary)

    {
        Name= name;
        EmployeeId= Id;
        BasicSalary= salary;
    }
    public void Display()
    {
        Console.WriteLine("Name: " + Name);
        Console.WriteLine("Employee ID : " + EmployeeId);
        Console.WriteLine("Basic Salary: " + BasicSalary);

    }
    public abstract double CalculateSalary();  // Abstract method (must be implemented in child classes)
}
class Manager: Employee
{
    public int HRI { get; set; }
    public int Medical { get; set; }

     // Constructor calls base class constructor
     public Manager(int hri,int medical,string name,int id,double salary) : base( name,id,salary )
    {
        HRI= hri;
        Medical= medical;
    }
    public override double CalculateSalary()
    {
        double hra = BasicSalary * 0.30;
        double medical = BasicSalary * 0.20;
        return BasicSalary + hra + medical;
    }
}
class SoftwareEngineer : Employee
{
    public int HRA { get; set; }
    public int PerfomanceBonus { get; set; }
    public SoftwareEngineer(int hra,int performanceBonus,string name,int id,double salary): base( name, id, salary)
    {
        HRA = hra;
        PerfomanceBonus = performanceBonus;
    }
    public override double CalculateSalary()
    {
        double hra = BasicSalary * 0.20;
        double performanceBonus= BasicSalary * 0.10;
        return BasicSalary + hra + performanceBonus;

    }
}
class PayRoll
{
    static void Main()
    {
        Employee[] e = new Employee[2];
        e[0] = new Manager(10, 20, "X", 208, 80000);
        e[1]= new SoftwareEngineer(20, 30, "Y", 308, 180000);

        foreach(Employee employees in e)
        {
            employees.Display();
            Console.WriteLine("Total Salary: "+employees.CalculateSalary());
        }

    }
}