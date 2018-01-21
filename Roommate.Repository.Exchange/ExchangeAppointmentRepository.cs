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
    public class ExchangeAppointmentRepository : IAppointmentRepository
    {
        private IExchangeServiceInitializer _exchangeServiceInitializer;
        public ExchangeAppointmentRepository(IExchangeServiceInitializer exchangeServiceInitializer)
        {
            _exchangeServiceInitializer = exchangeServiceInitializer;
        }

        public IEnumerable<AppointmentEntity> GetBetweenDates(DateTime startDate, DateTime endDate, int maxCount)
        {
            ExchangeService service = _exchangeServiceInitializer.GetService();
            CalendarView cView = new CalendarView(startDate, endDate, maxCount);
            cView.PropertySet = new PropertySet(AppointmentSchema.Subject, AppointmentSchema.Start, AppointmentSchema.End);
            FolderId folderid = new FolderId(WellKnownFolderName.Calendar, new Mailbox(_exchangeServiceInitializer.RoomEmailAddress));

            FindItemsResults<Microsoft.Exchange.WebServices.Data.Appointment> appointments = service.FindAppointments(folderid, cView);

            return appointments.Select(x => EntityFactory.CreateAppointment(x));
        }

        public AppointmentEntity GetOccuringAtDate(DateTime atDate)
        {
            return GetBetweenDates(atDate, atDate, 1).SingleOrDefault();
        }
    }
}
