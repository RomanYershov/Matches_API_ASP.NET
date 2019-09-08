using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Filters;
using Matches_API.BLL.Helpers;
using Matches_API.BLL.Interfaces;
using Matches_API.BLL.Models;
using Matches_API.BLL.Services;
using Matches_API.DAL.EF;
using Matches_API.DAL.Models;
using Newtonsoft.Json;


namespace Matches_API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class MatchesController : ApiController
    {
       // private MatchesDbContext db = new MatchesDbContext();
        private IService<Match, MatchModel> _service;

        private IService<Team, TeamModel> _teamService;

        private IService<League, LeagueModel> _leagueService;
       // public MatchesController()  { }
        public MatchesController()
        {
            _service = new MatchService();
            _teamService = new TeamService();
            _leagueService = new LeagueService();
        }

        // GET: api/Matches
        public SimpleResponse GetMatches()
        {
            //var options = new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore };
            //var context = new MatchesDbContext();
            //var matches = context.Matches.ToList();
            //return Json(matches, options);
            IEnumerable<MatchModel> model;
            try
            {
                model = _service.Get();
            }
            catch (Exception e)
            {
                return SimpleResponse.Error(e.StackTrace);
            }
            return SimpleResponse.Success(model);
        }


        public SimpleResponse GetMatches(int id)
        {
            MatchModel model;
            try
            {
                model = _service.FindById(id);
            }
            catch (Exception e)
            {
                return SimpleResponse.Error(e.StackTrace);
            }
            return SimpleResponse.Success(model);
        }
        [HttpGet]
        [Route("api/getteams")]
        public SimpleResponse GetTeams()
        {
            var teams = _teamService.Get();
            return SimpleResponse.Success(teams);
        }
        [HttpGet]
        [Route("api/getleagues")]
        public SimpleResponse GetLeagues()
        {
            var leagues = _leagueService.Get();
            return SimpleResponse.Success(leagues);
        }
        // GET: api/Matches/5
        //[ResponseType(typeof(Match))]
        //public async Task<IHttpActionResult> GetMatch(int id)
        //{
        //    Match match = await db.Matches.FindAsync(id);
        //    if (match == null)
        //    {
        //        return NotFound();
        //    }

        //    //return Ok(match);
        //    return Json(new
        //    {
        //        DateTime = match.DateTime,
        //        Teams = new { TeamId = match.Teams.First().Id, Name = match.Teams.First().Name },
        //        League = match.League
        //    });
        //}

        //// PUT: api/Matches/5
        //[ResponseType(typeof(void))]
        //public async Task<IHttpActionResult> PutMatch(int id, Match match)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != match.Id)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(match).State = EntityState.Modified;

        //    try
        //    {
        //        await db.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!MatchExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        // POST: api/Matches
        //[ResponseType(typeof(Match))]
        //public async Task<IHttpActionResult> PostMatch(Match match)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.Matches.Add(match);
        //    await db.SaveChangesAsync();

        //    return CreatedAtRoute("DefaultApi", new { id = match.Id }, match);
        //}

        public SimpleResponse PostMatch( MatchModel model)
        {
            Match newMatch;
            try
            {
            newMatch =  _service.Create(model);
            }
            catch (Exception e)
            {
               return SimpleResponse.Error(e.Message + "\t"  + e.StackTrace);
            }
            return SimpleResponse.Success(new {Id = newMatch.Id, DateTime = newMatch.DateTime, LeagueId = newMatch.LeagueId});
        }   




        //// DELETE: api/Matches/5
        //[ResponseType(typeof(Match))]
        //public async Task<IHttpActionResult> DeleteMatch(int id)
        //{
        //    Match match = await db.Matches.FindAsync(id);
        //    if (match == null)
        //    {
        //        return NotFound();
        //    }

        //    db.Matches.Remove(match);
        //    await db.SaveChangesAsync();

        //    return Ok(match);
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        //private bool MatchExists(int id)
        //{
        //    return db.Matches.Count(e => e.Id == id) > 0;
        //}
    }
}