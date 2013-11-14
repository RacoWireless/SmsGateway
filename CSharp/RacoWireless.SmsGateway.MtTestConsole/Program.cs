using RacoWireless.SmsGateway.Core;
using System;

namespace RacoWireless.SmsGateway.MtTestConsole
{
    class Program
    {


        static void Main(string[] args)
        {
            Console.WriteLine("This system will send an SMS message to a cellular device powered by RACO Wireless");
            
            
            Console.WriteLine("Please enter the destination MSISDN (phone number).");
            var phoneNumber = Console.ReadLine();
            Console.WriteLine("Please enter the message you'd like to send. (max 160 characters)");
            var message = Console.ReadLine();

            var messageSender = new MtMessageSender();
            var messageViaGetResponse = messageSender.SendMessageViaGet(phoneNumber, message);
            var messageViaPostResponse = messageSender.SendMessageViaPost(phoneNumber, message);
        }
    }
}
