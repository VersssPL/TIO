using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArtLibrary;
using LiteDB;

namespace ArtDB
{
    public class PaintingsRepositoryLiteDB : IPaintingsRepository
    {
        string _paintingsConnection = @"C:\tmp\paintings";

        public int Add(Painting painting)
        {
            using (var db = new LiteDatabase(this._paintingsConnection))
            {
                var dbObject = painting;
                var repository = db.GetCollection<Painting>("paintings");
                if (repository.FindById(painting.Id) != null)
                {
                    repository.Update(dbObject);
                }
                else
                {
                    repository.Insert(dbObject);
                }

                return dbObject.Id;
            }
        }

        public bool Delete(int id)
        {
            using (var db = new LiteDatabase(this._paintingsConnection))
            {
                var repository = db.GetCollection<Painting>("paintings");
                return repository.Delete(id);
            }
        }

        public Painting Get(int id)
        {
            using (var db = new LiteDatabase(this._paintingsConnection))
            {
                var repository = db.GetCollection<Painting>("paintings");
                var result = repository.FindById(id);
                return result;
            }
        }

        public List<Painting> GetAll()
        {
            using (var db = new LiteDatabase(this._paintingsConnection))
            {
                var repository = db.GetCollection<Painting>("paintings");
                var results = repository.FindAll();
                return results.ToList();
            }
        }

        public Painting Update(Painting painting)
        {
            using (var db = new LiteDatabase(this._paintingsConnection))
            {
                var repository = db.GetCollection<Painting>("paintings");
                var results = repository.FindAll();
                var dbObject = painting;
                if (repository.Update(dbObject))
                {
                    return dbObject;
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
