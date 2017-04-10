using Pokedex.Utils;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Pokedex.Converters
{
	class ViewModeToAcceptButtonContent : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if ((ViewMode)value == ViewMode.CreateNew) return "Create New";
			else if ((ViewMode)value == ViewMode.Update) return "Update";
			else return String.Empty;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
