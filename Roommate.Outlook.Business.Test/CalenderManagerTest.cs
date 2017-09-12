using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Roommate.Repository.Business;
using Roommate.Repository.Outlook;

namespace Roommate.Outlook.Business.Test
{
    [TestClass]
    public class CalenderManagerTest
    {
        [TestMethod]
        public void GetEventsByDates()
        {
            EchangeCalendarProvider manager = new EchangeCalendarProvider(new ExchangeServiceInitializer());

            var appointments = manager.GetAppointmentsBetweenDates(new DateTime(2017, 06, 09), new DateTime(2017, 06, 10));

            Assert.IsTrue(appointments.Count() > 0);

        }
    }
}
