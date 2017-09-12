using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Text;

namespace Roommate.Application.Shared.Appointments
{
    [ServiceContract]
    public interface IAppointmentService
    {
        [OperationContract]
        IEnumerable<AppointmentDTO> GetAppointmentsBetween(DateTime dateFrom, DateTime dateTo);
    }
}
