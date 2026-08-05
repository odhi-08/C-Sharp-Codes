/* An online shopping application asks the customer to enter the product price and quantity. The
system calculates and displays the total bill.
Requirements:
 Accept product price.
 Accept quantity.
 Calculate the total amount.
Exceptions to Handle:
FormatException = The user enters non-numeric input (e.g.abc insteadof 500).
OverflowException = The user enters a number that is too large or too small
for the data type (e.g., a value beyond the range of int or decimal).
ArgumentOutOfRangeException= The entered price or quantity is less than or equal to
zero. Throw this exception manually after validating
the input.
 */
using System;

namespace exception_handling
{
    class ArgumentOutofRangeException : Exception
    {
        public ArgumentOutofRangeException(string message) : base(message) { }
    }
    class Product
    {
        public double Price { get; set; }
        public int Quantity { get; set; }
        public double TotalAmount { get; set; }
        public void Display()
        {
            Console.WriteLine("\nPrice : " + Price);
            Console.WriteLine("Quantity : " + Quantity);
            Console.WriteLine("Total Amount : " + TotalAmount);
        }
    }
    internal class OnlineShopping
    {
        static void Main()
        {
            Product product = new Product();
            try
            {
                Console.Write("Enter Price: ");
                product.Price = double.Parse(Console.ReadLine());
                if (product.Price <= 0)
                {
                    product.Price = 0;
                    throw new ArgumentOutOfRangeException("Price is less than 0.");
                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (OverflowException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                Console.Write("Enter Quantity: ");
                product.Quantity = int.Parse(Console.ReadLine());
                if (product.Quantity <= 0)
                {
                    product.Quantity = 0;
                    throw new ArgumentOutOfRangeException("Quantity is less than 0.");
                }
            }
            catch (OverflowException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            product.TotalAmount = product.Price * product.Quantity;
            product.Display();

        }
    }
}

