/* Scenario: A customer has ₹15,000 in their bank account and wants to withdraw money.
Requirements:
 Accept the withdrawal amount.
 Deduct the amount if sufficient balance exists.
Create Custom Exception
Exceptions to Handle:
FormatException The user enters an invalid withdrawal amount (e.g.letters).
ArgumentOutOfRangeException The withdrawal amount is less than or equal to zero. Throw this exception manually.
InsufficientBalanceException The withdrawal amount is greater than the available account balance. Throw this custom exception manually.

Example Input / Output:
Input:
Balance: 15000
Withdraw: 20000
Output:
Insufficient balance for this transaction.
 */

using System;

namespace exception_handling
{
    class InsufficientBalanceException : Exception
    {
        public InsufficientBalanceException(string message) : base(message)
        { 
        }
    }
    class Bank
    {
        public double Balance { get; set; }
        public void Display()
        {
            Console.WriteLine("Remaining Balance: " + Balance);
        }
    }

    internal class BankSystem
    {
        static void Main()
        {
            Bank account = new Bank();
            account.Balance = 15000;

            try
            {
                Console.WriteLine("Balance : " + account.Balance);
                Console.Write("Withdraw : ");

                double amount = Convert.ToDouble(Console.ReadLine());

                if (amount <= 0)
                {
                    throw new ArgumentOutOfRangeException();
                }

                if (amount > account.Balance)
                {
                    throw new InsufficientBalanceException("Insufficient balance for this transaction.");
                }
                account.Balance -= amount;
                account.Display();
            }

            catch (FormatException)
            {
                Console.WriteLine("Invalid amount");

            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Amount must be greater than zero.");
            }
            catch (InsufficientBalanceException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }    
        
    }
}