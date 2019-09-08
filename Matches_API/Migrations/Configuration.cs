using System.Collections.Generic;
using Matches_API.DAL.Models;

namespace Matches_API.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Matches_API.DAL.EF.MatchesDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Matches_API.DAL.EF.MatchesDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.


            Team team1 = new Team { Name = "Team_1" };
            Team team2 = new Team { Name = "Team_2" };
            Team team3 = new Team { Name = "Team_3" };

            List<Team> teams_1 = new List<Team>();
            List<Team> teams_2 = new List<Team>();
            List<Team> teams_3 = new List<Team>();
            teams_1.AddRange(new[] { team1, team2 });
            teams_2.AddRange(new[] { team1, team3 });
            teams_3.AddRange(new[] { team2, team3 });

            Player player1 = new Player { LastName = "Yershov", FirstName = "Roman", Team = team1 };
            Player player2 = new Player { LastName = "Yershov", FirstName = "Sement", Team = team1 };
            Player player3 = new Player { LastName = "Yershov", FirstName = "Anton", Team = team1 };
            Player player4 = new Player { LastName = "Kuznechov", FirstName = "Mihail", Team = team2 };
            Player player5 = new Player { LastName = "Lermontov", FirstName = "Sergey", Team = team2 };
            Player player6 = new Player { LastName = "Konovalov", FirstName = "Fyodor", Team = team3 };

            League league2 = new League { Name = "League_2" };
            League league3 = new League { Name = "League_3" };

            Match match1 = new Match { DateTime = DateTime.Now.AddDays(10), League = league3, Teams = teams_1 };
            Match match2 = new Match { DateTime = DateTime.Now.AddDays(2), League = league2, Teams = teams_2 };
            Match match3 = new Match { DateTime = DateTime.Now, League = league3, Teams = teams_3 };

            context.Teams.AddRange(new[] {team1, team2, team3});
            context.Players.AddRange(new[] {player1, player2, player3, player4, player5, player6});
            context.Leagues.AddRange(new[] {league2, league3});
            context.Matches.AddRange(new[] {match1, match2, match3});
            context.SaveChanges();
        }
    }
}
