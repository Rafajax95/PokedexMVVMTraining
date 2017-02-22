using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Pokedex.Utils;
using Pokedex.Models;


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
			Pokemons = new ObservableCollection<Pokemon>()
			{
				new Pokemon("Pika",100,Data.Dictionaries.PokemonType.Electric),
				new Pokemon("Bulba",102,Data.Dictionaries.PokemonType.Grass),
				new Pokemon("Czarma",123,Data.Dictionaries.PokemonType.Fire),
				new Pokemon("Squirle",104,Data.Dictionaries.PokemonType.Water),
				new Pokemon("Caterprie",78,Data.Dictionaries.PokemonType.Grass),
				new Pokemon("Growlith",24,Data.Dictionaries.PokemonType.Fire),
				new Pokemon("Tentakoll",5,Data.Dictionaries.PokemonType.Water)
			};
		}

	}
}
