using Roommate.Application.Shared.Appointments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;


namespace Roommate.IoT.Services
{
    public class AppointmentService
    {
        public async AppointmentDTO GetCurrentAppointment()
        {
            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.GetAsync("")
            }
        }

    }
}
