using Roommate.Application.Shared.Appointments;
using Roommate.Business.Appointments;
using Roommate.Repository.Appointments;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Roommate.Application.Appointments
{
    [ServiceBehavior]
    public class AppointmentService : IAppointmentService
    {
        IAppointmentRepository _appointmentRepository;
        public AppointmentService(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }

        public IEnumerable<AppointmentDTO> GetAppointmentsBetween(DateTime dateFrom, DateTime dateTo)
        {
            if (dateFrom >= dateTo)
            {
                throw new ArgumentException($"{nameof(dateFrom)} doit être inférieur à {nameof(dateTo)}.");
            }

            IEnumerable<AppointmentEntity> appointments = _appointmentRepository.GetAppointmentsBetweenDates(dateFrom, dateTo);
            return appointments.Select(x => AppointmentFactory.CreateAppointmentUiModel(x));
        }
    }
}
