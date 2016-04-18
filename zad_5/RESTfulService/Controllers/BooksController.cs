using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LibraryBookAuthor;
using BooksDBActions;

namespace RESTfulService.Controllers
{
    public class BooksController : ApiController
    {
        // GET: api/Books
        public IEnumerable<Book> Get()
        {
            BooksRepository booksRepo = new BooksRepository();
            return booksRepo.GetAll();
        }

        // GET: api/Books?search=bookTitle
        public IEnumerable<Book> Get([FromUri]string search)
        {
            BooksRepository booksRepo = new BooksRepository();
            return booksRepo.GetAll().Where(x => x.BookTitle.Contains(search));
        }

        // GET: api/Books/5
        public Book Get(int id)
        {
            BooksRepository booksRepo = new BooksRepository();
            return booksRepo.Get(id);
        }

        // POST: api/Books
        public int Post([FromBody]Book book)
        {
            BooksRepository booksRepo = new BooksRepository();
            return booksRepo.Add(book);
        }

        // PUT: api/Books/5
        public Book Put(int id, [FromBody]Book book)
        {
            BooksRepository booksRepo = new BooksRepository();
            book.Id = id;
            return booksRepo.Update(book);
        }

        // DELETE: api/Books/5
        public bool Delete(int id)
        {
            BooksRepository booksRepo = new BooksRepository();
            return booksRepo.Delete(id);
        }
    }
}
