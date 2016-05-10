using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArtLibrary;

namespace ArtDB
{
    class MuseumInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<MuseumContext>
    {
        protected override void Seed(MuseumContext context)
        {
            var paintings = new List<Painting>
            {
                new Painting() {Title = "La persistencia de la memoria", Year = 1995},
                new Painting() {Title = "Sunflowers", Year = 2016},

            };
            paintings.ForEach(p => context.Paintings.Add(p));
            context.SaveChanges();

            var artists = new List<Artist>()
            {
                new Artist() {ArtistName = "Salvador", ArtistSurname = "Dali"},
                new Artist() {ArtistName= "Vincent", ArtistSurname = "Van Gogh"}
            };
            artists.ForEach(a => context.Artists.Add(a));
            context.SaveChanges();
        }
    }
}
