using HMS.Entities;
using HMS.Repository;
using HMS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Exceptions
{
    internal class PatientNotFoundException : Exception
    {
        public PatientNotFoundException(string message) :base(message) { }
   

        public static void PatientNotFound(int patientId)
        {
            AppointmentRepository appointmentRepository= new AppointmentRepository();
            if (!appointmentRepository.patientExists(patientId))
            {
                throw new PatientNotFoundException("Patient not found!!");
            }
        }
    }
}
