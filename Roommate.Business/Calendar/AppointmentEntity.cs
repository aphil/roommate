using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Roommate.Business.Calendar
{
    [DataContract]
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

        [DataMember]
        public string Description
        { get; set; }

        [DataMember]
        public DateTime StartTime
        { get; set; }

        [DataMember]
        public DateTime EndTime
        { get; set; }
    }
}
