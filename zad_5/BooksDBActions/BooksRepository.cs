using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryBookAuthor;
using LiteDB;

namespace BooksDBActions
{
    public class BooksRepository : IBooksRepository
    {
        private readonly string _booksConnection = @"C:\tmp\books";

        public List<Book> GetAll()
        {
            using (var db = new LiteDatabase(this._booksConnection))
            {
                var repository = db.GetCollection<Book>("books");
                var results = repository.FindAll();
                return results.ToList();
            }
        }

        public int Add(Book book)
        {
            using (var db = new LiteDatabase(this._booksConnection))
            {
                var dbObject = book;
                var repository = db.GetCollection<Book>("books");
                if (repository.FindById(book.Id) != null)
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

        public Book Get(int id)
        {
            using (var db = new LiteDatabase(this._booksConnection))
            {
                var repository = db.GetCollection<Book>("books");
                var result = repository.FindById(id);
                return result;
            }
        }

        public Book Update(Book book)
        {
            using (var db = new LiteDatabase(this._booksConnection))
            {
                var repository = db.GetCollection<Book>("books");
                var dbObject = book;
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
            using (var db = new LiteDatabase(this._booksConnection))
            {
                var repository = db.GetCollection<Book>("books");
                return repository.Delete(id);
            }
        }
    }
}
