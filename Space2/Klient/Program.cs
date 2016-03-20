using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Klient.ServiceReference1;

/* Michał Majtyka - lab2 */

namespace Klient
{
    class Program
    {
        static void Main(string[] args)
        {
            BlackHoleClient BlackHoleClient = new BlackHoleClient();

            Person kapitan = new Person() { Name = "Kapitan Hak", Age = 40 };
            Person[] zaloga = new Person[] { new Person() { Name = "Piotrus Pan", Age = 18 }, new Person() { Name = "Wendy", Age = 18 }, new Person() { Name = "Pan Smee", Age = 60 }, new Person() { Name = "Jas", Age = 10 }, new Person() { Name = "Krokodyl", Age = 10 } };
            Starship ship = new Starship() { Name = "Statek", Captain = kapitan, Crew = zaloga };

            Console.WriteLine("Załoga statku:");
            PresentCrew(ship);
            Console.WriteLine();

            Console.WriteLine("Ultimate answer: " + BlackHoleClient.UltimateAnswer());
            Console.WriteLine();

            Console.WriteLine("Załoga statku po kontakcie z czarną dziurą:");
            PresentCrew(BlackHoleClient.PullStarship(ship));

            Console.ReadKey();
        }

        static void PresentCrew(Starship ship)
        {
            Console.WriteLine("Kapitan: " + ship.Captain.Name + " (" + ship.Captain.Age + " lat)");
            foreach (var person in ship.Crew)
            {
                Console.WriteLine(person.Name + " (" + person.Age + " lat)");
            }
        }
    }
}