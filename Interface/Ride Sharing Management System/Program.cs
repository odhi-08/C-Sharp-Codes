/* A ride-sharing company wants to calculate fares for different vehicle types.

Requirements:
1. Create abstract class Vehicle with VehicleID, DriverName, BaseFare, constructor,
DisplayInfo(), and abstract CalculateFare().
2. Create interface IPremiumService with:
double CalculatePremiumCharge();
3. Create:
• Car : Vehicle, IPremiumService (LuxuryCharge; Fare = BaseFare + LuxuryCharge)
• Bike : Vehicle (Distance; Fare = BaseFare + Distance*10)
• SUV : Vehicle, IPremiumService (LuxuryCharge, ExtraPassengerCharge; Fare = BaseFare
+ LuxuryCharge + ExtraPassengerCharge)
4. In Main(), store all objects in Vehicle[], display details and fare using runtime
polymorphism. For premium vehicles, also display the premium charge.
 */

using System;
abstract class Vehicle
{
    public int VehicleId { get; set; }
    public string DriverName { get; set; }
    public double Basefare { get; set; }
    public Vehicle(int id,string name,double basefare)
    {
        VehicleId= id;
        DriverName= name;
        Basefare= basefare;
    }
    public void Display()
    {
        Console.WriteLine("Vehicle Id: " + VehicleId);
        Console.WriteLine("Driver Name: " + DriverName);
        Console.WriteLine("Base Fare: " + Basefare);
    }
    public abstract double CalculateFare(); //Abstract method (must be implemented in child classes)
}
interface IPremiumService
{
    double CalculatePremiumCharge();

}
class Car: Vehicle, IPremiumService
{
    public double LuxuaryCharge { get; set; }
    public Car(int  id,string name,double basefare,double luxuaryCharge) : base(id,name,basefare)
    {
        LuxuaryCharge= luxuaryCharge;
    }
    public override double CalculateFare()
    {
        return Basefare + LuxuaryCharge;
    }
    public double CalculatePremiumCharge()
    {
        return LuxuaryCharge;
    }
}
class Bike: Vehicle
{
    public double Distance { get; set; }
    public Bike(int id,string name,double basefare, double distance) : base(id,name,basefare)
    {
        Distance= distance;
    }
    public override double CalculateFare()
    {
        return Basefare + Distance*10;
    }
}
class SUV : Vehicle, IPremiumService
{
    public double LuxuaryCharge { get; set; }
    public double ExtraPassengerCharge { get; set; }
    public SUV(int id,string name,double basefare, double luxuarycharge,double extrapassenger) : base(id,name,basefare)
    {
        LuxuaryCharge= luxuarycharge;
        ExtraPassengerCharge= extrapassenger;
    }
    public override double CalculateFare()
    {
        return Basefare + LuxuaryCharge + ExtraPassengerCharge;
    }
    public double CalculatePremiumCharge()
    {
        return LuxuaryCharge + ExtraPassengerCharge;
    }
}

class RideSharing
{
    static void Main()
    {
        Vehicle[] vehicle = new Vehicle[3];
        vehicle[0] = new Car(1, "X", 100, 50);
        vehicle[1] = new Bike(2, "Y", 50, 5);
        vehicle[2] = new SUV(3, "Z", 150, 70, 30);

        foreach(Vehicle v in vehicle)
        {
            Console.WriteLine("\nVehicle Info");
            v.Display();

            double fare = v.CalculateFare(); // Calculate fare using polymorphism
            Console.WriteLine("Total Fare: " + fare);

            if(v is IPremiumService premimum)  // Check if vehicle is premium
            {
                Console.WriteLine("Premimum Charges: " + premimum.CalculatePremiumCharge());
            }
        }
    }
}