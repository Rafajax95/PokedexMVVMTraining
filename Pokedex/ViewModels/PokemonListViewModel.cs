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
using System.Windows.Input;

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

		public ICommand CloseDetailsCommand { get; set; }
		public ICommand DeleteSelectedCommand { get; set; }
		public ICommand UpdateSelectedCommand { get; set; }
		public ICommand CreateNewCommand { get; set; }

		public PokemonListViewModel()
		{
			Pokemons = new ObservableCollection<Pokemon>(DataService.GetAllPokemons());
			LoadCommands();
		}

		private void LoadCommands()
		{
			CloseDetailsCommand = new CustomCommand(CloseDetails, CanCloseDetails);
			UpdateSelectedCommand = new CustomCommand(UpdateSelected, CanUpdateSelected);
			DeleteSelectedCommand = new CustomCommand(DeleteSelected, CanDeleteSelected);
			UpdateSelectedCommand = new CustomCommand(UpdateSelected, CanUpdateSelected);
			CreateNewCommand = new CustomCommand(CreateNew, CanCreateNew);

		}

		private bool CanCreateNew(object obj)
		{
			return true;
		}

		private void CreateNew(object obj)
		{

		}

		private bool CanDeleteSelected(object obj)
		{
			if (SelectedPokemon != null) return true;
			else return false;
		}

		private void DeleteSelected(object obj)
		{
			Pokemons.Remove(SelectedPokemon);
		}

		private bool CanUpdateSelected(object obj)
		{
			if (SelectedPokemon != null) return true;
			else return false;
		}

		private void UpdateSelected(object obj)
		{
			
		}

		private bool CanCloseDetails(object obj)
		{
			if (SelectedPokemon != null) return true;
			else return false;
		}

		private void CloseDetails(object obj)
		{
			SelectedPokemon = null;
		}

		//public PokemonListViewModel()
		//{
		//	Pokemons = new ObservableCollection<Pokemon>()
		//	{
		//		new Pokemon("Pika",100,Data.Dictionaries.PokemonType.Electric,new BitmapImage()),
		//		new Pokemon("Bulba",102,Data.Dictionaries.PokemonType.Grass,new BitmapImage()),
		//		new Pokemon("Czarma",123,Data.Dictionaries.PokemonType.Fire,new BitmapImage()),
		//		new Pokemon("Squirle",54,Data.Dictionaries.PokemonType.Water,new BitmapImage())

		//	};
		//	LoadCommands();
		//}

	}
}
