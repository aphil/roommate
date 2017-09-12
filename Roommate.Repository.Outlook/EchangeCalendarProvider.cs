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

            // Set the start and end time and number of appointments to retrieve.
            CalendarView cView = new CalendarView(startDate, endDate, 20);

            // Limit the properties returned to the appointment's subject, start time, and end time.
            cView.PropertySet = new PropertySet(AppointmentSchema.Subject, AppointmentSchema.Start, AppointmentSchema.End);

            FolderId folderid = new FolderId(WellKnownFolderName.Calendar, new Mailbox(ConfigurationManager.AppSettings["RoomEmailAddress"]));

            // Retrieve a collection of appointments by using the calendar view.
            FindItemsResults<Microsoft.Exchange.WebServices.Data.Appointment> appointments = service.FindAppointments(folderid, cView);

            return appointments.Select(x => EntityFactory.CreateAppointment(x));
        }
    }
}
