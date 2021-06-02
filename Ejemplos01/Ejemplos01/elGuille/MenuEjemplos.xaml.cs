using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ejemplos01.elGuille
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuEjemplos : ContentPage
    {
        public static MenuEjemplos Current;
        public MenuEjemplos()
        {
            InitializeComponent();
            Current = this;
        }

        private void ContentPage_Appearing(object sender, EventArgs e)
        {
            LabelStatus.Text = App.InformacionDispositivo();
        }

        private void btnEjemplo01_Clicked(object sender, EventArgs e)
        {
            App.NavegarA(new Ejemplos());
        }

        private void btnEjercicios01y02_Clicked(object sender, EventArgs e)
        {
            App.NavegarA(new Ejercicios01_02());
        }

        async private void btnPost02jun2021_Clicked(object sender, EventArgs e)
        {
            var uri = new Uri("https://www.elguillemola.com/trucos-para-xamarin-forms-y-net-maui-en-dispositivos/");
            await Browser.OpenAsync(uri, BrowserLaunchMode.SystemPreferred);
        }
    }
}