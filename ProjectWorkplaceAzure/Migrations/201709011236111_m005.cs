namespace ProjectWorkplaceAzure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m005 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PW_TeamResources",
                c => new
                    {
                        TeamResourceID = c.Int(nullable: false, identity: true),
                        TeamID = c.Guid(nullable: false),
                        ResourceID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.TeamResourceID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PW_TeamResources");
        }
    }
}
