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
    public class CandidateService : IService<Candidate, CandidateModel>
    {
        private MatchesDbContext _dbContext;
        private IModelEtityConverter<CandidateModel, Candidate> _converter;

        public CandidateService()
        {
            _dbContext = new MatchesDbContext();
            _converter = new CandidateConverter();
        }
        public IEnumerable<CandidateModel> Get()
        {
            return _dbContext.Candidates.AsNoTracking().ToList().Select(x => _converter.GetModelByEntity(x));
        }

        public IEnumerable<CandidateModel> Get(Func<Candidate, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public CandidateModel FindById(int id)
        {
            throw new NotImplementedException();
        }

        public Candidate Create(CandidateModel item)
        {
            var newUser = new Candidate
            {
                Age = item.Age,
                FirstName = item.FirstName,
                LastName = item.LastName
            };
            _dbContext.Candidates.Add(newUser);
            _dbContext.SaveChanges();
            return newUser;
        }

        public CandidateModel Delete(CandidateModel item)
        {
            var user = _converter.GetEntityByModel(item);
            _dbContext.Candidates.Remove(user);
            _dbContext.SaveChanges();
            return item;
        }

        public CandidateModel Delete(int id)
        {
            var user = _dbContext.Candidates.Find(id);
            _dbContext.Candidates.Remove(user);
            _dbContext.SaveChanges();
            return _converter.GetModelByEntity(user);
        }

        public Candidate Done(CandidateModel model)
        {
            var user = _dbContext.Candidates.Find(model.Id);
            user.Done = model.Done;
            _dbContext.SaveChanges();
            return user;
        }
    }
}