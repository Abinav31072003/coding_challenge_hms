using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HMS.Entities;
using HMS.Repository;
using HMS.Exceptions;

namespace HMS.Dao
{
    internal class HospitalServiceImpl:IHospitalService
    {
        private readonly AppointmentRepository _appointmentRepository;

        public HospitalServiceImpl()
        {
            _appointmentRepository = new AppointmentRepository();
        }
        public void hospitalservicemenu()
        {
            int option;
            Patients patient = new Patients();
            Doctors doctor = new Doctors();
            Appointments appointment;
            do
            {
                Console.WriteLine("Hospital Service Management");
                Console.WriteLine("....................");
                Console.WriteLine($"1: Get appointment detail by id\n2: Get appointment detail of a patient\n3: Get appointment detail of a doctor\n4: Schedule appointment\n5: Update Appointment\n6: Cancel Appointment\n7: Exit");
                Console.WriteLine("Enter your choice: ");
                option = int.Parse(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        Console.WriteLine("Enter appointment id: ");
                        int aid = int.Parse(Console.ReadLine());
                        Appointments appt= GetAppointmentById(aid,_appointmentRepository);
                        Console.WriteLine($"ID: {appt.AppointmentId}, PatientID: {appt.PatientId}, DoctorID: {appt.DoctorId}");
                        break;

                    case 2:
                        Console.WriteLine("Enter patient id: ");
                        int pid = int.Parse(Console.ReadLine());
                        GetAppointmentsForPatient(pid,_appointmentRepository);
                        break;

                    case 3:
                        Console.WriteLine("Enter doctor id: ");
                        int did = int.Parse(Console.ReadLine());
                        GetAppointmentsForDoctor(did,_appointmentRepository);
                        break;

                    case 4:
                        Console.WriteLine("Enter appointment id: ");
                        int aid1 = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter patient id");
                        int pid1 = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter doctor id");
                        int did1 = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter the date");
                        string adate = Console.ReadLine();
                        Console.WriteLine("Enter the Description");
                        string adesc = Console.ReadLine();
                        appointment = new Appointments(aid1, pid1, did1, DateTime.Parse(adate), adesc);
                        ScheduleAppointment(appointment);
                        break;

                    case 5:
                        Console.WriteLine("Enter appointment id: ");
                        int aid2 = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter patient id");
                        int pid2 = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter doctor id");
                        int did2 = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter the date");
                        string adate1 = Console.ReadLine();
                        Console.WriteLine("Enter the Description");
                        string adesc1 = Console.ReadLine();
                        Appointments appointment1 = new Appointments(aid2, pid2, did2, DateTime.Parse(adate1), adesc1);
                        UpdateAppointment(appointment1);
                        break;
                    
                    case 6:
                        Console.WriteLine("Enter appointment id:");
                        int aid3 = int.Parse(Console.ReadLine());
                        CancelAppointment(aid3);
                        break;
                    
                    case 7:
                        Console.WriteLine("Exiting....");
                        break;

                    default:
                        Console.WriteLine("Try again!!!");
                        break;
                }
            } while (option != 7);
        }

        public Appointments GetAppointmentById(int appointmentID, AppointmentRepository appointmentRepository)
        {
            Appointments appointments = new Appointments();
            foreach (Appointments appointments1 in appointmentRepository.Appointments)
            {
                if (appointments1.AppointmentId == appointments.AppointmentId)
                {
                    appointments = appointments1;
                }
            }
            return appointments;
        }

        public void GetAppointmentsForPatient(int patientId, AppointmentRepository appointmentRepository)
        {
            try
            {
                List<Appointments> appointments = new List<Appointments>();
                PatientNotFoundException.PatientNotFound(patientId);
                foreach (Appointments appointments1 in appointmentRepository.Appointments)
                {
                    if (appointments1.PatientId == patientId)
                    {
                        appointments.Add(appointments1);
                    }
                }
                foreach(Appointments appointments2 in appointments)
                {
                    Console.WriteLine(appointments2.ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public List<Appointments> GetAppointmentsForDoctor(int doctorId, AppointmentRepository appointmentRepository)
        {
            List<Appointments> appointments = new List<Appointments>();
            foreach (Appointments appointments1 in appointmentRepository.Appointments)
            {
                if (appointments1.DoctorId == doctorId)
                {
                    appointments.Add(appointments1);
                }
            }
            return appointments;
        }

        public bool ScheduleAppointment(Appointments appointment)
        {
            _appointmentRepository.AddAppointment(appointment);
            return true;
        }

        public bool UpdateAppointment(Appointments appointment)
        {
            foreach (Appointments appointments1 in _appointmentRepository.Appointments)
            {
                if (appointments1.AppointmentId == appointment.AppointmentId)
                {
                    appointment.AppointmentDate = appointments1.AppointmentDate;
                    appointment.PatientId = appointment.PatientId;
                    appointment.DoctorId = appointment.DoctorId;
                    appointment.Description = appointment.Description;
                    return true;
                }
            }
            return true;
        }

        public bool CancelAppointment(int appointmentId)
        {
            _appointmentRepository.RemoveAppointment(appointmentId);
            return true;
        }

    }
}
