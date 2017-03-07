CREATE TABLE PokemonPictures
(
	[Id] [uniqueidentifier] ROWGUIDCOL NOT NULL UNIQUE, 
	[InternalId] int unique NOT NULL,
	[Image] VARBINARY(MAX) FILESTREAM NULL
	CONSTRAINT [PokemonPicturesPK] PRIMARY KEY ([InternalId]ASC)
)
GO