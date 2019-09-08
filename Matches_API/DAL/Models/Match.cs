using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Matches_API.DAL.Models
{
    public class Match : Entity 
    {
        public DateTime DateTime { get; set; }
        public int LeagueId { get; set; }   
        public virtual League League { get; set; }
        public virtual List<Team> Teams{ get; set; }
        public Match() => Teams = new List<Team>(2);
    }
}