using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Text;

namespace Roommate.Application.Shared.Appointments
{
    public interface IAppointmentService
    {
        IEnumerable<AppointmentDTO> GetAppointmentsBetween(DateTime dateFrom, DateTime dateTo);
        AppointmentDTO GetOccuringAppointmentAtDate(DateTime atDate);
    }
}
