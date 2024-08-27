-- Genre
SET IDENTITY_INSERT [Genre] ON;

INSERT INTO [Genre] ([GenreId], [Name])
 VALUES (1, 'Science-Fiction'),
		(2, 'Fantastique'),
		(3, 'Horreur'),
		(4, 'Science-Fiction Humoristique'),
		(5, 'Histoire');

SET IDENTITY_INSERT [Genre] OFF;

-- Livre
SET IDENTITY_INSERT [Book] ON;

INSERT INTO [Book] ([BookId], [Title], [ReleaseYear], [GenreId])
 VALUES (1, 'Ça', 1988, 3),
	    (2, 'Fondation', 1957, 1),
	    (3, 'La Ligne verte', 1996, 2),
	    (4, 'Le Guide du voyageur galactique', 1978, 4),
	    (5, 'Le Roi de fer', 1955, 5),
	    (6, 'Les robots', 1967, 1);

SET IDENTITY_INSERT [Book] OFF;

-- Auteur
SET IDENTITY_INSERT [Author] ON;
INSERT INTO [Author] ([AuthorId], [Firstname], [Lastname], [BirthDate])
 VALUES (1, 'Stephen', 'King', '1947-09-21'),
	    (2, 'Isaac', 'Asimov', '1920-01-02'),
		(3, 'Douglas', 'Adams', '1952-03-11'),
		(4, 'Maurice', 'Druon', '1918-04-23');

SET IDENTITY_INSERT [Author] OFF;

-- Auteur Book
INSERT INTO [Author_Book] ([AuthorId], [BookId])
 VALUES (1, 1),
		(1, 3),
		(2, 2),
		(2, 6),
		(3, 4),
		(4, 5);
