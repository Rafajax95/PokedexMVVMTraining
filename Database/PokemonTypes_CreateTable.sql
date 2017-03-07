CREATE TABLE PokemonTypes(
[Id] int identity(1,1),
[TypeName] nvarchar(50)
CONSTRAINT [PokemonTypesPK] PRIMARY KEY CLUSTERED ([Id]ASC)
)