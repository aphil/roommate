using Roommate.Application.Shared.Appointment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Roommate.Application.Appointment
{
    [ServiceBehavior]
    public class AppointmentService : IAppointmentService
    {
        public IEnumerable<AppointmentUiModel> GetAppointmentsBetween(DateTime dateFrom, DateTime dateTo)
        {
            return new List<AppointmentUiModel>()
            {
                new AppointmentUiModel(),
                new AppointmentUiModel()
            };
        }
    }
}
