using Pokedex.Data.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Pokedex.Mappers
{
	internal static class ModelPokemon2DatabasePokemon
	{
		public static Pokemons ToDatabasePokemon(this Models.Pokemon modelPokemon)
		{
			return new Pokemons {
				AmountOnWorld = modelPokemon.AmountOnWorld,
				Name = modelPokemon.Name,
				TypeId = (int)modelPokemon.Type
			};
		}

		private static byte[] LoadImage(BitmapImage image)
		{

			return new byte[1];
		}
	}
}
