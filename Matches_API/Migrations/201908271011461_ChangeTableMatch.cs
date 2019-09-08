namespace Matches_API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeTableMatch : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Matches", "League_Id", "dbo.Leagues");
            DropIndex("dbo.Matches", new[] { "League_Id" });
            RenameColumn(table: "dbo.Matches", name: "League_Id", newName: "LeagueId");
            AlterColumn("dbo.Matches", "LeagueId", c => c.Int(nullable: false));
            CreateIndex("dbo.Matches", "LeagueId");
            AddForeignKey("dbo.Matches", "LeagueId", "dbo.Leagues", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Matches", "LeagueId", "dbo.Leagues");
            DropIndex("dbo.Matches", new[] { "LeagueId" });
            AlterColumn("dbo.Matches", "LeagueId", c => c.Int());
            RenameColumn(table: "dbo.Matches", name: "LeagueId", newName: "League_Id");
            CreateIndex("dbo.Matches", "League_Id");
            AddForeignKey("dbo.Matches", "League_Id", "dbo.Leagues", "Id");
        }
    }
}
