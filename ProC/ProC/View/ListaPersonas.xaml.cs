using ProC.Model;
using ProC.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProC.View
{ 
	public partial class ListaPersonas : ContentPage
	{

        #region Constructor
        public ListaPersonas ()
		{
			InitializeComponent ();
		}
        #endregion

        #region Metodos
        protected override void OnAppearing()
        {
            PopulatePersonaList();
        }
        //Select
        public void PopulatePersonaList()
        {
            PersonaList.ItemsSource = null;
            PersonaList.ItemsSource = DependencyService.Get<ISQLite>().GetPersonas();
        }
        #endregion

        #region Eventos-Buttons

        //Navegacion para registrar
        private void btnNavAdd_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AgregarPersona(null));
        }

        //Navegacion para actualizar con los campos pertenecientes
        private void btnNavComunicacion_Clicked(object sender, ItemTappedEventArgs e)
        {
            Persona detalles = e.Item as Persona;
            if (detalles != null)
            {
                Navigation.PushAsync(new AgregarPersona(detalles));
            }
        }

        //Boton eliminar
        private async void BorrarPersona_Clicked(object sender, EventArgs e)
        {
            bool res = await DisplayAlert("Message", "Seguro que deseas eliminar esta persona?", "Ok", "Cancel");
            if (res)
            {
                var menu = sender as MenuItem;
                Persona detalles = menu.CommandParameter as Persona;
                DependencyService.Get<ISQLite>().EliminarPersona(detalles.Id);
                PopulatePersonaList();
            }

        }
        #endregion

    }
}