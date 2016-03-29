using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CosmicAdventureDTO;

namespace Service1
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public class Service1 
    {
        private List<SpaceSystem> _systems = new List<SpaceSystem>();

        public void InitializeGame()
        {
            string[] spaceSystemsNames = { "1", "2", "3", "4" };
            Random r = new Random();
            for (int i = 0; i < 4; ++i)
            {
                string name = spaceSystemsNames[i];
                int minShipPower = r.Next(10, 40);
                int baseDistance = r.Next(20, 120);
                int gold = r.Next(3000, 7000);
                SpaceSystem spaceSystem = new SpaceSystem(name, minShipPower, baseDistance, gold);
                _systems.Add(spaceSystem);
            }
        }

        public Starship SendStarship(Starship starship, string systemName)
        {
            SpaceSystem spaceSystem = _systems.Find((SpaceSystem ss) => { return ss.Name == systemName; });
            if (spaceSystem != null)
            {
                foreach (Person person in starship.Crew)
                {
                    if (starship.ShipPower <= 20)
                    {
                        person.Age += (2 * spaceSystem.BaseDistance) / 12;
                    }
                    else if (starship.ShipPower > 20 && starship.ShipPower <= 30)
                    {

                        person.Age += (2 * spaceSystem.BaseDistance) / 6;
                    }
                    else if (starship.ShipPower > 30)
                    {

                        person.Age += (2 * spaceSystem.BaseDistance) / 4;
                    }

                    if (person.Age > 90)
                    {
                        starship.Crew.Remove(person);
                    }
                }

                if (starship.ShipPower >= spaceSystem.MinShipPower)
                {
                    starship.Gold += spaceSystem.Gold;
                    _systems.Remove(spaceSystem);
                }
            }
            else
            {
                starship.Crew.Clear();
            }
            return starship;
        }

        public SpaceSystem GetSystem()
        {
            return _systems.First();
        }

        public Starship GetStarship(int money)
        {
            Random r = new Random();
            List<Person> crew = new List<Person>();
            int gold = 0;
            int shipPower = 0;

            if (money > 1000 && money <= 3000)
            {
                shipPower = r.Next(10, 25);
                crew.Add(new Person("Janusz", "Gol", 20));
                crew.Add(new Person("Zbigniew", "Boniek", 20));
                crew.Add(new Person("Tomasz", "Adamek", 20));
            }
            else if (money > 3001 && money <= 10000)
            {
                shipPower = r.Next(20, 35);
                crew.Add(new Person("Robert", "Kubica", 20));
                crew.Add(new Person("Marcin", "Wasilewski", 20));
            }
            else if (money > 10000)
            {
                shipPower = r.Next(35, 60);
                crew.Add(new Person("Tomasz", "Podolski", 20));
                crew.Add(new Person("Miroslaw", "Klose", 20));
                crew.Add(new Person("Phil", "Jagielka", 20));
            }

            return new Starship(crew, gold, shipPower);
        }
    }
}
