using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pokedex.Mappers;
using Pokedex.Data.Database;


namespace Pokedex.Services
{
	public static class DataService
	{
		internal static IEnumerable<Models.Pokemon> GetAllPokemons()
		{
			PokedexDBEntities context = new PokedexDBEntities();
			IEnumerable<Models.Pokemon> modelPokemons = context.Pokemons.ToList().ToModelPokemonList();

			return modelPokemons;
		}

		internal static void AddPokemon(Models.Pokemon Pokemon)
		{
			PokedexDBEntities context = new PokedexDBEntities();
			Pokemons dbPokemon = Pokemon.ToDatabasePokemon();
			context.Pokemons.Add(dbPokemon);
			context.SaveChanges();
		}

	}
}
