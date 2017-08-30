namespace ProjectWorkplaceAzure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PW_Answers",
                c => new
                    {
                        AnswerID = c.Guid(nullable: false),
                        QuestionID = c.Guid(nullable: false),
                        AnswerDesc = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        IsCorrect = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.AnswerID)
                .ForeignKey("dbo.PW_Questions", t => t.QuestionID, cascadeDelete: true)
                .Index(t => t.QuestionID);
            
            CreateTable(
                "dbo.PW_Questions",
                c => new
                    {
                        QuestionID = c.Guid(nullable: false),
                        QuestionDesc = c.String(),
                        IsCommon = c.Boolean(nullable: false),
                        IsMultipleAns = c.Boolean(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.QuestionID);
            
            CreateTable(
                "dbo.PW_QuizTags",
                c => new
                    {
                        QuizTagID = c.Guid(nullable: false),
                        QuestionID = c.Guid(nullable: false),
                        SubjectID = c.Guid(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.QuizTagID)
                .ForeignKey("dbo.PW_Questions", t => t.QuestionID, cascadeDelete: true)
                .ForeignKey("dbo.PW_Subjects", t => t.SubjectID, cascadeDelete: true)
                .Index(t => t.QuestionID)
                .Index(t => t.SubjectID);
            
            CreateTable(
                "dbo.PW_Subjects",
                c => new
                    {
                        SubjectID = c.Guid(nullable: false),
                        SubjectName = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.SubjectID);
            
            CreateTable(
                "dbo.PW_Examinees",
                c => new
                    {
                        ExamineeID = c.Guid(nullable: false),
                        PersonID = c.Guid(nullable: false),
                        CodeNum = c.Int(),
                        SubjectID = c.Guid(),
                        DateCompleted = c.DateTime(),
                        Score = c.Int(nullable: false),
                        Items = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ExamineeID)
                .ForeignKey("dbo.PW_Persons", t => t.PersonID, cascadeDelete: true)
                .ForeignKey("dbo.PW_Subjects", t => t.SubjectID)
                .Index(t => t.PersonID)
                .Index(t => t.SubjectID);
            
            CreateTable(
                "dbo.PW_Persons",
                c => new
                    {
                        PersonID = c.Guid(nullable: false),
                        FirstName = c.String(),
                        Lastname = c.String(),
                        Username = c.String(),
                        WorkDayNum = c.String(),
                        RoleID = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.PersonID)
                .ForeignKey("dbo.PW_Roles", t => t.RoleID, cascadeDelete: true)
                .Index(t => t.RoleID);
            
            CreateTable(
                "dbo.PW_PersonTeams",
                c => new
                    {
                        PersonTeamID = c.Guid(nullable: false),
                        PersonID = c.Guid(nullable: false),
                        TeamID = c.Guid(),
                        LeaderID = c.Guid(),
                        EffectiveDate = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        PW_Persons1_PersonID = c.Guid(),
                        PW_Persons_PersonID = c.Guid(),
                        PW_Persons_PersonID1 = c.Guid(),
                    })
                .PrimaryKey(t => t.PersonTeamID)
                .ForeignKey("dbo.PW_Persons", t => t.PersonID, cascadeDelete: true)
                .ForeignKey("dbo.PW_Persons", t => t.PW_Persons1_PersonID)
                .ForeignKey("dbo.PW_Teams", t => t.TeamID)
                .ForeignKey("dbo.PW_Persons", t => t.PW_Persons_PersonID)
                .ForeignKey("dbo.PW_Persons", t => t.PW_Persons_PersonID1)
                .Index(t => t.PersonID)
                .Index(t => t.TeamID)
                .Index(t => t.PW_Persons1_PersonID)
                .Index(t => t.PW_Persons_PersonID)
                .Index(t => t.PW_Persons_PersonID1);
            
            CreateTable(
                "dbo.PW_Teams",
                c => new
                    {
                        TeamID = c.Guid(nullable: false),
                        TeamDesc = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.TeamID);
            
            CreateTable(
                "dbo.PW_TeamResources",
                c => new
                    {
                        TeamResourceID = c.Int(nullable: false, identity: true),
                        TeamID = c.Guid(nullable: false),
                        ResourceID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.TeamResourceID)
                .ForeignKey("dbo.PW_Resources", t => t.ResourceID, cascadeDelete: true)
                .ForeignKey("dbo.PW_Teams", t => t.TeamID, cascadeDelete: true)
                .Index(t => t.TeamID)
                .Index(t => t.ResourceID);
            
            CreateTable(
                "dbo.PW_Resources",
                c => new
                    {
                        ResourceID = c.Guid(nullable: false),
                        ResourceName = c.String(),
                        ResourcePath = c.String(),
                        ResourceCategory = c.String(),
                        IsUrl = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ResourceID);
            
            CreateTable(
                "dbo.PW_Roles",
                c => new
                    {
                        RoleID = c.Int(nullable: false, identity: true),
                        RoleDesc = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.RoleID);
            
            CreateTable(
                "dbo.PW_Leaders",
                c => new
                    {
                        LeaderID = c.Int(nullable: false, identity: true),
                        LeaderName = c.String(),
                        ManagerID = c.Int(),
                        LeaderResourceID = c.Guid(),
                        ManagerResourceID = c.Guid(),
                    })
                .PrimaryKey(t => t.LeaderID);
            
            CreateTable(
                "dbo.PW_TemporaryUsers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        TeamID = c.Guid(nullable: false),
                        LeaderID = c.Int(nullable: false),
                        Username = c.String(),
                        QuizScore = c.Int(nullable: false),
                        QuizItem = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PW_QuizTags", "SubjectID", "dbo.PW_Subjects");
            DropForeignKey("dbo.PW_Examinees", "SubjectID", "dbo.PW_Subjects");
            DropForeignKey("dbo.PW_Persons", "RoleID", "dbo.PW_Roles");
            DropForeignKey("dbo.PW_PersonTeams", "PW_Persons_PersonID1", "dbo.PW_Persons");
            DropForeignKey("dbo.PW_PersonTeams", "PW_Persons_PersonID", "dbo.PW_Persons");
            DropForeignKey("dbo.PW_TeamResources", "TeamID", "dbo.PW_Teams");
            DropForeignKey("dbo.PW_TeamResources", "ResourceID", "dbo.PW_Resources");
            DropForeignKey("dbo.PW_PersonTeams", "TeamID", "dbo.PW_Teams");
            DropForeignKey("dbo.PW_PersonTeams", "PW_Persons1_PersonID", "dbo.PW_Persons");
            DropForeignKey("dbo.PW_PersonTeams", "PersonID", "dbo.PW_Persons");
            DropForeignKey("dbo.PW_Examinees", "PersonID", "dbo.PW_Persons");
            DropForeignKey("dbo.PW_QuizTags", "QuestionID", "dbo.PW_Questions");
            DropForeignKey("dbo.PW_Answers", "QuestionID", "dbo.PW_Questions");
            DropIndex("dbo.PW_TeamResources", new[] { "ResourceID" });
            DropIndex("dbo.PW_TeamResources", new[] { "TeamID" });
            DropIndex("dbo.PW_PersonTeams", new[] { "PW_Persons_PersonID1" });
            DropIndex("dbo.PW_PersonTeams", new[] { "PW_Persons_PersonID" });
            DropIndex("dbo.PW_PersonTeams", new[] { "PW_Persons1_PersonID" });
            DropIndex("dbo.PW_PersonTeams", new[] { "TeamID" });
            DropIndex("dbo.PW_PersonTeams", new[] { "PersonID" });
            DropIndex("dbo.PW_Persons", new[] { "RoleID" });
            DropIndex("dbo.PW_Examinees", new[] { "SubjectID" });
            DropIndex("dbo.PW_Examinees", new[] { "PersonID" });
            DropIndex("dbo.PW_QuizTags", new[] { "SubjectID" });
            DropIndex("dbo.PW_QuizTags", new[] { "QuestionID" });
            DropIndex("dbo.PW_Answers", new[] { "QuestionID" });
            DropTable("dbo.PW_TemporaryUsers");
            DropTable("dbo.PW_Leaders");
            DropTable("dbo.PW_Roles");
            DropTable("dbo.PW_Resources");
            DropTable("dbo.PW_TeamResources");
            DropTable("dbo.PW_Teams");
            DropTable("dbo.PW_PersonTeams");
            DropTable("dbo.PW_Persons");
            DropTable("dbo.PW_Examinees");
            DropTable("dbo.PW_Subjects");
            DropTable("dbo.PW_QuizTags");
            DropTable("dbo.PW_Questions");
            DropTable("dbo.PW_Answers");
        }
    }
}
