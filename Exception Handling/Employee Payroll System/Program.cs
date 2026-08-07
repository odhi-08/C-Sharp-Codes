/* A company requires every employee&#39;s monthly salary to be at least ₹18,000.
Requirements:
 Accept the employee&#39;s salary.
 Validate the salary before storing it.
Create Custom Exception:
class InvalidSalaryException : Exception
{
public InvalidSalaryException(string message)
: base(message)
{
}
}

Exceptions to Handle:
Exception When it Occurs
FormatException The user enters a non-numeric salary value.
ArgumentOutOfRangeException The salary entered is negative. Throw this exception manually.
InvalidSalaryException The salary is less than ₹18,000, which violates the companys minimum salary policy. Throw this custom exception manually.

Example Input / Output:
Input:
Salary: 12000

Output:
Salary must be at least 18,000.
 */

using System;

namespace exception_handling
{
    // Custom Exception
    class InvalidSalaryException : Exception
    {
        public InvalidSalaryException(string message) : base(message)
        {
        }
    }

    class Employee
    {
        public double Salary { get; set; }

        public void Display()
        {
            Console.WriteLine("Salary Accepted: " + Salary);
        }
    }

    internal class SalarySystem
    {
        static void Main()
        {
            Employee e = new Employee();

            try
            {
                Console.Write("Salary: ");
                e.Salary = Convert.ToDouble(Console.ReadLine());

                // negative check
                if (e.Salary < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }

                // minimum salary check
                if (e.Salary < 18000)
                {
                    throw new InvalidSalaryException("Salary must be at least 18,000.");
                }

                e.Display();
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid salary input.");
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Salary cannot be negative.");
            }
            catch (InvalidSalaryException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}