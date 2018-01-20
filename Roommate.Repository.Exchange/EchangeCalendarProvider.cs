using Microsoft.Exchange.WebServices.Data;
using Roommate.Business.Appointments;
using Roommate.Repository.Appointments;
using Roommate.Repository.Outlook;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roommate.Repository.Business
{
    public class EchangeCalendarProvider : IAppointmentRepository
    {
        private IExchangeServiceInitializer _exchangeServiceInitializer;
        public EchangeCalendarProvider(IExchangeServiceInitializer exchangeServiceInitializer)
        {
            _exchangeServiceInitializer = exchangeServiceInitializer;
        }

        public IEnumerable<AppointmentEntity> GetAppointmentsBetweenDates(DateTime startDate, DateTime endDate)
        {
            ExchangeService service = _exchangeServiceInitializer.GetService();
            CalendarView cView = new CalendarView(startDate, endDate, 20);
            cView.PropertySet = new PropertySet(AppointmentSchema.Subject, AppointmentSchema.Start, AppointmentSchema.End);
            FolderId folderid = new FolderId(WellKnownFolderName.Calendar, new Mailbox(_exchangeServiceInitializer.RoomEmailAddress));

            FindItemsResults<Microsoft.Exchange.WebServices.Data.Appointment> appointments = service.FindAppointments(folderid, cView);

            return appointments.Select(x => EntityFactory.CreateAppointment(x));
        }
    }
}
