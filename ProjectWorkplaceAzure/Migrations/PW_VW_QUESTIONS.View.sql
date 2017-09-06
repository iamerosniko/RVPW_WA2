IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[PW_VW_QUESTIONS]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[PW_VW_QUESTIONS]
SELECT TOP 10 
		*
	FROM 
		PW_Questions
	where isActive = cast(1 as bit)
	ORDER BY 
		NEWID()'