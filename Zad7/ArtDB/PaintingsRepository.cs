using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArtLibrary;
using System.Data.Entity;

namespace ArtDB
{
    class PaintingsRepository : IPaintingsRepository
    {
        private MuseumContext dbContext = new MuseumContext();

        public List<Painting> GetAll()
        {
            List<Painting> paintings = new List<Painting>();

            foreach (var painting in dbContext.Paintings)
            {
                paintings.Add(painting);
            }

            return paintings;
        }

        public int Add(Painting painting)
        {
            int id = dbContext.Paintings.Add(painting).Id;
            dbContext.SaveChanges();
            return id;
        }

        public Painting Get(int id)
        {
            return dbContext.Paintings.Find(id);
        }

        public Painting Update(Painting painting)
        {
            dbContext.Entry(painting).State = EntityState.Modified;
            dbContext.SaveChanges();
            return painting;
        }

        public bool Delete(int id)
        {
            try
            {
                dbContext.Paintings.Remove(dbContext.Paintings.Find(id));
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
