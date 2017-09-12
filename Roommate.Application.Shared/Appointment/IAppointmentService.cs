using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Text;

namespace Roommate.Application.Shared.Appointment
{
    [ServiceContract]
    public interface IAppointmentService
    {
        [OperationContract]
        IEnumerable<AppointmentUiModel> GetAppointmentsBetween(DateTime dateFrom, DateTime dateTo);
    }
}
