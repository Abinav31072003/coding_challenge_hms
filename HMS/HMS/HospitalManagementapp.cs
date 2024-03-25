using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HMS.Dao;

namespace HMS.HMS
{
    internal class HospitalManagementapp
    {
        HospitalServiceImpl hospitalServiceImpl;
        PatientService patientService;
        DoctorService doctorService;
        AppointmentService appointmentService;

        public HospitalManagementapp()
        {
            hospitalServiceImpl = new HospitalServiceImpl();
            patientService = new PatientService();  
            doctorService = new DoctorService();    
            appointmentService = new AppointmentService();
        }

        public void mainmenu()
        {
            int option = 0;
            do
            {
                //Console.Clear();
                Console.WriteLine("Main Menu");
                Console.WriteLine(".................");
                Console.WriteLine($"1:: Hospital Service\n2:: Patients\n3:: Doctors\n4:: Appointments\n5:: Exit\n");
                Console.WriteLine("Enter your choice: ");
                option = int.Parse(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        hospitalServiceImpl.hospitalservicemenu();
                        break;

                    case 2:
                        patientService.patientmenu();
                        break;

                    case 3:
                        doctorService.doctormenu();
                        break;

                    case 4:
                        appointmentService.appointmentmenu();
                        break;

                    case 5:
                        Console.WriteLine("Exiting...");
                        break;

                    default:
                        Console.WriteLine("Try again...");
                        break;
                }
            } while (option != 5);
        }
    }
}
