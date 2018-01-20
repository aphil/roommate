using Microsoft.Exchange.WebServices.Data;
using Roommate.Business.Appointments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roommate.Repository.Outlook
{
    public static class EntityFactory
    {
        public static AppointmentEntity CreateAppointment(Microsoft.Exchange.WebServices.Data.Appointment appointment)
        {
            AppointmentEntity entity = new AppointmentEntity();

            entity.Description = appointment.Subject;
            entity.StartTime = appointment.Start;
            entity.EndTime = appointment.End;
            return entity;
        }
    }
}
