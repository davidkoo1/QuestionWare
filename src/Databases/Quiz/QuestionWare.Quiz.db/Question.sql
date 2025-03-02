CREATE TABLE [dbo].[Question]
(
	[Id] INT IDENTITY(1,1) PRIMARY KEY,
	[OrderNumber] INT NOT NULL,
	[Message] nVARCHAR(300),
	[IdQuiz] INT FOREIGN KEY REFERENCES Quiz(Id),
	[CreatedBy] INT,						--FK User
	[CreatedAt] datetime default GETDATE(),
	[LastModifiedBy] INT,					--FK User
	[LastModifiedAt] datetime default GETDATE(),
)
