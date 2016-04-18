using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiteDB;
using LibraryBookAuthor;

namespace AuthorsDBActions
{
    public class AuthorsRepository : IAuthorsRepository
    {
        private readonly string _authorsConnection = @"C:\tmp\authors";

        public List<Author> GetAll()
        {
            using (var db = new LiteDatabase(this._authorsConnection))
            {
                var repository = db.GetCollection<Author>("authors");
                var results = repository.FindAll();
                return results.ToList();
            }
        }

        public int Add(Author author)
        {
            using (var db = new LiteDatabase(this._authorsConnection))
            {
                var dbObject = author;
                var repository = db.GetCollection<Author>("authors");
                if (repository.FindById(author.Id) != null)
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

        public Author Get(int id)
        {
            using (var db = new LiteDatabase(this._authorsConnection))
            {
                var repository = db.GetCollection<Author>("authors");
                var result = repository.FindById(id);
                return result;
            }
        }

        public Author Update(Author author)
        {
            using (var db = new LiteDatabase(this._authorsConnection))
            {
                var repository = db.GetCollection<Author>("authors");
                var dbObject = author;
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

        public bool Delete(int id)
        {
            using (var db = new LiteDatabase(this._authorsConnection))
            {
                var repository = db.GetCollection<Author>("authors");
                return repository.Delete(id);
            }
        }

    }
}
