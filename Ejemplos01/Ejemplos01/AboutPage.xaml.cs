using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Ejemplos01.elGuille;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ejemplos01
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

        async private void btnInicio_Clicked(object sender, EventArgs e)
        {
            try
            {
                await Shell.Current.GoToAsync("//MenuEjemplos");
            }
            catch
            {
                Application.Current.MainPage = MenuEjemplos.Current;
            }
        }
    }
}