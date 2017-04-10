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
		public ICommand RefreshCommand { get; set; }

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
			RefreshCommand = new CustomCommand(Refresh, CanRefresh);
		}



		private bool CanCreateNew(object obj)
		{
			return true;
		}

		private void CreateNew(object obj)
		{
			Views.PokemonDetailsView createNewWindow = new Views.PokemonDetailsView();
			createNewWindow.ShowDialog();
			Refresh();
		}

		private bool CanRefresh(object obj)
		{
			return true;
		}

		private void Refresh(object obj = null)
		{
			Pokemons = new ObservableCollection<Pokemon>(DataService.GetAllPokemons());
		}

		private bool CanDeleteSelected(object obj)
		{
			if (SelectedPokemon != null) return true;
			else return false;
		}

		private void DeleteSelected(object obj)
		{
			DataService.DeletePokemon(SelectedPokemon);
			Refresh();
		}

		private bool CanUpdateSelected(object obj)
		{
			if (SelectedPokemon != null) return true;
			else return false;
		}

		private void UpdateSelected(object obj)
		{
			Views.PokemonDetailsView udpateWindow = new Views.PokemonDetailsView((Pokemon)selectedPokemon.Clone());
			udpateWindow.ShowDialog();
			Refresh();
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
	
	}
}
