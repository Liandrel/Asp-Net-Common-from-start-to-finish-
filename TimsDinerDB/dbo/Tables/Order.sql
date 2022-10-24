CREATE TABLE [dbo].[Order]
(
	[Id] INT NOT NULL PRIMARY KEY identity, 
    [OrderName] NVARCHAR(50) NOT NULL, 
    [OrderDate] DATETIME2 NOT NULL, 
    [FoodID] INT NOT NULL, 
    [Quantity] INT NOT NULL, 
    [Total] MONEY NOT NULL, 
    CONSTRAINT [FK_Order_Food] FOREIGN KEY (FoodID) REFERENCES [Food]([Id])	
)
