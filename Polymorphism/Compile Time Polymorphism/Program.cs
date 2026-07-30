/* Create a class `Calculator` with multiple overloaded versions of a method `Add()`. Implement
the following overloads:
-One that takes two integers and returns their sum.
- Another that takes three integers and returns their sum.
- One that takes two doubles and returns their sum. */

using System;
class Calculator
{
    public int Add(int x, int y)
    {
        return x + y;
    }
    public int Add(int x, int y, int z) //Overloading with different signature(parameter)
    {
        return x + y + z;
    }
    public double Add(double x, double y) //Overloading
    {
        return x + y;
    }
}

class Program
{
    static void Main()
    {
        Calculator c = new Calculator();
        Console.WriteLine(c.Add(5, 6));
        Console.WriteLine(c.Add(1, 2, 3));
        Console.WriteLine(c.Add(4.5, 6.5));
    }
}

