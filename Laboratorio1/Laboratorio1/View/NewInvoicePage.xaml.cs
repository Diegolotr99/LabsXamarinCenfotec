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
	public partial class NewInvoicePage : ContentPage
	{
        public bool editMode;

        public NewInvoicePage ()
		{
			InitializeComponent ();
            BindingContext = PersonViewModel.GetInstance();
        }

        public NewInvoicePage(bool pEditMode)
        {
            InitializeComponent();
            BindingContext = PersonViewModel.GetInstance();
            editMode = pEditMode;
            if (editMode)
            {
                //THen Disable controls that cant be edited

            }
        }

        
    }
}