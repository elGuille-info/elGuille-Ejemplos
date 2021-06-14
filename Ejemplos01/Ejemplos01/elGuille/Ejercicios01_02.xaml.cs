using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace elGuilleEjemplos.elGuille
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Ejercicios01_02 : ContentPage
    {
        public Ejercicios01_02()
        {
            InitializeComponent();
        }
        private void ContentPage_Appearing(object sender, EventArgs e)
        {
            LabelStatus.Text = App.InformacionDispositivo();
        }
        private void btnAtras_Clicked(object sender, EventArgs e)
        {
            App.IrAtras();
        }
    }
}