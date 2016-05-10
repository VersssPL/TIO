using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArtLibrary;
using LiteDB;

namespace ArtDB
{
    public class ArtistsRepositoryLiteDB : IArtistsRepository
    {
        string _artistsConnection = @"C:\tmp\paintings";

        public int Add(Artist artist)
        {
            using (var db = new LiteDatabase(this._artistsConnection))
            {
                var dbObject = artist;
                var repository = db.GetCollection<Artist>("artists");
                if (repository.FindById(artist.Id) != null)
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
            using (var db = new LiteDatabase(this._artistsConnection))
            {
                var repository = db.GetCollection<Artist>("artists");
                return repository.Delete(id);
            }
        }

        public Artist Get(int id)
        {
            using (var db = new LiteDatabase(this._artistsConnection))
            {
                var repository = db.GetCollection<Artist>("artists");
                var result = repository.FindById(id);
                return result;
            }
        }

        public List<Artist> GetAll()
        {
            using (var db = new LiteDatabase(this._artistsConnection))
            {
                var repository = db.GetCollection<Artist>("artists");
                var results = repository.FindAll();
                return results.ToList();
            }
        }

        public Artist Update(Artist artist)
        {
            using (var db = new LiteDatabase(this._artistsConnection))
            {
                var repository = db.GetCollection<Artist>("artists");
                var results = repository.FindAll();
                var dbObject = artist;
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
