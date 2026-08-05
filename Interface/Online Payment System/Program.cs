/* An e-commerce company supports multiple payment methods.
1. Create interface IPayment with method:
double Pay(double amount);
2. Implement CreditCard (2% fee), MobileBanking (1.5% fee and 100 Tk cashback if
amount=5000), and Cash (no fee).
3. In Main(), store all payment methods in an IPayment[] array and process a payment of
6000 Tk using runtime polymorphism
*/

using System;
interface IPayment
{
    double Pay(double amount); //method declaration
}
class Creditcard : IPayment
{
    public double Pay(double amount) //must be public
    {
        return amount + amount * 0.02;
    }
}
class MobileBanking : IPayment
{
    public double Pay(double amount)
    {
        double total = amount + amount * 0.015;
        if (amount >= 5000)
        {
            total -= 100;
        }
        return total;
    }
}
class Cash: IPayment
{
    public double Pay(double amount)
    {
        return amount;
    }
}
class PaymentSystem
{
    static void Main()
    {
        IPayment[] payment = new IPayment[3];
        payment[0]= new Creditcard();
        payment[1]= new MobileBanking();
        payment[2] = new Cash();

        //Runtime polymorphism
        foreach (IPayment p in payment)
        {
            switch (p)
            {
                case Creditcard:
                    Console.WriteLine("Payment by Credit Card : " + p.Pay(6000));
                    break;

                case MobileBanking:
                    Console.WriteLine("Payment by Mobile Banking : " + p.Pay(6000));
                    break;

                case Cash:
                    Console.WriteLine("Payment by Cash : " + p.Pay(6000));
                    break;

            }
        }
            
    }
}