using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Roommate.Repository.Business;
using Roommate.Repository.Outlook;
using System.Configuration;

namespace Roommate.Outlook.Business.Test
{
    [TestClass]
    public class CalenderManagerTest
    {
        [TestMethod]
        public void GetEventsByDates()
        {

            ExchangeAppointmentRepository manager = new ExchangeAppointmentRepository(new ExchangeServiceInitializer(
                ConfigurationManager.AppSettings["ExchangeUsername"],
                ConfigurationManager.AppSettings["ExchangePassword"],
                ConfigurationManager.AppSettings["ExchangeDomain"],
                ConfigurationManager.AppSettings["ExchangeUrl"],
                ConfigurationManager.AppSettings["RoomEmailAddress"]
                ));

            var appointments = manager.GetBetweenDates(new DateTime(2017, 06, 09), new DateTime(2017, 06, 10), 20);

            Assert.IsTrue(appointments.Count() > 0);

        }

        [TestMethod]
        public void GetOccuringAtDate()
        {

            ExchangeAppointmentRepository manager = new ExchangeAppointmentRepository(new ExchangeServiceInitializer(
                ConfigurationManager.AppSettings["ExchangeUsername"],
                ConfigurationManager.AppSettings["ExchangePassword"],
                ConfigurationManager.AppSettings["ExchangeDomain"],
                ConfigurationManager.AppSettings["ExchangeUrl"],
                ConfigurationManager.AppSettings["RoomEmailAddress"]
                ));

            var appointments = manager.GetOccuringAtDate(new DateTime(2017, 06, 09, 10, 30, 0));

            Assert.IsNotNull(appointments);

        }
    }
}
