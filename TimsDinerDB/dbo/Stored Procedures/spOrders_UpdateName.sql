CREATE PROCEDURE [dbo].[spOrders_UpdateName]
	@Id			int,
	@OrderName	nvarchar(50)

AS
	
begin

	set nocount on;

	UPDATE dbo.[Order]
	SET OrderName = @OrderName
	WHERE Id = @Id;


end
