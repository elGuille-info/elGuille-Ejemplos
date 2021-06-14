using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

namespace elGuilleEjemplos.elGuille
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Ejemplos : ContentPage
    {
        public Ejemplos()
        {
            InitializeComponent();
        }

        private void ContentPage_Appearing(object sender, EventArgs e)
        {
            // Saber la plataforma
            if (DeviceInfo.Platform == DevicePlatform.UWP)
                LabelDevicePlatform.Text = "Estás usando la plataforma UWP";
            else if (DeviceInfo.Platform == DevicePlatform.Android)
                LabelDevicePlatform.Text = "Estás usando la plataforma Android";
            else if (DeviceInfo.Platform == DevicePlatform.iOS)
                LabelDevicePlatform.Text = "Estás usando la plataforma iOS";

            // Saber el tipo de dispositivo
            if (DeviceInfo.Idiom == DeviceIdiom.Desktop)
                LabelDeviceIdiom.Text = "Estás usando el escitorio.";
            else if (DeviceInfo.Idiom == DeviceIdiom.Phone)
                LabelDeviceIdiom.Text = "Estás usando un teléfono móvil.";
            else if (DeviceInfo.Idiom == DeviceIdiom.Tablet)
                LabelDeviceIdiom.Text = "Estás usando una tableta.";

        }

        private void btnAtras_Clicked(object sender, EventArgs e)
        {
            App.IrAtras();
        }
    }
}