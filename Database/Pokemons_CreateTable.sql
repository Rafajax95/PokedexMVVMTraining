CREATE TABLE Pokemons(
[Id] int identity(1,1),
[AmountOnWorld] int,
[Name] nvarchar(50),
[TypeId] int,
[ImageId] int
CONSTRAINT [PokemonsPK] PRIMARY KEY CLUSTERED ([Id]ASC)
CONSTRAINT [Pokemon2PokemonTypes] FOREIGN KEY ([TypeId]) REFERENCES [PokemonTypes](Id),
CONSTRAINT [Pokemon2PokemonPicture] FOREIGN KEY ([ImageId]) REFERENCES [PokemonPictures](InternalId)
)