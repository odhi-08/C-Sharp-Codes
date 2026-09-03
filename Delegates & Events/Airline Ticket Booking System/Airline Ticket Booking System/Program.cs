/* Airline Ticket Booking System (Delegates + Events)
Problem Statement:
Develop an Airline Ticket Booking System. Customers can pay using Credit Card, Debit Card, or bKash. After successful payment, the system should automatically:
• Send the e-ticket by email
• Send an SMS confirmation
• Update seat availability
Requirements:
Part A (Delegate)
Define PaymentDelegate.
Create:
   • CreditCardPayment(double amount)
   • DebitCardPayment(double amount)
   • BkashPayment(double amount)
Ask the user to enter ticket price.
Ask the user to choose a payment method.
Use the delegate to invoke the selected payment method.
Part B (Event)
Create a publisher class named Airline.
Declare an event named TicketBooked.
Create subscriber methods:
   • SendEmail()
   • SendSMS()
   • UpdateSeatAvailability()
Raise the event after successful payment.

 */

using System;
// Delegate
delegate void PaymentDelegate(double amount);
class Payment
{
    public static void CreditCardPayment(double amount)
    {
        Console.WriteLine("Paid " + amount + " by Credit Card.");
    }
    public static void DebitCardPayment(double amount)
    {
        Console.WriteLine("Paid " + amount + " by Debit Card.");
    }
    public static void BkashPayment(double amount)
    {
        Console.WriteLine("Paid " + amount + " by Bkash.");
    }
}

// Publisher
class Airline
{
    // Event declaration
    public event Action TicketBooked;
    public void BookTicket()
    {
        Console.WriteLine("Ticket Booked Successfully");
        // Raise event
        TicketBooked?.Invoke();
    }
}

// Subscriber
class Notification
{
    public static void SendEmail()
    {
        Console.WriteLine("E-ticket sent via Email.");
    }
    public static void SendSMS()
    {
        Console.WriteLine("SMS confirmation sent.");
    }
    public static void UpdateSeatAvailability()
    {
        Console.WriteLine("Seat availability updated.");
    }
}
class Program
{
    static void Main()
    {
        Console.Write("Enter ticket price: ");
        double amount = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("\nSelect a Payment Method:");
        Console.WriteLine("1. Credit Card");
        Console.WriteLine("2. Debit Card");
        Console.WriteLine("3. Bkash");
        int choice = int.Parse(Console.ReadLine());
        PaymentDelegate pay;
        switch (choice)
        {
            case 1:
                pay = Payment.CreditCardPayment;
                break;
            case 2:
                pay = Payment.DebitCardPayment;
                break;
            case 3:
                pay = Payment.BkashPayment;
                break;
            default:
                Console.WriteLine("Invalid choice.");
                return;
        }
        // Delegate call
        pay(amount);
        Console.WriteLine("\nPayment Successful!");
        Airline airline = new Airline();
        // Subscribe events
        airline.TicketBooked += Notification.SendEmail;
        airline.TicketBooked += Notification.SendSMS;
        airline.TicketBooked += Notification.UpdateSeatAvailability;
        // Raise event
        airline.BookTicket();
    }
}
