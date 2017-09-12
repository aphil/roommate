using Roommate.Application.Appointment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Roommate.Background.ConsoleHost
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost svcHost = null;
            try
            {
                svcHost = new ServiceHost(typeof(AppointmentService));
                svcHost.Open(); Console.WriteLine("\n\nService is Running  at following address");
                Console.WriteLine("net.tcp://localhost:9001/AppointmentService");
            }
            catch (Exception eX)
            {
                svcHost = null;
                Console.WriteLine("Service can not be started \n\nError Message [" + eX.Message + "]");
                Console.ReadKey();
            }
            if (svcHost != null)
            {
                Console.WriteLine("\nPress any key to close the Service");
                Console.ReadKey();
                svcHost.Close();
                svcHost = null;
            }
        }
    }
}
