using HMS.Entities;
using HMS.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Dao
{
    internal interface IHospitalService
    {
        // Method to get an appointment by its ID
        Appointments GetAppointmentById(int appointmentId, AppointmentRepository appointmentRepository);

        // Method to get appointments for a specific patient
        void GetAppointmentsForPatient(int patientId, AppointmentRepository appointmentRepository);

        // Method to get appointments for a specific doctor
        List<Appointments> GetAppointmentsForDoctor(int doctorId, AppointmentRepository appointmentRepository);

        // Method to schedule a new appointment
        bool ScheduleAppointment(Appointments appointment);

        // Method to update an existing appointment
        bool UpdateAppointment(Appointments appointment);

        // Method to cancel an appointment by its ID
        bool CancelAppointment(int appointmentId);
    }
}
