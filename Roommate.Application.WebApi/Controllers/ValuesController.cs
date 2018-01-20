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
    public class ValuesController : Controller
    {
        private IAppointmentService _appointmentService;

        public ValuesController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            var aa = _appointmentService.GetAppointmentsBetween(DateTime.Now.AddDays(-2), DateTime.Now);

               var bb = aa.FirstOrDefault();

            return bb?.Description;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
