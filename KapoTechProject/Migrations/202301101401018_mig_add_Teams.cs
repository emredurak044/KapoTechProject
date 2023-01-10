namespace KapoTechProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_add_Teams : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Teams",
                c => new
                    {
                        TeamID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                        GithubURL = c.String(),
                        LinkedinURL = c.String(),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.TeamID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Teams");
        }
    }
}
