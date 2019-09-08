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
    public class LeagueService : IService<League, LeagueModel>
    {
        private MatchesDbContext _dbContext;
        private IModelEtityConverter<LeagueModel, League> _converter;
       public  LeagueService()
        {
            _dbContext = new MatchesDbContext();
            _converter = new LeagueConverter();
        }
        public IEnumerable<LeagueModel> Get()
        {
            return _dbContext.Leagues.AsNoTracking().ToList().Select(x => _converter.GetModelByEntity(x));
        }

        public IEnumerable<LeagueModel> Get(Func<League, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public LeagueModel FindById(int id)
        {
            throw new NotImplementedException();
        }

        public League Create(LeagueModel item)
        {
            throw new NotImplementedException();
        }
    }
}