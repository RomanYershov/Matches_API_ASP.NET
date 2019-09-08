using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Matches_API.DAL.Models;

namespace Matches_API.BLL.Models
{
    public class MatchModel : ModelBase
    {
        //public ICollection<Team> Teams { get; set; }   
        public Team TeamOne { get; set; }   
        public Team TeamTwo { get; set; }   
        public League League { get; set; }
        public DateTime DateTime { get; set; }
    }
}