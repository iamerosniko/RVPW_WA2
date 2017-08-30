namespace ProjectWorkplaceAzure.Migrations
{
    using ProjectWorkplaceAzure.Models;
using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.IO;
using System.Linq;
using System.Reflection;

    internal sealed class Configuration : DbMigrationsConfiguration<ProjectWorkplaceAzure.Models.ProjectWorkplaceAzureContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ProjectWorkplaceAzure.Models.ProjectWorkplaceAzureContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            string codeBase = Assembly.GetExecutingAssembly().CodeBase;
            UriBuilder uri = new UriBuilder(codeBase);
            string path = Uri.UnescapeDataString(uri.Path);
            var baseDir = Path.GetDirectoryName(path) + "\\Migrations\\PW_ViewEmployeeScore.View.sql";

            context.Database.ExecuteSqlCommand(File.ReadAllText(baseDir));

            baseDir = Path.GetDirectoryName(path) + "\\Migrations\\PW_VW_QUESTIONS.View.sql";
            context.Database.ExecuteSqlCommand(File.ReadAllText(baseDir));

            context.PW_Teams.AddOrUpdate(x => x.TeamID,
                   new PW_Teams()
                   {
                        TeamID = new Guid ("52865e93-bba1-4e8b-a4dc-c442386d7b5c"),
                        TeamDesc = "DIS - Enterprise Solutions Development",
                        IsActive = true
                   }

            );

            context.PW_Leaders.AddOrUpdate(x => x.LeaderID,
                   new PW_Leaders()
                   {
                       LeaderID = 17,
                       LeaderName = "Gian Karlo Villaluz",
                       ManagerID = null,
                       LeaderResourceID = new Guid ("8a43576a-264c-40ad-a9f8-a45390efa421"),
                       ManagerResourceID = new Guid ("594370e4-4f40-4695-b337-348e66fd349a")
                   }

            );
        }
    }
}
