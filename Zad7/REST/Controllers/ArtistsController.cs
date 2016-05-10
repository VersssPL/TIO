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
    public class ArtistsController : ApiController
    {
        private IArtistsRepository db;
        // GET: api/Artists
        public IEnumerable<Artist> Get()
        {
            return db.GetAll();
        }

        // GET: api/Artists/5
        public Artist Get(int id)
        {
            return db.Get(id);
        }

        // POST: api/Artists
        public void Post([FromBody]Artist value)
        {
            db.Add(value);
        }

        // PUT: api/Artists/5
        public void Put(int id, [FromBody]Artist value)
        {
            db.Update(value);
        }

        // DELETE: api/Artists/5
        public void Delete(int id)
        {
            db.Delete(id);
        }
    }
}
