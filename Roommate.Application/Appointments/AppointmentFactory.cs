using Roommate.Application.Shared.Appointments;
using Roommate.Business.Appointments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roommate.Application.Appointments
{
    internal static class AppointmentFactory
    {
        internal static AppointmentDTO CreateAppointmentUiModel(AppointmentEntity appointmentEntity)
        {
            AppointmentDTO dto = new AppointmentDTO();
            dto.Description = appointmentEntity.Description;
            dto.EndTime = appointmentEntity.EndTime;
            dto.StartTime = appointmentEntity.StartTime;
            return dto;
        }
    }
}
