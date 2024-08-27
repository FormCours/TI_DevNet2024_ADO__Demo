CREATE TABLE [dbo].[Author]
(
	[AuthorId] INT NOT NULL IDENTITY, 
    [Firstname] NVARCHAR(60) NOT NULL, 
    [Lastname] NVARCHAR(60) NOT NULL, 
    [BirthDate] DATE NULL, 
    CONSTRAINT [PK_Author] PRIMARY KEY ([AuthorId]) 
)

GO

CREATE INDEX [IX_Author__Name] ON [dbo].[Author] ([Lastname], [Firstname])
