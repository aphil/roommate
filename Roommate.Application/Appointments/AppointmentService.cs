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

            IEnumerable<AppointmentEntity> appointments = _appointmentRepository.GetBetweenDates(dateFrom, dateTo, 20);
            return appointments.Select(x => AppointmentFactory.CreateAppointmentUiModel(x));
        }

        public AppointmentDTO GetOccuringAppointmentAtDate(DateTime atDate)
        {
            AppointmentEntity appointment = _appointmentRepository.GetOccuringAtDate(atDate);
            if (appointment != null)
            {
                return AppointmentFactory.CreateAppointmentUiModel(appointment);
            }

            return null;
        }
    }
}
