/* University Admission System using Events
Problem Statement:
When a student's admission is completed, the system should automatically:
• Generate Student ID
• Send Welcome Email
• Create LMS Account
• Create Library Account
Requirements:
 Create a delegate named AdmissionHandler.
 Create a publisher class named AdmissionOffice.
 Declare an event named AdmissionCompleted.
 Implement subscriber methods:
• GenerateStudentID()
• SendWelcomeEmail()
• CreateLMSAccount()
• CreateLibraryAccount()
 Raise the event after admission is completed.
*/

using System;

public delegate void AdmissionHandler();

//Publisher class
class Admission
{
    //Declare Event
    public event AdmissionHandler AdmissionCompleted;
    public void CompleteAdmission()
    {
        Console.WriteLine("Student Admission is completed");

        //Raise event
        AdmissionCompleted?.Invoke();
    }

}

class Program
{

    //Subscriber Methods
    static void GenerateStudent()
    {
        Console.WriteLine("Student ID Generated.");
    }
    static void SendWelcomeEmail()
    {
        Console.WriteLine("Welcome Email Sent.");
    }

    static void CreateLMSAccount()
    {
        Console.WriteLine("LMS Account Created.");
    }

    static void CreateLibraryAccount()
    {
        Console.WriteLine("Library Account Created.");
    }
    static void Main()
    {
        Admission a = new Admission(); //publisher's object

        a.AdmissionCompleted += GenerateStudent;
        a.AdmissionCompleted += SendWelcomeEmail;
        a.AdmissionCompleted += CreateLMSAccount;
        a.AdmissionCompleted += CreateLibraryAccount;

        a.CompleteAdmission();
    }
}

   
