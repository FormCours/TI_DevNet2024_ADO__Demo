CREATE TABLE [dbo].[Author_Book]
(
	[AuthorId] INT NOT NULL, 
    [BookId] INT NOT NULL, 
    CONSTRAINT [PK_Author_Book] PRIMARY KEY ([AuthorId], [BookId]), 
    CONSTRAINT [FK_Author_Book__Author] FOREIGN KEY ([AuthorId]) REFERENCES [Author]([AuthorId]),
    CONSTRAINT [FK_Author_Book__Book] FOREIGN KEY ([BookId]) REFERENCES [Book]([BookId])
)
