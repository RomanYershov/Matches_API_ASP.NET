using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Matches_API.DAL.Models
{
    public class Team : Entity
    {
        public string Name { get; set; }
        public  List<Player> Players { get; set; }
        public  List<Match> Matches { get; set; }

        public Team()
        {
            Players = new List<Player>(11);
            Matches = new List<Match>();
        }
    }
}