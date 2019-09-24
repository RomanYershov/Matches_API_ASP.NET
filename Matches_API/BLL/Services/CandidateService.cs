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
    public class CandidateService :  ServiceBase
    {
        private IModelEtityConverter<CandidateModel, Candidate> _converter;

        public CandidateService()
        {
            _converter = new CandidateConverter();
        }
        public override IEnumerable<ModelBase> Get()
        {
            return DbContext.Candidates.AsNoTracking().ToList().Select(x => _converter.GetModelByEntity(x));
        }

        public override IEnumerable<ModelBase> Get(Func<Entity, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public override ModelBase FindById(int id)
        {
            throw new NotImplementedException();
        }

        public override  ModelBase Create(ModelBase item)
        {
            var newUser = _converter.GetEntityByModel(item as CandidateModel);
            DbContext.Candidates.Add(newUser);
            DbContext.SaveChanges();
            item.Id = newUser.Id;
            return item;
        }

        public override ModelBase Delete(ModelBase item)
        {
            var user = _converter.GetEntityByModel(item as CandidateModel);
            DbContext.Candidates.Remove(user);
            DbContext.SaveChanges();
            return item;
        }

        public override ModelBase Delete(int id)
        {
            var user = DbContext.Candidates.Find(id);
            DbContext.Candidates.Remove(user);
            DbContext.SaveChanges();
            return _converter.GetModelByEntity(user);
        }

        public override void Update(ModelBase model)
        {
            
        }

        public ModelBase Done(ModelBase model)
        {
            var user = DbContext.Candidates.Find(model.Id);
            user.Done =((CandidateModel) model).Done;
            DbContext.SaveChanges();
            return model;
        }
    }
}