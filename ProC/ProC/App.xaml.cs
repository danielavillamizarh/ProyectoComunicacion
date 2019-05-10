using System;
using Xamarin.Forms;
using ProC.Services;
using ProC.View;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace ProC
{
    public partial class App : Application
    {
        public App()
        {         
                InitializeComponent();
                DependencyService.Get<ISQLite>().GetConnectionWithCreateDatabase();
                MainPage = new NavigationPage(new ListaPersonas());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
