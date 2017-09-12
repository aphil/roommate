using Roommate.Application.Shared.Appointment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestUWP
{
    public class Class1
    {
        public async Task<IEnumerable<AppointmentUiModel>> GetAppointments()
        {
            Roommate.IoT.Presentation.RoommateServices.AppointmentServiceClient client = new Roommate.IoT.Presentation.RoommateServices.AppointmentServiceClient();
            IEnumerable<AppointmentUiModel> appointments = await client.GetAppointmentsBetweenAsync(DateTime.Now, DateTime.Now);
            return appointments;
        }
    }
}
