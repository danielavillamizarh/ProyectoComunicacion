using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using ProC.Model;

namespace ProC.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ComunicacionPage : ContentPage
	{
        #region Metodos
        public ComunicacionPage()
		{
            InitializeComponent();
                       
        }
              

        public ComunicacionPage(Persona datos) {

            InitializeComponent();

            txtDestino.Text = datos.Correo + ";";

            this.Title = "Enviar correo a "+ datos.Nombre +" "+ datos.Apellido;
            this.Navigation.PopToRootAsync();



        }

        private async Task SendMailAsync() {
            //comando para debugar System.Diagnostics.Debug.WriteLine("mensaje");
            try
            {       //lee el campo destinatarios como un string
                var texto = txtDestino.Text;
                //divide los destinatarios en una lista de destinatarios, deparadores dentro de {}
               List<string> destinatarios = texto.Split(new Char[] { ' ', ',', ':', ';' }).ToList();
                
                var message = new EmailMessage
                {
                    Subject = txtAbout.Text,
                    Body = txtBody.Text,
                    To = destinatarios,

                };
                await Email.ComposeAsync(message);
                { }
            }
            catch (FeatureNotSupportedException fbsEx)
            {
                // Email is not supported on this device
                System.Diagnostics.Debug.WriteLine(fbsEx);
            }
            catch (Exception ex)
            {
                // Some other exception occurred
                System.Diagnostics.Debug.WriteLine(ex);

            }
        }

        
        #endregion

        #region Eventos
        private async void BtnSend_ClickedAsync(object sender, EventArgs e)
        {
            await SendMailAsync();
        }
        #endregion
    }
}