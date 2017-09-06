

IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[PW_ViewEmployeeScore]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[PW_ViewEmployeeScore] AS 
select pe.Username,ex.Score,ex.Items,ex.DateCompleted from 
PW_Examinees ex
left join PW_Persons pe
on pe.PersonID=ex.PersonID'

