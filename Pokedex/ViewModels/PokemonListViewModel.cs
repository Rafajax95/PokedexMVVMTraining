using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Pokedex.Utils;
using Pokedex.Models;
using Pokedex.Services;
using System.Windows.Media.Imaging;

namespace Pokedex.ViewModels
{
	class PokemonListViewModel : BindableBase
	{
		private Pokemon selectedPokemon;
		private ObservableCollection<Pokemon> pokemons;

		public Pokemon SelectedPokemon
		{
			get
			{
				return selectedPokemon;
			}

			set
			{
				selectedPokemon = value;
				RaisePropertyChanged("SelectedPokemon");
			}
		}

		public ObservableCollection<Pokemon> Pokemons
		{
			get
			{
				return pokemons;
			}

			set
			{
				pokemons = value;
				RaisePropertyChanged("Pokemons");
			}
		}

		public PokemonListViewModel()
		{
			Pokemons = new ObservableCollection<Pokemon>(DataService.GetAllPokemons());
		}

		//public PokemonListViewModel()
		//{
		//	Pokemons = new ObservableCollection<Pokemon>()
		//	{
		//		new Pokemon("Pika",100,Data.Dictionaries.PokemonType.Electric,new BitmapImage()),
		//		new Pokemon("Bulba",102,Data.Dictionaries.PokemonType.Grass,new BitmapImage()),
		//		new Pokemon("Czarma",123,Data.Dictionaries.PokemonType.Fire,new BitmapImage()),
		//		new Pokemon("Squirle",104,Data.Dictionaries.PokemonType.Water,new BitmapImage())
		//	};
		//}

	}
}
