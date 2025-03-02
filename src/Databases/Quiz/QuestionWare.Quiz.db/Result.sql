CREATE TABLE [dbo].[Result]
(
	[IdQuiz] INT FOREIGN KEY REFERENCES Quiz(Id) NOT NULL,
	[ResultId] INT PRIMARY KEY,
	[ResultDescription] NVARCHAR(300)
)
