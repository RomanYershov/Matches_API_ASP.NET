using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Matches_API.BLL.Interfaces;
using Matches_API.BLL.Models;
using Matches_API.DAL.Models;

namespace Matches_API.BLL.Services
{
    public class ServiceContainer
    {
        public MatchService MatchService { get; set; }
        public TeamService TeamService { get; set; }
        public LeagueService LeagueService { get; set; }
        public CandidateService UserService { get; set; }

        public ServiceContainer()
        {
            MatchService = new MatchService();
            TeamService = new TeamService();
            LeagueService = new LeagueService();
            UserService = new CandidateService();
        }

       
    }
}