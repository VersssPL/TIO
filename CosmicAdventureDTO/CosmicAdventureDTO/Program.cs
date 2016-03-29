using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace CosmicAdventureDTO
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    [DataContractAttribute]
    public class SpaceSystem
    {
        public SpaceSystem(string Name, int MinShipPower, int BaseDistance, int Gold)
        {
            this.Name = Name;
            this.minShipPower = MinShipPower;
            this.BaseDistance = BaseDistance;
            this.gold = Gold;
        }

        [DataMemberAttribute]
        public string Name { get; set; }
        private int minShipPower;
        public int MinShipPower { get { return minShipPower; } }
        [DataMemberAttribute]
        public int BaseDistance { get; set; }
        private int gold { get; set; }
        public int Gold { get { return gold; } }
    }

    [DataContractAttribute]
    public class Starship
    {
        public Starship(List<Person> Crew, int Gold, int ShipPower)
        {
            this.Crew = Crew;
            this.Gold = Gold;
            this.ShipPower = ShipPower;
        }
        [DataMemberAttribute]
        public List<Person> Crew { get; set; }
        [DataMemberAttribute]
        public int Gold { get; set; }
        [DataMemberAttribute]
        public int ShipPower { get; set; }
    }

    public class Person
    {
        public Person(string Name, string Nick, float Age)
        {
            this.Name = Name;
            this.Nick = Nick;
            this.Age = Age;
        }

        public string Name { get; set; }
        public string Nick { get; set; }
        public float Age { get; set; }
    }
}
