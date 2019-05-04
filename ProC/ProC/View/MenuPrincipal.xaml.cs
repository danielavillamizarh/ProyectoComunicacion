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
    public partial class MenuPrincipal : TabbedPage
    {
        public MenuPrincipal ()
        {
            InitializeComponent();
        }
    }
}