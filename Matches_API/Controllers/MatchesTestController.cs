﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Matches_API.DAL.EF;
using Matches_API.DAL.Models;

namespace Matches_API.Controllers
{
    public class MatchesTestController : ApiController
    {
        private MatchesDbContext db = new MatchesDbContext();

        // GET: api/MatchesTest
        public IQueryable<Match> GetMatches()
        {
            return db.Matches;
        }

        // GET: api/MatchesTest/5
        [ResponseType(typeof(Match))]
        public IHttpActionResult GetMatch(int id)
        {
            Match match = db.Matches.Find(id);
            if (match == null)
            {
                return NotFound();
            }

            return Ok(match);
        }

        // PUT: api/MatchesTest/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMatch(int id, Match match)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != match.Id)
            {
                return BadRequest();
            }

            db.Entry(match).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MatchExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/MatchesTest
        [ResponseType(typeof(Match))]
        public IHttpActionResult PostMatch(Match match)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Matches.Add(match);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = match.Id }, match);
        }

        // DELETE: api/MatchesTest/5
        [ResponseType(typeof(Match))]
        public IHttpActionResult DeleteMatch(int id)
        {
            Match match = db.Matches.Find(id);
            if (match == null)
            {
                return NotFound();
            }

            db.Matches.Remove(match);
            db.SaveChanges();

            return Ok(match);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MatchExists(int id)
        {
            return db.Matches.Count(e => e.Id == id) > 0;
        }
    }
}