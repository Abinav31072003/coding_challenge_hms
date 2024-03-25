using HMS.Entities;
using System.Data.SqlClient;
using HMS.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace HMS.Repository
{
    internal class AppointmentRepository
    {
        public List<Appointments>  Appointments = new List<Appointments>();
        SqlConnection connect = null;
        SqlCommand cmd = null;

        public AppointmentRepository()
        {
            connect = new SqlConnection(DataConnectionUtilitycs.GetConnectionString());
            cmd = new SqlCommand();
        }

        public void AddAppointment(Appointments appointments)
        {
            cmd.CommandText = "Insert into Appointment values(@aid,@pid,@did,@date,@desc)";
            cmd.Parameters.AddWithValue("@aid", appointments.AppointmentId);
            cmd.Parameters.AddWithValue("@pid", appointments.PatientId);
            cmd.Parameters.AddWithValue("@did", appointments.DoctorId);
            cmd.Parameters.AddWithValue("@date", appointments.AppointmentDate);
            cmd.Parameters.AddWithValue("@desc",appointments.Description);
            connect.Open();
            cmd.Connection = connect;
            cmd.ExecuteNonQuery();
            connect.Close();
        }

        public void RemoveAppointment(int aid)
        {
            cmd.CommandText = "Delete * from Appointment where appointmentId = @aid";
            cmd.Parameters.AddWithValue("@aid", aid);
            connect.Open();
            cmd.Connection = connect;
            cmd.ExecuteNonQuery();
            connect.Close();
        }

        public void GetbyId(int aid)
        {
            cmd.CommandText = "Select * from Appointment where appointmentId = @aid";
            cmd.Parameters.AddWithValue("@aid", aid);
            connect.Open();
            cmd.Connection = connect;
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            while (reader.Read())
            {
                Appointments appointments = new Appointments();
                appointments.AppointmentId = (int)reader["appointmentId"];
                appointments.PatientId = (int)reader["patientId"];
                appointments.DoctorId = (int)reader["doctorId"];
                appointments.Description = (string)reader["description"];
                appointments.AppointmentDate = (DateTime)reader["appointmentDate"];

                Appointments.Add(appointments);

            }
            Console.WriteLine("{AppointmentID}\t{PatientId}\t{DoctorId}\t{Appointment Date}\t{Decsription}\t");
            foreach (Appointments appointments1 in Appointments)
            {
                Console.WriteLine(appointments1.ToString());
            }
            connect.Close();
        }

        public void GetbyPatientId(int pid)
        {
            cmd.CommandText = "Select * from Appointment where appointmentId = @pid";
            cmd.Parameters.AddWithValue("@pid", pid);
            connect.Open();
            cmd.Connection = connect;
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            connect.Close();
        }

        public void GetbyDoctorId(int did)
        {
            cmd.CommandText = "Select * from Appointment where appointmentId = @did";
            cmd.Parameters.AddWithValue("@did", did);
            connect.Open();
            cmd.Connection = connect;
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            connect.Close();
        }

        public void GetAppointments()
        {
            cmd.CommandText = "Select * from Appointment";
            cmd.Connection = connect;
            connect.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Appointments apooint1 = new Appointments();
                apooint1.AppointmentId = (int)reader["appointmentId"];
                apooint1.PatientId = (int)reader["patientId"];
                apooint1.DoctorId = (int)reader["doctorId"];
                apooint1.AppointmentDate = (DateTime)reader["appointmentDate"];
                apooint1.Description = (string)reader["Description"];
                Appointments.Add(apooint1);

            }

            connect.Close();
        }

        public bool patientExists(int patientid)
        {
            int count = 0;
            cmd.CommandText = "Select count(*) as total from Appointment where patientId=@pid";
            cmd.Parameters.AddWithValue("@pid", patientid);
            connect.Open();
            cmd.Connection = connect;
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                count = (int)reader["total"];
            }
            connect.Close();
            if (count > 0)
            {
                return true;
            }
            return false;
        }

    }
}
