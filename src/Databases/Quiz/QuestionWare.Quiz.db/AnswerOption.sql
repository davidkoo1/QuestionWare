CREATE TABLE [dbo].[AnswerOption]
(
	[Id] INT IDENTITY(1,1) PRIMARY KEY,
	[IdQuestion] INT FOREIGN KEY REFERENCES Question(Id) NOT NULL,
	[AnswerDescription] NVARCHAR(300)
)
