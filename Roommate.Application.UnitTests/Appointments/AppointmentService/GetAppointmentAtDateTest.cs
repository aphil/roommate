using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Roommate.Business.Appointments;
using Roommate.Repository.Appointments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roommate.Application.UnitTests.Appointments.AppointmentService
{
    [TestClass]
    public class GetAppointmentAtDateTest
    {
        [TestMethod]
        public void When_AppointmentsExist_Then_AppointmentsAreReturned()
        {
            Mock<IAppointmentRepository> appointmentRepositoryMock = new Mock<IAppointmentRepository>();
            appointmentRepositoryMock.Setup(x => x.GetOccuringAtDate(It.IsAny<DateTime>())).Returns(
                new AppointmentEntity("Test", DateTime.Now.AddMinutes(-10), DateTime.Now.AddMinutes(30))
            );

            Shared.Appointments.IAppointmentService appointmentService = new Application.Appointments.AppointmentService(appointmentRepositoryMock.Object);
            var appointment = appointmentService.GetOccuringAppointmentAtDate(DateTime.Now);

            Assert.IsNotNull(appointment);
        }
    }
}
