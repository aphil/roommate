using Roommate.Application.Shared.Appointments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestUWP
{
    public class Class1
    {
        public async Task<IEnumerable<AppointmentDTO>> GetAppointments()
        {
            Roommate.IoT.Presentation.RoommateServices.AppointmentServiceClient client = new Roommate.IoT.Presentation.RoommateServices.AppointmentServiceClient();
            IEnumerable<AppointmentDTO> appointments = await client.GetAppointmentsBetweenAsync(DateTime.Now, DateTime.Now);
            return appointments;
        }
    }
}
