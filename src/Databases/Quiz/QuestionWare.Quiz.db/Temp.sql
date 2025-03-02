CREATE TABLE [dbo].[Temp]
(
	[IdAnswer] INT FOREIGN KEY REFERENCES AnswerOption(Id) NOT NULL,
	[IdResult] INT FOREIGN KEY REFERENCES Result(ResultId) NOT NULL,
	[CountScore] DECIMAL(6, 2)
)
