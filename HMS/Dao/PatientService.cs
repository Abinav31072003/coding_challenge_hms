using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HMS.Repository;
using HMS.Entities;

namespace HMS.Dao
{
    internal class PatientService
    {
        PatientRepository patientRepository = new PatientRepository();
        public void patientmenu() 
        {
            try
            {
                List<Patients> patients = patientRepository.GetPatients();
                Console.WriteLine("All Patients:");
                foreach (Patients patient in patients)
                {
                    Console.WriteLine($"ID: {patient.PatientId}, Name: {patient.FirstName}, DOB: {patient.DateOfBirth}, Gender: {patient.Gender}");
                }
            } catch (Exception ex)
            {
                Console.WriteLine("An error occurred"+ex.Message);
            }

        }
    }
}
