CREATE PROCEDURE [dbo].[spOrders_Delete]
	@Id			int
AS

begin

	set nocount on;

	DELETE
	FROM dbo.[Order]
	WHERE Id = @Id;


end
