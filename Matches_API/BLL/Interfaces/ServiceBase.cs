using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Matches_API.BLL.Models;
using Matches_API.DAL.EF;
using Matches_API.DAL.Models;

namespace Matches_API.BLL.Interfaces
{
    public abstract class ServiceBase
    {
        protected ServiceBase()
        {
            DbContext = new MatchesDbContext();
        }
        public MatchesDbContext DbContext { get; set; }
        public abstract IEnumerable<ModelBase> Get();
        public abstract IEnumerable<ModelBase> Get(Func<Entity, Boolean> predicate);
        public abstract ModelBase FindById(int id);
        public abstract ModelBase Create(ModelBase model);
        public abstract ModelBase Delete(ModelBase model);
        public abstract ModelBase Delete(int id);
        public abstract void Update(ModelBase model);

    }
}