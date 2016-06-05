using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamingStoreDTO
{
    public class GamesInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<GamesContext>
    {
        protected override void Seed(GamesContext context)
        {
            var games = new List<Game>
            {
                new Game() { Title = "Osadnicy z Catanu", CreatorCompany = "FunFacts", Year = 1994, AgeRate = 3 },
                new Game() { Title = "Game of Thrones", CreatorCompany = "Toys", Year = 2016, AgeRate = 12 },
                new Game() { Title = "Party Time", CreatorCompany = "TeenagePlay", Year = 2005, AgeRate = 18 },
                new Game() { Title = "Kolejka", CreatorCompany = "Trefl", Year = 2008, AgeRate = 12 },
                new Game() { Title = "Chińczyk", CreatorCompany = "KidsWorld", Year = 2003, AgeRate = 16 }
            };
            games.ForEach(g => context.Games.Add(g));
            context.SaveChanges();

            var stores = new List<Store>
            {
                new Store() { Name = "Sklep a", Address = "Czarnowiejska"},
                new Store() { Name = "Sklep b", Address = "Lea"},
                new Store() { Name = "Sklep c", Address = "Ofiar Dabia"},
                new Store() { Name = "Sklep d", Address = "Reymonta"},
                new Store() { Name = "Sklep e", Address = "Warszawska"}
            };
            stores.ForEach(s => context.Stores.Add(s));
            context.SaveChanges();
        }
    }
}
