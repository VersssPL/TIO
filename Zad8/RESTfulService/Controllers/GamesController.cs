﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.OData;
using System.Web.Http.OData.Routing;
using GamingStoreDTO;

namespace RESTfulService.Controllers
{
    public class GamesController : ODataController
    {
        private GamesContext db = new GamesContext();

        // GET: odata/Games
        [EnableQuery]
        public IQueryable<Game> GetGames()
        {
            return db.Games;
        }

        // GET: odata/Games(5)
        [EnableQuery]
        public SingleResult<Game> GetGame([FromODataUri] int key)
        {
            return SingleResult.Create(db.Games.Where(game => game.Id == key));
        }

        // PUT: odata/Games(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<Game> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Game game = db.Games.Find(key);
            if (game == null)
            {
                return NotFound();
            }

            patch.Put(game);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GameExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(game);
        }

        // POST: odata/Games
        public IHttpActionResult Post(Game game)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Games.Add(game);
            db.SaveChanges();

            return Created(game);
        }

        // DELETE: odata/Games(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            Game game = db.Games.Find(key);
            if (game == null)
            {
                return NotFound();
            }

            db.Games.Remove(game);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GameExists(int key)
        {
            return db.Games.Count(e => e.Id == key) > 0;
        }
    }
}
