using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using elGuilleEjemplos.elGuille;

using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace elGuilleEjemplos
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            InitializeComponent();
        }

        private void ContentPage_Appearing(object sender, EventArgs e)
        {
            LabelStatus.Text = App.InformacionDispositivo();
        }

        private void btnInicio_Clicked(object sender, EventArgs e)
        {
            App.IrInicio();
        }

        private void btnElguillemola_Clicked(object sender, EventArgs e)
        {
            App.NavegarA("https://www.elguillemola.com/");
        }

        private void btnPost02jun2021_Clicked(object sender, EventArgs e)
        {
            App.NavegarA("https://www.elguillemola.com/trucos-para-xamarin-forms-y-net-maui-en-dispositivos/");
        }

        private void btnGitHub_Clicked(object sender, EventArgs e)
        {
            App.NavegarA("https://github.com/elGuille-info/elGuille-Ejemplos");
        }
    }
}