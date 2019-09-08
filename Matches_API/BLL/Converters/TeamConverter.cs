using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Matches_API.BLL.Interfaces;
using Matches_API.BLL.Models;
using Matches_API.DAL.Models;

namespace Matches_API.BLL.Converters
{
    public class TeamConverter : IModelEtityConverter<TeamModel, Team>
    {
        public TeamModel GetModelByEntity(Team entity)
        {
            return new TeamModel
            {
                Id = entity.Id,
                Name = entity.Name
            };
        }

        public Team GetEntityByModel(TeamModel model)
        {
            throw new NotImplementedException();
        }
    }
}