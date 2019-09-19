namespace Matches_API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedCandidateTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Candidates",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Age = c.Int(nullable: false),
                        Done = c.Boolean(nullable: false),
                        LastName = c.String(),
                        FirstName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Candidates");
        }
    }
}
