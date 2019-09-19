using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Matches_API.BLL.Interfaces;
using Matches_API.BLL.Models;
using Matches_API.DAL.Models;

namespace Matches_API.BLL.Converters
{
    public class CandidateConverter : IModelEtityConverter<CandidateModel, Candidate>
    {
        public CandidateModel GetModelByEntity(Candidate entity)
        {
            return new CandidateModel
            {
                Done = entity.Done,
                LastName = entity.LastName,
                FirstName = entity.FirstName,
                Age = entity.Age,
                Id = entity.Id
            };
        }

        public Candidate GetEntityByModel(CandidateModel model)
        {
            return new Candidate
            {
                Id = model.Id,
                Done = model.Done,
                LastName = model.LastName,
                FirstName = model.FirstName,
                Age = model.Age
            };
        }
    }
}