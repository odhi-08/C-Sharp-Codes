/* A hospital wants to automate its patient billing system. Every patient shares common
information, but the billing process differs depending on the type of patient. Additionally, only
insured patients can claim insurance.
Requirements
1. Create an abstract class Patient;
Properties:
- PatientID
- Name
- Age
- ConsultationFee
Methods:
- Constructor
- DisplayInfo()
- Abstract method CalculateBill()
2. Create the following derived classes
IndoorPatient
- Additional: NumberOfDays, RoomChargePerDay
- Bill = ConsultationFee + (NumberOfDays × RoomChargePerDay)
- Implements IInsurance
OutdoorPatient
- Additional: TestCharge
- Bill = ConsultationFee + TestCharge
- Does NOT implement IInsurance
EmergencyPatient
- Additional: EmergencyCharge
- Bill = ConsultationFee + EmergencyCharge
- Implements IInsurance
3. Create an interface &#39;IInsurance&#39;
Method:
- double ClaimAmount();
Insurance Claim = 80% of Total Bill
4. In the Main() method
- Store all patient objects in a Patient[] array.
- Display patient information and total bill using runtime polymorphism.
- Show insurance claim only for patients implementing IInsurance. */

using System;
abstract class Patient
{
    public int PatientID { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public double ConsultationFee { get; set; }

    public Patient(int id, string name, int age, double fee)
    {
        PatientID = id;
        Name = name;
        Age = age;
        ConsultationFee = fee;
    }
    public void DisplayInfo()
    {
        Console.WriteLine("Patient ID: " + PatientID);
        Console.WriteLine("Name: " + Name);
        Console.WriteLine("Age: " + Age);
        Console.WriteLine("Consultation Fee: " + ConsultationFee);
    }
    public abstract double CalculateBill();
}
interface IInsurance
{
    double ClaimAmount();
}
class IndoorPatient : Patient, IInsurance
{
    public int NumberOfDays { get; set; }
    public int RoomChargePerDay { get; set; }
    public IndoorPatient(int id, string name, int age, double fee, int days, int roomCharge) : base(id, name, age, fee)
    {
        NumberOfDays = days;
        RoomChargePerDay = roomCharge;
    }
    public override double CalculateBill()
    {
        return ConsultationFee + (NumberOfDays * RoomChargePerDay);
    }
    public double ClaimAmount()
    {
        return CalculateBill() * 0.8;
    }

}
// Outdoor Patient (no insurance)
class OutdoorPatient : Patient
{
    public double TestCharge { get; set; }
    public OutdoorPatient(int id, string name, int age, double fee, double testCharge) : base(id, name, age,fee)
    {
        TestCharge = testCharge;
    }
    public override double CalculateBill()
    {
        return ConsultationFee + TestCharge;
    }
}
// Emergency Patient (has insurance)
class EmergencyPatient : Patient, IInsurance
{
    public double EmergencyCharges { get; set; }
    public EmergencyPatient(int id, string name, int age, double fee, double emergencyCharges) : base(id, name, age,fee)
    {
        EmergencyCharges = emergencyCharges;
    }
    public override double CalculateBill()
    {
        return ConsultationFee + EmergencyCharges;
    }
    public double ClaimAmount()
    {
        return CalculateBill() * 0.8;
    }
}
class PatientSystem
{
    static void Main()
    {
        Patient[] patients = new Patient[3];

        patients[0] = new IndoorPatient(1, "Odhi", 08, 500, 3, 1000);
        patients[1] = new OutdoorPatient(2, "Sajib", 16, 300, 200);
        patients[2] = new EmergencyPatient(3, "Rizvi", 30, 700, 500);

        foreach (Patient p in patients)
        {
            Console.WriteLine("\n--- Patient Info ---");
            p.DisplayInfo();

            double bill = p.CalculateBill();
            Console.WriteLine("Total Bill: " + bill);

            // Check insurance
            if (p is IInsurance insurance)
            {
                Console.WriteLine("Insurance Claim (80%): " + insurance.ClaimAmount());
            }
        }

    }
}