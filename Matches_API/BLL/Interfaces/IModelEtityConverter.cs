using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Matches_API.BLL.Models;
using Matches_API.DAL.Models;

namespace Matches_API.BLL.Interfaces
{
    public interface IModelEtityConverter<TM,TE>
    {
        TM GetModelByEntity(TE entity);
        TE GetEntityByModel(TM model);
    }
}
