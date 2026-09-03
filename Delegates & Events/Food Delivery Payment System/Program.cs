/*Develop an Online Food Delivery System where customers can pay using Cash on Delivery, bKash, or Credit Card.
Requirements:
 Define a delegate named PaymentDelegate.
 Create methods:
• CashOnDelivery(double amount)
• BkashPayment(double amount)
• CreditCardPayment(double amount)
 Ask the user to enter the food bill.
 Ask the user to choose a payment method.
 Use the delegate to invoke the selected payment method.
 Display a payment confirmation and &#39;Order Confirmed Successfully.&#39;
 * */


using System;
// delegate declare (method reference)
delegate void PaymentDelegate(double amount);

class Payment
{
    public static void CashOnDelivery(double amount)
    {
        Console.WriteLine("Paid " + amount + " by COD");
    }
    public static void BkashPayment(double amount)
    {
        Console.WriteLine("Paid " + amount + " by Bkash");
    }
    public static void CreditCardPayment(double amount)
    {
        Console.WriteLine("Paid " + amount + " by Credit Card");
    }
}

class Program
{
    static void Main()
    {
        Console.Write("Enter amount : ");
        double amount = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Select a payment method:");
        Console.WriteLine("1. COD");
        Console.WriteLine("2. Bkash");
        Console.WriteLine("3. Credit Card");

        int choice = int.Parse(Console.ReadLine());

        PaymentDelegate pay; //delegate variable

        switch (choice)
        {
            case 1:
                pay = Payment.CashOnDelivery;
                break;

            case 2:
                pay = Payment.BkashPayment;
                break;

            case 3:
                pay = Payment.CreditCardPayment;
                break;

            default:
                Console.WriteLine("Invalid payment method.");
                return;
        }

        pay(amount); //delegate call
        Console.WriteLine("\nOrder Confirmed Successfully.");
    }
}
