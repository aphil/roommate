using Roommate.Business.Appointments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roommate.Repository.Appointments
{
    public interface IAppointmentRepository
    {
        IEnumerable<AppointmentEntity> GetBetweenDates(DateTime dateFrom, DateTime dateTo, int maxCount);
        AppointmentEntity GetOccuringAtDate(DateTime atDate);
    }
}
