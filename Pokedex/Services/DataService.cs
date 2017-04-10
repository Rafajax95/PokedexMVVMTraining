using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pokedex.Mappers;
using Pokedex.Data.Database;
using Pokedex.Models;

namespace Pokedex.Services
{
	public static class DataService
	{
		internal static IEnumerable<Models.Pokemon> GetAllPokemons()
		{
			PokedexDBEntities context = new PokedexDBEntities();
			IEnumerable<Models.Pokemon> modelPokemons = context.Pokemons.ToList().ToModelPokemonList();
			context.Dispose();
			context = null;
			return modelPokemons;
		}

		internal static void AddPokemon(Models.Pokemon Pokemon)
		{
			PokedexDBEntities context = new PokedexDBEntities();
			PokemonPictures picture = new PokemonPictures() { Image = Pokemon.Image.ToByteArray(), Id = Guid.NewGuid() ,
			InternalId = context.PokemonPictures.Select(x=>x.InternalId).OrderByDescending(x=>x).ToList().First() + 1 };
			Pokemons dbPokemon = Pokemon.ToDatabasePokemon(picture);
			context.Pokemons.Add(dbPokemon);
			context.SaveChanges();
			context.Dispose();
			context = null;
		}

		internal static void UpdatePokemon(Pokemon Pokemon)
		{
			byte[] image = Pokemon.Image.ToByteArray();

			PokedexDBEntities context = new PokedexDBEntities();

			Pokemons dbPokemon = context.Pokemons.FirstOrDefault(x => x.Id == Pokemon.id);
			PokemonPictures dbPicture = context.PokemonPictures.FirstOrDefault(x => x.InternalId == dbPokemon.ImageId);

			if (dbPicture.Image != image)
				dbPicture.Image = image;

			Pokemons updatedPokemon = Pokemon.ToDatabasePokemon(dbPicture);
			updatedPokemon.ImageId = dbPicture.InternalId;
			context.Entry(dbPokemon).CurrentValues.SetValues(updatedPokemon);
	
			context.SaveChanges();
			context.Dispose();
			context = null;
		}

		internal static void DeletePokemon(Pokemon selectedPokemon)
		{
			PokedexDBEntities context = new PokedexDBEntities();
			Pokemons pokToRemove = context.Pokemons.Where(x => x.Id == selectedPokemon.id).First();
			context.PokemonPictures.Remove(pokToRemove.PokemonPictures);
			context.SaveChanges();
			context.Pokemons.Remove(pokToRemove);
			context.SaveChanges();
			context.Dispose();
			context = null;

			context = new PokedexDBEntities();
			context.ClearFiles();
			context.SaveChanges();
			context.Dispose();
			context = null;

		}
	}
}
