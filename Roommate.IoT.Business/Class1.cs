using Roommate.Application.Shared.Appointment;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roommate.Business
{
    public class Class1
    {
        // AppointmentUiModel
        public async Task AAa()
        {

            IoT.Business.RoommateServer.AppointmentServiceClient client = new IoT.Business.RoommateServer.AppointmentServiceClient();
            var appointments = await client.GetAppointmentsBetweenAsync(DateTime.Now, DateTime.Now);
            var abbb = new AppointmentUiModel();
        }
    }
}
