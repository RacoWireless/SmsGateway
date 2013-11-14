using RacoWireless.SmsGateway.Core;
using System;
using System.Threading.Tasks;

namespace RacoWireless.SmsGateway.MoTestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Polling RACO Wireless SMS gateway for new messages");

            var t = Task.Factory.StartNew(() =>
            {
                var messageReceiver = new MoMessageReceiver();
                messageReceiver.PollMessages();
            });

            Console.WriteLine("Press enter to exit");
            Console.ReadLine();
        }
    }
}
