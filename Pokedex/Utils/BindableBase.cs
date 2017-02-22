using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Pokedex.Utils
{
	public class BindableBase : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		protected void RaisePropertyChanged(string propName)
		{
			if(PropertyChanged!=null)
			{
				PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propName));
			}
		}
	}
}
