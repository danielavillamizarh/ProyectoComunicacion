using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProC.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ListaPersonas : ContentPage
	{
		public ListaPersonas ()
		{
			InitializeComponent ();
		}

        private void btnNavAdd_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AgregarPersona());
        }
    }
}