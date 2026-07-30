/*Create an abstract class `Shape` with an abstract method `CalculateArea()` and a non-abstract method `Display()` that 
 * prints Calculating areaThen create two derived classes, `Circle` and `Rectangle`, that implement the `CalculateArea()` method. 
 * The `Circle` class should calculate the area of a circle, and the `Rectangle` class should calculate the area of a rectangle.
 * Demonstrate the use of the abstract class by creating objects of `Circle` and `Rectangle` and calling their methods.*/
using System;
public abstract class Shape
{
    public abstract void CalculateArea();
    public void Display() //non abstract method
    {
        Console.WriteLine("Calculating Area");
    }
}
class Circle : Shape
{
    public double radius;
    public Circle(double r)
    {
        radius = r;
    }
    public override void CalculateArea()
    {
        double area = 3.14 * radius * radius;
        Console.WriteLine("Area of a Circle: " + area);
    }
}
class Rectangle : Shape
{
    public double length, width;
    public Rectangle(double l, double w)
    {
        length = l;
        width = w;
    }
    public override void CalculateArea()
    {
        double area = length * width;
        Console.WriteLine("Area of a Rectangle: " + area);
    }

}
class Program
{
    static void Main()
    {
        Shape s = new Circle(5.5);
        s.Display();
        s.CalculateArea();

        Shape r = new Rectangle(5.5, 6.5);
        r.Display();
        r.CalculateArea();
    }
}

