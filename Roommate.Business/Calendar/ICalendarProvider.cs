using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roommate.Business.Calendar
{
    public interface ICalendarProvider
    {
        IEnumerable<AppointmentEntity> GetAppointmentsBetweenDates(DateTime startDate, DateTime endDate);
    }
}
