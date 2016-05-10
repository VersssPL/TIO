using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArtLibrary;
using System.Data.Entity;

namespace ArtDB
{
    class ArtistsRepository : IArtistsRepository
    {
        private MuseumContext dbContext = new MuseumContext();

        public List<Artist> GetAll()
        {
            List<Artist> artists = new List<Artist>();

            foreach (var artist in dbContext.Artists)
            {
                artists.Add(artist);
            }

            return artists;
        }

        public int Add(Artist artist)
        {
           int id = dbContext.Artists.Add(artist).Id;
           dbContext.SaveChanges();
           return id;
        }

        public Artist Get(int id)
        {
            return dbContext.Artists.Find(id);

        }

        public Artist Update(Artist artist)
        {
            dbContext.Entry(artist).State = EntityState.Modified;
            dbContext.SaveChanges();
            return artist;
        }

        public bool Delete(int id)
        {
            try
            {
                dbContext.Artists.Remove(dbContext.Artists.Find(id));
                dbContext.SaveChanges();
            }
            catch
            {
                return false;
            }

            return true;

        }
    }
}
