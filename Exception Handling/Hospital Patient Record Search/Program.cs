/* A hospital stores patient records in a Dictionary&lt;int, string&gt; where the key is the Patient ID.
Requirements:
 Accept a Patient ID.
 Display the patients name if found.

Exceptions to Handle:
Exception When it Occurs
FormatException The user enters an invalid Patient ID (e.g., letters instead of numbers).
KeyNotFoundException The entered Patient ID does not exist in the dictionary.

Example Input / Output:
Input:
Patient ID: 200
Output:
Patient record not found. */

using System;
using System.Collections.Generic;

namespace exception_handling
{
    class Patient
    {
        public int PatientId { get; set; }
        public string Name { get; set; }
        public void Display()
        {
            Console.WriteLine("Patient Name: " + Name);
        }

    }
    internal class PatientRecord
    {
        static void Main()
        {
            Patient patient = new Patient();   // object created
            Dictionary<int, string> patients = new Dictionary<int, string>(); // Dictionary created

            patients[101] = "X";
            patients[102] = "Y";
            patients[103] = "Z";

            try
            {
                Console.Write("Patient ID : ");
                patient.PatientId = int.Parse(Console.ReadLine());

                if (!patients.ContainsKey(patient.PatientId))  //checking if the id is in the dictionary
                {
                    throw new KeyNotFoundException();
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid patient ID.");
            }
            catch (KeyNotFoundException)
            {
                Console.WriteLine("Patient record not found.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}