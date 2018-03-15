using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using Laboratorio1.View;
namespace Laboratorio1
{
	public partial class App : Application
	{
		public App ()
		{
			InitializeComponent();

			MainPage = new Laboratorio1.View.PersonView();
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
