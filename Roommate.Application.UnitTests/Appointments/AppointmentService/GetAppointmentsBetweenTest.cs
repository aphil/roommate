using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Roommate.Repository.Appointments;
using System.Collections.Generic;
using Roommate.Business.Appointments;
using System.Linq;

namespace Roommate.Application.UnitTests.Appointment.AppointmentService
{
    [TestClass]
    public class GetAppointmentsBetweenDatesTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void When_InvalidDates_Then_ExceptionIsRaised()
        {
            Shared.Appointments.IAppointmentService appointmentService = new Application.Appointments.AppointmentService(null);
            appointmentService.GetAppointmentsBetween(DateTime.Now, DateTime.Now.AddHours(-1));
        }

        [TestMethod]
        public void When_AppointmentsExist_Then_AppointmentsAreReturned()
        {
            Mock<IAppointmentRepository> appointmentRepositoryMock = new Mock<IAppointmentRepository>();
            appointmentRepositoryMock.Setup(x => x.GetBetweenDates(It.IsAny<DateTime>(), It.IsAny<DateTime>(), It.IsAny<int>())).Returns(new List<AppointmentEntity>()
            {
                new AppointmentEntity("Test", DateTime.Now.AddMinutes(10), DateTime.Now.AddMinutes(30))
            });

            Shared.Appointments.IAppointmentService appointmentService = new Application.Appointments.AppointmentService(appointmentRepositoryMock.Object);
            var appointments = appointmentService.GetAppointmentsBetween(DateTime.Now, DateTime.Now.AddDays(1));

            Assert.AreEqual(1, appointments.Count());
        }
    }
}
