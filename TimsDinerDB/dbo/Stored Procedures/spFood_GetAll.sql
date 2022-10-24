CREATE PROCEDURE [dbo].[spFood_GetAll]

AS
	
begin

	set nocount on;

	SELECT [Id], [Title], [Description], [Price]
	FROM dbo.Food;
end
