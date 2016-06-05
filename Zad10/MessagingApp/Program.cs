using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MessagesLibrary;
using EasyNetQ;

namespace MessagingApp
{
    class Program
    {
        static private string Nick;
        static void Main(string[] args)
        {
            Console.Write("Enter your nickname: ");
            Nick = Console.ReadLine();
            using (var busSubscriber = RabbitHutch.CreateBus("host=localhost"))
            {
                busSubscriber.Subscribe<Message>(GenerateId(), HandleTextMessage);
                using (var busPublisher = RabbitHutch.CreateBus("host=localhost"))
                {
                    var input = "";
                    Console.WriteLine("Enter a message. 'escape' to escape.");
                    while ((input = Console.ReadLine()) != "escape")
                    {
                        busPublisher.Publish(
                            new Message
                            {
                                Name = Nick,
                                Text = input
                            });
                    }
                }
            }
        }

        static string GenerateId()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, 8)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        static void HandleTextMessage(Message message)
        {
            if (message.Name == Nick)
            {
                return;
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("{0}: {1}", message.Name, message.Text);
            Console.ResetColor();
        }
    }
}
