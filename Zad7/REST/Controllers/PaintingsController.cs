using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ArtDB;
using ArtLibrary;

namespace REST.Controllers
{
    public class PaintingsController : ApiController
    {
        private IPaintingsRepository db;
        // GET: api/Paintings
        public IEnumerable<Painting> Get()
        {
            return db.GetAll();
        }

        // GET: api/Paintings/5
        public Painting Get(int id)
        {
            return db.Get(id);
        }

        // POST: api/Paintings
        public void Post([FromBody]Painting value)
        {
            db.Add(value);
        }

        // PUT: api/Paintings/5
        public void Put(int id, [FromBody]Painting value)
        {
            db.Update(value);
        }

        // DELETE: api/Paintings/5
        public void Delete(int id)
        {
            db.Delete(id);
        }
    }
}
