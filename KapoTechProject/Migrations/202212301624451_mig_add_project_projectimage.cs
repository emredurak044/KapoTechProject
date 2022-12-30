namespace KapoTechProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_add_project_projectimage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Projects", "ProjectImage", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Projects", "ProjectImage");
        }
    }
}
