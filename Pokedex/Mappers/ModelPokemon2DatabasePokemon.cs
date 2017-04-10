using Pokedex.Data.Database;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Pokedex.Mappers
{
	internal static class ModelPokemon2DatabasePokemon
	{
		public static Pokemons ToDatabasePokemon(this Models.Pokemon modelPokemon, PokemonPictures picture)
		{
			return new Pokemons
			{
				Id = modelPokemon.id,
				AmountOnWorld = modelPokemon.AmountOnWorld,
				Name = modelPokemon.Name,
				TypeId = (int)modelPokemon.Type,
				PokemonPictures = picture
			};
		}

		public static byte[] ToByteArray(this BitmapImage image)
		{
			byte[] data;
			try
			{
				JpegBitmapEncoder encoder = new JpegBitmapEncoder();
				encoder.Frames.Add(BitmapFrame.Create(image));
				using (MemoryStream ms = new MemoryStream())
				{
					encoder.Save(ms);
					data = ms.ToArray();
				}

				return data;
			}
			catch
			{
				return new byte[0];
			}


		}
	}
}
