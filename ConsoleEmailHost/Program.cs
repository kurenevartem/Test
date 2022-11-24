using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using EmailService;

namespace ConsoleEmailHost
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost host = new ServiceHost(typeof(EmailService.EmailService)))
            {
                Console.WriteLine("Host Started....");
                host.Open();
                Console.ReadLine();
            }
        }
    }
}