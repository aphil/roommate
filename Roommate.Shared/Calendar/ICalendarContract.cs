using System;
using System.Collections.Generic;
using System.Text;

namespace Roommate.Shared.Calendar
{
    [ServiceContract]
    public interface ICalendarContract
    {
        GetEventsResponse GetEvents(GetEventsArgs args);
    }
}
