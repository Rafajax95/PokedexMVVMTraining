using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace Pokedex.Converters
{
	public class PokemonTypeToColorConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{

			if ((Pokedex.Data.Dictionaries.PokemonType)value == Data.Dictionaries.PokemonType.Fire)
				return new SolidColorBrush(Color.FromArgb(100,199, 0, 0));
			if ((Pokedex.Data.Dictionaries.PokemonType)value == Data.Dictionaries.PokemonType.Grass)
				return new SolidColorBrush(Color.FromArgb(100, 0, 199, 0));
			if ((Pokedex.Data.Dictionaries.PokemonType)value == Data.Dictionaries.PokemonType.Water)
				return new SolidColorBrush(Color.FromArgb(100, 0, 0,199));
			if ((Pokedex.Data.Dictionaries.PokemonType)value == Data.Dictionaries.PokemonType.Electric)
				return new SolidColorBrush(Color.FromArgb(100, 255, 241, 84));

			else return Brushes.Transparent;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
