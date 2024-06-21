﻿CREATE PROCEDURE [dbo].[spUsers_Authenticate]
	@username nvarchar(16),
	@password nvarchar(16)
AS
begin
	set nocount on;

	SELECT [Id], [Username], [FirstName], [LastName], [Password]
	FROM dbo.Users
	WHERE Username = @username
	AND Password = @password;

end