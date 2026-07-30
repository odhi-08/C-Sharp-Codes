/*Create two classes: `Animal` and `Dog`. The `Animal` class should have a virtual method 
 `MakeSound()` that prints Animal soundIn the `Dog` class, 
override the `MakeSound()` method to print BarkWrite a program that 
demonstrates **run-time polymorphism** by creating a base class reference(`Animal`) and
pointing it to a derived class object(`Dog`).Call the `MakeSound()` method using the base class reference.*/

using System;
class Animal
{
    public virtual void MakeSound()
    {
        Console.WriteLine("Animal Sound");
    }
}
class Dog : Animal
{
    public override void MakeSound()
    {
        Console.WriteLine("Bark");
    }
}
class Program
{
    static void Main()
    {
        Animal a;
        a = new Dog();
        a.MakeSound();
    }
}

