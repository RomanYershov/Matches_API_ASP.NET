using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Matches_API.DAL.Models;

namespace Matches_API.DAL.EF
{
    public class MatchesDbContext : DbContext
    {
        public MatchesDbContext() : base("DefaultConnection") { }

      
        public DbSet<Team> Teams { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<League> Leagues { get; set; }
        public DbSet<Match> Matches { get; set; }
    }

   
}