using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Matches_API.DAL.Models;

namespace Matches_API.BLL.Models
{
    public abstract class ModelBase
    {
        public int Id { get; set; }
    }
}