using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roommate.Business.Appointments
{
    public class AppointmentEntity
    {
        public AppointmentEntity()
        : this(string.Empty, DateTime.MinValue, DateTime.MaxValue)
        {

        }

        public AppointmentEntity(string description, DateTime startTime, DateTime endTime)
        {
            Description = description;
            StartTime = startTime;
            EndTime = endTime;
        }

        public string Description
        { get; set; }

        public DateTime StartTime
        { get; set; }

        public DateTime EndTime
        { get; set; }
    }
}
