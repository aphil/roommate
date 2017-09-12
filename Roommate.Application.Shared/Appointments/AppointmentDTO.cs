using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Roommate.Application.Shared.Appointments
{
    [DataContract]
    public class AppointmentDTO
    {
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
