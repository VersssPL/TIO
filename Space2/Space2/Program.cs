using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

/* Michał Majtyka - lab2 */

namespace Space2
{
    class Program
    {
        static void Main(string[] args)
        {
            Uri address = new Uri("http://localhost:8000/BlackHole");
            ServiceHost selfHost = new ServiceHost(typeof(BlackHole), address);

            try
            {
                selfHost.AddServiceEndpoint(typeof(IBlackHole), new WSHttpBinding(), "ServiceEndpoint");
                ServiceMetadataBehavior smd = new ServiceMetadataBehavior();
                smd.HttpGetEnabled = true;
                selfHost.Description.Behaviors.Add(smd);

                selfHost.Open();
                Console.WriteLine("Service is running!");
                Console.ReadLine();

                selfHost.Close();
            }
            catch (CommunicationException)
            {
                Console.WriteLine("Connectivity problem...");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
                selfHost.Abort();
            }
        }


    }

    [DataContract]
    public class Person
    {

        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public int Age { get; set; }

    }

    [DataContract]
    public class Starship
    {

        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public Person Captain { get; set; }
        [DataMember]
        public List<Person> Crew { get; set; }
    }

    [DataContract]
    public class Planet
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public int Mass { get; set; }
    }

    [ServiceContract]
    public interface IBlackHole
    {
        [OperationContract]
        Starship PullStarship(Starship ship);
        [OperationContract]
        string UltimateAnswer();
    }

    class BlackHole : IBlackHole
    {
        public Starship PullStarship(Starship ship)
        {
            if (ship.Captain.Age <= 40)
            {
                foreach (var person in ship.Crew)
                    person.Age += 20;
            }
            return ship;
        }
        public string UltimateAnswer()
        {
            return (42.ToString());
        }

    }
}