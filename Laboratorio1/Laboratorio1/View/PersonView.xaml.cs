using Laboratorio1.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Laboratorio1.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PersonView : ContentPage
	{
		public PersonView ()
		{
			InitializeComponent ();
            BindingContext = new PersonViewModel();
		}
	}
}