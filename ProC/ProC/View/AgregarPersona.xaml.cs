
namespace ProC.View
{
    using ProC.Model;
    using ProC.Services;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AgregarPersona : ContentPage
    {
        Persona PersonaDetalles;

        public AgregarPersona()
        {
            InitializeComponent();
            btnContactar.IsVisible = false;
        }
        public AgregarPersona(Persona detalles)
        {
            InitializeComponent();
            if (detalles != null)
            {
                PersonaDetalles = detalles;
                PopulateDetalles(PersonaDetalles);
            }
        }
        

        #region Metodos
        private void PopulateDetalles(Persona detalles)
        {
            nombre.Text = detalles.Nombre;
            apellido.Text = detalles.Apellido;
            departamento.Text = detalles.Departamento;
            correo.Text = detalles.Correo;
            btnGuardar.Text = "Actualizar";
            this.Title = "Editar Contacto - Comunicacion";
        }

        private void GuardarPersona(object sender, EventArgs e)
        {
            if (btnGuardar.Text == "Guardar" )
            {
                Persona persona = new Persona();
                persona.Nombre = nombre.Text;
                persona.Apellido = apellido.Text;
                persona.Departamento = departamento.Text;
                persona.Correo = correo.Text;

                bool res = DependencyService.Get<ISQLite>().GuardarPersona(persona);
                if (res)
                {
                    Navigation.PopAsync();
                }
                else
                {
                    DisplayAlert("Error", "No se ha podido guardar", "Ok");
                }
            }
            else
            {
                // update persona
                PersonaDetalles.Nombre = nombre.Text;
                PersonaDetalles.Apellido = apellido.Text;
                PersonaDetalles.Departamento = departamento.Text;
                PersonaDetalles.Correo = correo.Text;

                bool res = DependencyService.Get<ISQLite>().ActualizarPersona(PersonaDetalles);
                if (res)
                {
                    Navigation.PopAsync();
                }
                else
                {
                    DisplayAlert("Error", "No se ha podido Actualizar", "Ok");
                }
            }
        }
        #endregion

        #region Eventos
        private void GuardarPersona_Clicked(object sender, EventArgs e)
        {
            if (btnGuardar.Text == "Guardar")
            {
                Persona persona = new Persona();
                persona.Nombre = nombre.Text;
                persona.Apellido = apellido.Text;
                persona.Departamento = departamento.Text;
                persona.Correo = correo.Text;

                bool res = DependencyService.Get<ISQLite>().GuardarPersona(persona);
                if (res)
                {
                    Navigation.PopAsync();
                }
                else
                {
                    DisplayAlert("Message", "No se ha podido guardar", "Ok");
                }
            }
            else
            {
                // update persona
                PersonaDetalles.Nombre = nombre.Text;
                PersonaDetalles.Apellido = apellido.Text;
                PersonaDetalles.Departamento = departamento.Text;
                PersonaDetalles.Correo = correo.Text;

                bool res = DependencyService.Get<ISQLite>().ActualizarPersona(PersonaDetalles);
                if (res)
                {
                    Navigation.PopAsync();
                }
                else
                {
                    DisplayAlert("Error", "No se ha podido Actualizar", "Ok");
                }
            }
        }
        #endregion

        
        private void BtnContactar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ComunicacionPage(PersonaDetalles));
        }
    }
}