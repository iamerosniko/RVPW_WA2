using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Web;

namespace ProjectWorkplaceAzure.Models
{
    public class ProjectWorkplaceAzureContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public ProjectWorkplaceAzureContext() : base("name=ProjectWorkplaceAzureContext")
        {
        }

        public System.Data.Entity.DbSet<ProjectWorkplaceAzure.Models.PW_Answers> PW_Answers { get; set; }

        public System.Data.Entity.DbSet<ProjectWorkplaceAzure.Models.PW_Questions> PW_Questions { get; set; }

        public System.Data.Entity.DbSet<ProjectWorkplaceAzure.Models.PW_Examinees> PW_Examinees { get; set; }

        public System.Data.Entity.DbSet<ProjectWorkplaceAzure.Models.PW_Persons> PW_Persons { get; set; }

        public System.Data.Entity.DbSet<ProjectWorkplaceAzure.Models.PW_Subjects> PW_Subjects { get; set; }

        public System.Data.Entity.DbSet<ProjectWorkplaceAzure.Models.PW_Leaders> PW_Leaders { get; set; }

        public System.Data.Entity.DbSet<ProjectWorkplaceAzure.Models.PW_Roles> PW_Roles { get; set; }

        public System.Data.Entity.DbSet<ProjectWorkplaceAzure.Models.PW_PersonTeams> PW_PersonTeams { get; set; }

        public System.Data.Entity.DbSet<ProjectWorkplaceAzure.Models.PW_Teams> PW_Teams { get; set; }

        public System.Data.Entity.DbSet<ProjectWorkplaceAzure.Models.PW_QuizTags> PW_QuizTags { get; set; }

        public System.Data.Entity.DbSet<ProjectWorkplaceAzure.Models.PW_Resources> PW_Resources { get; set; }

        public System.Data.Entity.DbSet<ProjectWorkplaceAzure.Models.PW_TemporaryUsers> PW_TemporaryUsers { get; set; }

        public System.Data.Entity.DbSet<ProjectWorkplaceAzure.Models.PW_TeamResources> PW_TeamResources { get; set; }

        public System.Data.Entity.DbSet<ProjectWorkplaceAzure.Models.PW_VW_QUESTIONS> PW_VW_QUESTIONS { get; set; }

        public System.Data.Entity.DbSet<ProjectWorkplaceAzure.Models.PW_ViewEmployeeScore> PW_ViewEmployeeScore { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.AddFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }

        public System.Data.Entity.Core.Objects.ObjectResult<PW_GetResourcePath_Result> PW_GetResourcePath(string username, string resourceCategory)
        {
            var usernameParameter = username != null ?
                new System.Data.Entity.Core.Objects.ObjectParameter("username", username) :
                new System.Data.Entity.Core.Objects.ObjectParameter("username", typeof(string));

            var resourceCategoryParameter = resourceCategory != null ?
                new System.Data.Entity.Core.Objects.ObjectParameter("resourceCategory", resourceCategory) :
                new System.Data.Entity.Core.Objects.ObjectParameter("resourceCategory", typeof(string));

            return ((System.Data.Entity.Infrastructure.IObjectContextAdapter)this).ObjectContext.ExecuteFunction<PW_GetResourcePath_Result>("PW_GetResourcePath", usernameParameter, resourceCategoryParameter);
        }

    }
}
