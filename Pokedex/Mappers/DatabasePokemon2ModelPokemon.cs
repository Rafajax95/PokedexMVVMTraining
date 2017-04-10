using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Pokedex.Mappers
{
	internal static class DatabasePokemon2ModelPokemon
	{
		public static IEnumerable<Models.Pokemon> ToModelPokemonList(this List<Data.Database.Pokemons> DatabasePokemons)
		{
			List<Models.Pokemon> pokemons = new List<Models.Pokemon>();
			foreach(var Pok in DatabasePokemons)
			{
				pokemons.Add(Pok.ToModelPokemon());
			}
			return pokemons;
		}

		public static Models.Pokemon ToModelPokemon(this Data.Database.Pokemons databasePokemon)
		{
			BitmapImage image = LoadImage(databasePokemon.PokemonPictures.Image);
			return new Models.Pokemon(databasePokemon.Id, databasePokemon.Name, (int)databasePokemon.AmountOnWorld, (Data.Dictionaries.PokemonType)databasePokemon.TypeId,image);
		}

		private static BitmapImage LoadImage(byte[] imageData)
		{
			if (imageData == null || imageData.Length == 0) return null;
			var image = new BitmapImage();
			using (var mem = new MemoryStream(imageData))
			{
				mem.Position = 0;
				image.BeginInit();
				image.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
				image.CacheOption = BitmapCacheOption.OnLoad;
				image.UriSource = null;
				image.StreamSource = mem;
				image.EndInit();
			}
			image.Freeze();
			return image;
		}
	}
}
