using Pokedex.Models;
using Pokedex.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Pokedex.Views
{
	/// <summary>
	/// Interaction logic for PokemonDetailsView.xaml
	/// </summary>
	public partial class PokemonDetailsView : Window
	{
		internal PokemonDetailsView(Pokemon pokemon = null)
		{
			InitializeComponent();
			if (pokemon == null)
			{
				((PokemonDetailsViewModel)this.DataContext).Pokemon = new Pokemon(0,"", 0, Data.Dictionaries.PokemonType.Electric, new BitmapImage());
				((PokemonDetailsViewModel)this.DataContext).ViewMode = Utils.ViewMode.CreateNew;
			}

			else
			{
				((PokemonDetailsViewModel)this.DataContext).Pokemon = pokemon;
				((PokemonDetailsViewModel)this.DataContext).ViewMode = Utils.ViewMode.Update;
			}
			
			if (((PokemonDetailsViewModel)this.DataContext).CloseAction == null)
				((PokemonDetailsViewModel)this.DataContext).CloseAction = new Action(this.Close);
		}
	}
}
