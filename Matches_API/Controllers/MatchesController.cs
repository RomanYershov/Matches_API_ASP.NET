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
        private readonly ServiceContainer _serviceContainer;


        // public MatchesController()  { }
        public MatchesController()
        {
            _serviceContainer = new ServiceContainer();
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
                model = _serviceContainer.MatchService.Get();
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
                model = _serviceContainer.MatchService.FindById(id);
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
            var teams = _serviceContainer.TeamService.Get();
            return SimpleResponse.Success(teams);
        }
        [HttpGet]
        [Route("api/getleagues")]
        public SimpleResponse GetLeagues()
        {
            var leagues = _serviceContainer.LeagueService.Get();
            return SimpleResponse.Success(leagues);
        }

        [HttpGet]
        [Route("api/getcandidates")]
        public SimpleResponse GetCandidates()
        {
            var result = BaseServiceExecute.Get(new CandidateService());
            return SimpleResponse.Success(result);
        }
        [HttpPost]
        [Route("api/user/done")]
        public SimpleResponse Done(CandidateModel candidate)
        {
            ModelBase user;
            try
            {
                user = BaseServiceExecute.Done(new CandidateService(), candidate);
            }
            catch (Exception e)
            {
                return SimpleResponse.Error($"{e.Message}\n{e.StackTrace}");
            }
            return SimpleResponse.Success(user);
        }
        [HttpPost]
        [Route("api/user/create")]
        public SimpleResponse CreateCandidate(CandidateModel model)
        {
            //var result = _serviceContainer.UserService.Create(model);
            var newModel = BaseServiceExecute.Create(new CandidateService(), model);
            return SimpleResponse.Success(newModel);
        }

        [HttpDelete]
        [Route("api/user/delete/{id}")]
        public SimpleResponse RemoveUser(int id)
        {
            ModelBase model;
            try
            {
                model = BaseServiceExecute.Delete(new CandidateService(), id);
            }
            catch (Exception e)
            {
                return SimpleResponse.Error(e.StackTrace);
            }
            return SimpleResponse.Success(model);
        }
       
        public SimpleResponse PostMatch(MatchModel model)
        {
            Match newMatch;
            try
            {
                newMatch = _serviceContainer.MatchService.Create(model);
            }
            catch (Exception e)
            {
                return SimpleResponse.Error(e.Message + "\t" + e.StackTrace);
            }
            return SimpleResponse.Success(new { Id = newMatch.Id, DateTime = newMatch.DateTime, LeagueId = newMatch.LeagueId });
        }




      
    }
}