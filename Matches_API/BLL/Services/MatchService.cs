using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Matches_API.BLL.Converters;
using Matches_API.BLL.Interfaces;
using Matches_API.BLL.Models;
using Matches_API.DAL.EF;
using Matches_API.DAL.Models;

namespace Matches_API.BLL.Services
{
    public class MatchService : IService<Match, MatchModel>
    {
        private readonly MatchesDbContext _dbContext;
        private readonly IModelEtityConverter<MatchModel, Match> _converter;

        public MatchService() 
        {
            _dbContext = new MatchesDbContext();
            _converter = new MatchConverter();
        }
        public IEnumerable<MatchModel> Get()
        {
           // Expression<Func<Match, MatchModel>> ex = s => _converter.GetModelByEntity(s);
            var matches = _dbContext.Matches.AsNoTracking().ToList().Select(x => _converter.GetModelByEntity(x));
            return matches;
        }

        public IEnumerable<MatchModel> Get(Func<Match, bool> predicate)
        {
            var matches = _dbContext.Matches.AsNoTracking().Where(predicate).ToList().Select(x => _converter.GetModelByEntity(x));
            return matches;
        }

        public MatchModel FindById(int id)
        {
            var match = _dbContext.Matches.Find(id);
            return _converter.GetModelByEntity(match);
        }

        public Match Create(MatchModel item)
        {
            var match = _converter.GetEntityByModel(item);
            _dbContext.Matches.Add(match);
            _dbContext.SaveChanges();
            return match;
        }

        public MatchModel Delete(MatchModel item)
        {
            throw new NotImplementedException();
        }

        public MatchModel Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}