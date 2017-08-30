namespace ProjectWorkplaceAzure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m002 : DbMigration
    {
        public override void Up()
        {
            CreateStoredProcedure(
            "dbo.PW_GetCurrentUser",
            p => new
            {
                username = p.String()
            },
            @"select top 1 * from PW_TemporaryUsers 
	            where PW_TemporaryUsers.Username=@username
	            order by PW_TemporaryUsers.ID desc"
            );

            CreateStoredProcedure(
            "dbo.PW_GetResourcePath",
            p => new
            {
                username = p.String(),
                resourceCategory = p.String()
            },
            @"select 
		            r.ResourcePath as [ResourcePath],
		            r.ResourceCategory
	            from 
		            PW_Persons p
	            left join
		            PW_PersonTeams pt
		            on	p.PersonID=pt.PersonID
	            left join 
		            PW_Teams t
		            on pt.TeamID=t.TeamID
	            left join 
		            PW_TeamResources tr
		            on t.TeamID=tr.TeamID
	            left join 
		            PW_Resources r
		            on r.ResourceID=tr.ResourceID
	            where p.Username=@username
	            and r.ResourceCategory=@resourceCategory"
            );

            CreateStoredProcedure(
            "dbo.PW_GetResourcePath2",
            p => new
            {
                username = p.String(),
                resourceCategory = p.String()
            },
            @"select 
		        r.ResourcePath as [ResourcePath],
		        r.ResourceCategory,
		        p.*
	        from 
		        PW_TemporaryUsers p
	        left join 
		        PW_TeamResources tr
		        on p.TeamID=tr.TeamID
	        left join 
		        PW_Resources r
		        on r.ResourceID=tr.ResourceID
	        where p.Username=@username
	        and p.IsActive=cast(1 as bit)
	        and r.ResourceCategory=@resourceCategory
	        order by p.id desc"
            );

            CreateStoredProcedure(
            "dbo.PW_GetVideo",
            p => new
            {
                username = p.String(),
                isLeader = p.Boolean()
            },
            @"if(@isLeader = cast(1 as bit))
		select 
			r.ResourcePath as [ResourcePath],
			r.ResourceCategory
		from 
			PW_TemporaryUsers p
		left join PW_Leaders l
			on p.LeaderID=l.LeaderID
		left join 
			PW_Resources r
			on r.ResourceID=l.LeaderResourceID
		where p.Username=@username
		and p.IsActive=cast(1 as bit)
		order by p.id desc
	else
		select 
			r.ResourcePath as [ResourcePath],
			r.ResourceCategory
		from 
			PW_TemporaryUsers p
		left join PW_Leaders l
			on p.LeaderID=l.LeaderID
		left join 
			PW_Resources r
			on r.ResourceID=l.ManagerResourceID
		where p.Username=@username
		and p.IsActive=cast(1 as bit)
		order by p.id desc"
            );
        }
        
        public override void Down()
        {
            DropStoredProcedure("dbo.PW_GetCurrentUser");
            DropStoredProcedure("dbo.PW_GetResourcePath");
            DropStoredProcedure("dbo.PW_GetResourcePath2");
            DropStoredProcedure("dbo.PW_GetVideo");
        }
    }
}
