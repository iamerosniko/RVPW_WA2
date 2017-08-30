namespace ProjectWorkplaceAzure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m004 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PW_Examinees", "PersonID", "dbo.PW_Persons");
            DropForeignKey("dbo.PW_PersonTeams", "PersonID", "dbo.PW_Persons");
            DropForeignKey("dbo.PW_PersonTeams", "PW_Persons1_PersonID", "dbo.PW_Persons");
            DropForeignKey("dbo.PW_PersonTeams", "TeamID", "dbo.PW_Teams");
            DropForeignKey("dbo.PW_TeamResources", "ResourceID", "dbo.PW_Resources");
            DropForeignKey("dbo.PW_TeamResources", "TeamID", "dbo.PW_Teams");
            DropForeignKey("dbo.PW_PersonTeams", "PW_Persons_PersonID", "dbo.PW_Persons");
            DropForeignKey("dbo.PW_PersonTeams", "PW_Persons_PersonID1", "dbo.PW_Persons");
            DropForeignKey("dbo.PW_Persons", "RoleID", "dbo.PW_Roles");
            DropForeignKey("dbo.PW_Examinees", "SubjectID", "dbo.PW_Subjects");
            DropForeignKey("dbo.PW_Answers", "QuestionID", "dbo.PW_Questions");
            DropForeignKey("dbo.PW_QuizTags", "QuestionID", "dbo.PW_Questions");
            DropForeignKey("dbo.PW_QuizTags", "SubjectID", "dbo.PW_Subjects");
            DropIndex("dbo.PW_Answers", new[] { "QuestionID" });
            DropIndex("dbo.PW_Examinees", new[] { "PersonID" });
            DropIndex("dbo.PW_Examinees", new[] { "SubjectID" });
            DropIndex("dbo.PW_Persons", new[] { "RoleID" });
            DropIndex("dbo.PW_PersonTeams", new[] { "PersonID" });
            DropIndex("dbo.PW_PersonTeams", new[] { "TeamID" });
            DropIndex("dbo.PW_PersonTeams", new[] { "PW_Persons1_PersonID" });
            DropIndex("dbo.PW_PersonTeams", new[] { "PW_Persons_PersonID" });
            DropIndex("dbo.PW_PersonTeams", new[] { "PW_Persons_PersonID1" });
            DropIndex("dbo.PW_TeamResources", new[] { "TeamID" });
            DropIndex("dbo.PW_TeamResources", new[] { "ResourceID" });
            DropIndex("dbo.PW_QuizTags", new[] { "QuestionID" });
            DropIndex("dbo.PW_QuizTags", new[] { "SubjectID" });
            DropColumn("dbo.PW_PersonTeams", "PW_Persons1_PersonID");
            DropColumn("dbo.PW_PersonTeams", "PW_Persons_PersonID");
            DropColumn("dbo.PW_PersonTeams", "PW_Persons_PersonID1");
            DropTable("dbo.PW_TeamResources");
        }
        
        public override void Down()
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
            
            AddColumn("dbo.PW_PersonTeams", "PW_Persons_PersonID1", c => c.Guid());
            AddColumn("dbo.PW_PersonTeams", "PW_Persons_PersonID", c => c.Guid());
            AddColumn("dbo.PW_PersonTeams", "PW_Persons1_PersonID", c => c.Guid());
            CreateIndex("dbo.PW_QuizTags", "SubjectID");
            CreateIndex("dbo.PW_QuizTags", "QuestionID");
            CreateIndex("dbo.PW_TeamResources", "ResourceID");
            CreateIndex("dbo.PW_TeamResources", "TeamID");
            CreateIndex("dbo.PW_PersonTeams", "PW_Persons_PersonID1");
            CreateIndex("dbo.PW_PersonTeams", "PW_Persons_PersonID");
            CreateIndex("dbo.PW_PersonTeams", "PW_Persons1_PersonID");
            CreateIndex("dbo.PW_PersonTeams", "TeamID");
            CreateIndex("dbo.PW_PersonTeams", "PersonID");
            CreateIndex("dbo.PW_Persons", "RoleID");
            CreateIndex("dbo.PW_Examinees", "SubjectID");
            CreateIndex("dbo.PW_Examinees", "PersonID");
            CreateIndex("dbo.PW_Answers", "QuestionID");
            AddForeignKey("dbo.PW_QuizTags", "SubjectID", "dbo.PW_Subjects", "SubjectID", cascadeDelete: true);
            AddForeignKey("dbo.PW_QuizTags", "QuestionID", "dbo.PW_Questions", "QuestionID", cascadeDelete: true);
            AddForeignKey("dbo.PW_Answers", "QuestionID", "dbo.PW_Questions", "QuestionID", cascadeDelete: true);
            AddForeignKey("dbo.PW_Examinees", "SubjectID", "dbo.PW_Subjects", "SubjectID");
            AddForeignKey("dbo.PW_Persons", "RoleID", "dbo.PW_Roles", "RoleID", cascadeDelete: true);
            AddForeignKey("dbo.PW_PersonTeams", "PW_Persons_PersonID1", "dbo.PW_Persons", "PersonID");
            AddForeignKey("dbo.PW_PersonTeams", "PW_Persons_PersonID", "dbo.PW_Persons", "PersonID");
            AddForeignKey("dbo.PW_TeamResources", "TeamID", "dbo.PW_Teams", "TeamID", cascadeDelete: true);
            AddForeignKey("dbo.PW_TeamResources", "ResourceID", "dbo.PW_Resources", "ResourceID", cascadeDelete: true);
            AddForeignKey("dbo.PW_PersonTeams", "TeamID", "dbo.PW_Teams", "TeamID");
            AddForeignKey("dbo.PW_PersonTeams", "PW_Persons1_PersonID", "dbo.PW_Persons", "PersonID");
            AddForeignKey("dbo.PW_PersonTeams", "PersonID", "dbo.PW_Persons", "PersonID", cascadeDelete: true);
            AddForeignKey("dbo.PW_Examinees", "PersonID", "dbo.PW_Persons", "PersonID", cascadeDelete: true);
        }
    }
}
