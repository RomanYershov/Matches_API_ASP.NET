using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Matches_API.BLL.Interfaces;
using Matches_API.BLL.Models;
using Matches_API.DAL.Models;

namespace Matches_API.BLL.Converters
{
    public class LeagueConverter : IModelEtityConverter<LeagueModel,League>
    
    {
        public LeagueModel GetModelByEntity(League entity)
        {
            return new LeagueModel {Id = entity.Id, Name = entity.Name};
        }

        public League GetEntityByModel(LeagueModel model)
        {
            throw new NotImplementedException();
        }
    }
}