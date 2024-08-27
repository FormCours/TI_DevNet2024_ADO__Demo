CREATE TABLE [dbo].[Book]
(
	[BookId] INT NOT NULL IDENTITY, 
    [Title] NVARCHAR(500) NOT NULL, 
    [ReleaseYear] INT NULL,
    [GenreId] INT NOT NULL,

    CONSTRAINT [PK_Book] PRIMARY KEY ([BookId]), 
    CONSTRAINT [UK_Book__Title_ReleaseYear] UNIQUE ([Title], [ReleaseYear]),
    CONSTRAINT [FK_Book__Genre] FOREIGN KEY ([GenreId]) REFERENCES [Genre]([GenreId])
)
