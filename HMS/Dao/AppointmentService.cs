﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HMS.Repository;

namespace HMS.Dao
{
    internal class AppointmentService
    {
        public void appointmentmenu()
        {
            AppointmentRepository appointmentRepository = new AppointmentRepository();
            appointmentRepository.GetAppointments();
        }
    }
}
