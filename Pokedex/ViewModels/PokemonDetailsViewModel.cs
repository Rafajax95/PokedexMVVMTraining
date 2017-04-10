using Microsoft.Win32;
using Pokedex.Models;
using Pokedex.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Pokedex.ViewModels
{
	internal class PokemonDetailsViewModel : BindableBase
	{
		private Pokemon pokemon;

		public ViewMode viewMode;
		public Action CloseAction { get; set; }

		public ICommand AcceptCommand { get; set; }
		public ICommand SetPictureCommand { get; set; }

		internal PokemonDetailsViewModel()
		{
			LoadCommands();	
		}

		private void LoadCommands()
		{
			AcceptCommand = new CustomCommand(Accept, CanAccept);
			SetPictureCommand = new CustomCommand(SetPicture, CanSetPicture);
		}

		private bool CanSetPicture(object obj)
		{
			return true;
		}

		private void SetPicture(object obj)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			if (openFileDialog.ShowDialog() == true)
			{
				try
				{
					System.Windows.MessageBox.Show(openFileDialog.FileName);
					pokemon.Image = new System.Windows.Media.Imaging.BitmapImage(new Uri(openFileDialog.FileName));
				}
				catch
				{
					System.Windows.MessageBox.Show("Invalid image source!");
				}
			}

		}



		private bool CanAccept(object obj)
		{
			return true;
		}

		private void Accept(object obj)
		{
			if(viewMode == ViewMode.CreateNew)
			{
				Services.DataService.AddPokemon(pokemon);
			}

			if(viewMode == ViewMode.Update)
			{
				Services.DataService.UpdatePokemon(pokemon);
			}
			CloseAction();
		}
		
		public Pokemon Pokemon
		{
			get
			{
				return pokemon;
			}
			set
			{
				pokemon = value;
				RaisePropertyChanged("Pokemon");
			}
		}

		public ViewMode ViewMode
		{
			get
			{
				return viewMode;
			}
			set
			{
				viewMode = value;
				RaisePropertyChanged("ViewMode");
			}
		}


	}
}
