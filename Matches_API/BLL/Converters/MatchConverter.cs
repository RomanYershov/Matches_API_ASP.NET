using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Matches_API.BLL.Interfaces;
using Matches_API.BLL.Models;
using Matches_API.DAL.Models;

namespace Matches_API.BLL.Converters
{
    public class MatchConverter : IModelEtityConverter<MatchModel, Match>
    {
        public MatchModel GetModelByEntity(Match entity)
        {
            var model = new MatchModel
            {
                Id = entity.Id,
                League = entity.League,
                DateTime = entity.DateTime,
                TeamOne = new Team { Id = entity.Teams.ElementAt(0).Id, Name = entity.Teams.ElementAt(0).Name },
                TeamTwo = new Team { Id = entity.Teams.ElementAt(1).Id, Name = entity.Teams.ElementAt(1).Name }
            };
            return model;
        }

        public Match GetEntityByModel(MatchModel model)
        {
            var entity = new Match
            {
                Id = model.Id,
                DateTime = model.DateTime,
                LeagueId = model.League.Id
            };
            var listTeams = new List<Team>();
            listTeams.Add(model.TeamOne);
            listTeams.Add(model.TeamTwo);
            entity.Teams = listTeams;
            return entity;
        }
    }
}