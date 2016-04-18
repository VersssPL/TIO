using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LibraryBookAuthor;
using AuthorsDBActions;

namespace RESTfulService.Controllers
{
    public class AuthorsController : ApiController
    {
        // GET: api/Authors
        public IEnumerable<Author> Get()
        {
            AuthorsRepository authorsRepo = new AuthorsRepository();
            return authorsRepo.GetAll();
        }

        // GET: api/Authors/5
        public Author Get(int id)
        {
            AuthorsRepository authorsRepo = new AuthorsRepository();
            return authorsRepo.Get(id);
        }

        // POST: api/Authors
        public int Post([FromBody]Author author)
        {
            AuthorsRepository authorsRepo = new AuthorsRepository();
            return authorsRepo.Add(author);
        }

        // PUT: api/Authors/5
        public Author Put(int id, [FromBody]Author author)
        {
            AuthorsRepository authorsRepo = new AuthorsRepository();
            author.Id = id;
            return authorsRepo.Update(author);
        }

        // DELETE: api/Authors/5
        public bool Delete(int id)
        {
            AuthorsRepository authorsRepo = new AuthorsRepository();
            return authorsRepo.Delete(id);
        }
    }
}
