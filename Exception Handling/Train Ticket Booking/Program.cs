/* Scenario: A railway reservation system has 100 seats numbered from 1 to 100. A passenger enters a
seat number to book.
Requirements:
 Accept a seat number.
 Book the seat if it is available.
Exceptions to Handle:
Exception When it Occurs
FormatException The user enters a non-numeric seat number.
ArgumentOutOfRangeException The seat number is less than 1 or greater than 100.Throw this exception manually.
InvalidOperationException The selected seat has already been booked. Throw this exception manually.

Example Input / Output:
Input:
Seat Number: 105
Output:
Seat number must be between 1 and 100.
*/

using System;
namespace exception_handling
{
    class Train
    {
        public int SeatNumber { get; set; }
        public void Display()
        {
            Console.WriteLine("Booked Seat Number : "+SeatNumber);
        }
    }
    internal class TrainBooking
{
    static void Main()
    {
        Train train = new Train();
        bool[] seats = new bool[101];

        //Seat 50 is already booked
        seats[50] = true;

        try
        {
            Console.Write("Enter seat Number : ");
            train.SeatNumber = int.Parse(Console.ReadLine());

            if(train.SeatNumber<1 || train.SeatNumber>100)
            {
                throw new ArgumentOutOfRangeException("Seat Number must be between 1-100.");
            }
            if (seats[train.SeatNumber]==true)
            {
                throw new InvalidOperationException("The selected seat has already been booked.");
            }
            seats[train.SeatNumber] = true;
            train.Display();

        }
        catch (FormatException)
        {
            Console.WriteLine("Please enter a valid number.");
        }
        catch(OverflowException)
        {
            Console.WriteLine("Number is too large or too small.");
        }
        catch(ArgumentOutOfRangeException)
        {
            Console.WriteLine("Seat number must be between 1 and 100.");
        }
        catch(InvalidOperationException)
        {
            Console.WriteLine("The selected seat has already been booked.");
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        
    }
    }
}
