CREATE TABLE [dbo].[orders]
(
	[Id] INT NOT NULL PRIMARY KEY,
	[Status] NVARCHAR(50) NOT NULL,
	[CreatedDate] DATE NOT NULL,
	[UpdatedDate] DATE NOT NULL,
	[ProductId] INT NOT NULL
)
