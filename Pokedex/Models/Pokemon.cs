using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pokedex.Utils;
using Pokedex.Data.Dictionaries;

namespace Pokedex.Models
{
	internal class Pokemon : BindableBase
	{
		private string name;
		private int amountOnWorld;
		private PokemonType type;

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
		#endregion

		public Pokemon(string name, int amountOnWorld, PokemonType type)
		{
			Name = name;
			AmountOnWorld = amountOnWorld;
			Type = type;
		}
	}


}
