using Microsoft.Exchange.WebServices.Data;
using Roommate.Business.Calendar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roommate.Outlook.Business
{
    public static class EntityFactory
    {
        public static AppointmentEntity CreateAppointment(Appointment appointment)
        {
            AppointmentEntity entity = new AppointmentEntity();

            entity.Description = appointment.Subject;
            entity.StartTime = appointment.Start;
            entity.EndTime = appointment.End;
            return entity;
        }
    }
}
