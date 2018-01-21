using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Roommate.Application.Appointments;
using Roommate.Application.Shared.Appointments;
using Roommate.Business.Appointments;
using Roommate.Repository.Appointments;

namespace Roommate.Application.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class AppointmentsController : Controller
    {
        private IAppointmentService _appointmentService;

        public AppointmentsController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        //// GET api/values
        [HttpGet("current")]
        public AppointmentDTO Current()
        {
            return _appointmentService.GetOccuringAppointmentAtDate(DateTime.Now);
        }
    }
}
