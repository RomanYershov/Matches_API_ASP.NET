using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Matches_API.BLL.Converters;
using Matches_API.BLL.Interfaces;
using Matches_API.BLL.Models;
using Matches_API.DAL.EF;
using Matches_API.DAL.Models;

namespace Matches_API.BLL.Services
{
    public class TeamService : IService<Team,TeamModel>
    {
        private readonly MatchesDbContext _dbContext;
        private readonly IModelEtityConverter<TeamModel, Team> _converter;

        public TeamService()
        {
            _dbContext = new MatchesDbContext();
            _converter = new  TeamConverter();
        }
        public IEnumerable<TeamModel> Get()
        {
            return _dbContext.Teams.AsNoTracking().ToList().Select(x => _converter.GetModelByEntity(x));
        }

        public IEnumerable<TeamModel> Get(Func<Team, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public TeamModel FindById(int id)
        {
            throw new NotImplementedException();
        }

        public Team Create(TeamModel item)
        {
            throw new NotImplementedException();
        }

        public TeamModel Delete(TeamModel item)
        {
            throw new NotImplementedException();
        }

        public TeamModel Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}