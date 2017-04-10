using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pokedex.Utils;
using Pokedex.Data.Dictionaries;
using System.Windows.Media.Imaging;

namespace Pokedex.Models
{
	internal class Pokemon : BindableBase, ICloneable
	{
		public int id;
		private string name;
		private int amountOnWorld;
		private PokemonType type;
		private BitmapImage image;

		#region Props
		public string Name
		{
			get
			{
				return name;
			}

			set
			{
				name = value;
				RaisePropertyChanged("Name");
			}
		}

		public int AmountOnWorld
		{
			get
			{
				return amountOnWorld;
			}

			set
			{
				amountOnWorld = value;
				RaisePropertyChanged("AmountOnWorld");
			}
		}

		public PokemonType Type
		{
			get
			{
				return type;
			}

			set
			{
				type = value;
				RaisePropertyChanged("Type");
			}
		}
		
		public BitmapImage Image
		{
			get
			{
				return image;
			}
			set
			{
				image = value;
				RaisePropertyChanged("Image");
			}
		}
		#endregion

		public Pokemon(int id, string name, int amountOnWorld, PokemonType type, BitmapImage image)
		{
			this.id = id;
			Name = name;
			AmountOnWorld = amountOnWorld;
			Type = type;
			Image = image;
		}

		public object Clone()
		{
			return this.MemberwiseClone();
		}
	}


}
