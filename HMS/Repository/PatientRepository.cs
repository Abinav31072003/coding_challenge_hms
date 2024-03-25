using HMS.Entities;
using HMS.Dao;
using HMS.Utility;
using HMS.Utility;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Repository
{
    internal class PatientRepository
    {
        List<Patients> patients = new List<Patients>();
        SqlConnection connect = null;
        SqlCommand cmd = null;

        public PatientRepository()
        {
            connect = new SqlConnection(DataConnectionUtilitycs.GetConnectionString());
            cmd = new SqlCommand();
        }
        public List<Patients> GetPatients()
        {
            cmd.CommandText = "Select * from Patient";
            cmd.Connection = connect;
            connect.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Patients patients1 = new Patients();
                patients1.PatientId = (int)reader["patientId"];
                patients1.FirstName = (string)reader["firstName"];
                patients1.LastName = (string)reader["lastName"];
                patients1.DateOfBirth = (DateTime)reader["dateOfBirth"];
                patients1.Gender = (string)reader["gender"];
                patients1.ContactNumber = (string)reader["contactNumber"];
                patients1.Address = (string)reader["address"];
                patients.Add(patients1);

            }

            connect.Close();
            return patients;
        }
    }
}
