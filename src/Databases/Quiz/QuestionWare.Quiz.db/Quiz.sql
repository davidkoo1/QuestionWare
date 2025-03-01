CREATE TABLE [dbo].[Quiz]
(
	[Id] INT IDENTITY(1,1) PRIMARY KEY,
	[Name] nVARCHAR(30) NOT NULL,
	[TimeForQuiz] INT NOT NULL,
	[Description] nVARCHAR(300),
	[CreatedBy] INT,
	[CreatedAt] datetime default GETDATE(),
	[LastModifiedBy] INT,
	[LastModifiedAt] datetime default GETDATE(),
)
