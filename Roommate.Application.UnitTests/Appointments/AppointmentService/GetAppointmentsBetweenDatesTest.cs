using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Roommate.Repository.Appointments;
using System.Collections.Generic;
using Roommate.Business.Appointments;

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
            appointmentRepositoryMock.Setup(x => x.GetAppointmentsBetweenDates(It.IsAny<DateTime>(), It.IsAny<DateTime>())).Returns(new List<AppointmentEntity>());

            Shared.Appointments.IAppointmentService appointmentService = new Application.Appointments.AppointmentService(appointmentRepositoryMock.Object);

        }
    }
}
