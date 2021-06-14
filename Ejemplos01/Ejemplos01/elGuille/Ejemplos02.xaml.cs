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
    public partial class Ejemplos02 : ContentPage
    {
        public Ejemplos02()
        {
            InitializeComponent();
        }

        private bool esUnaPrueba = false;

        private void ContentPage_Appearing(object sender, EventArgs e)
        {
            //ColorearEtiqueta();
        }

        private void ColorearEtiqueta()
        {
            if (esUnaPrueba)
                LabelInternet.TextColor = (Color)Application.Current.Resources["ColorAzul"];
            else
                LabelInternet.TextColor = (Color)Application.Current.Resources["ColorRojo"];
        }

        private void btnUsarColorAzul_Clicked(object sender, EventArgs e)
        {
            esUnaPrueba = true;
            ColorearEtiqueta();
        }

        private void btnUsarColorRojo_Clicked(object sender, EventArgs e)
        {
            esUnaPrueba = false;
            ColorearEtiqueta();
        }

        private void btnUsarPredeterminado_Clicked(object sender, EventArgs e)
        {
            LabelInternet.TextColor = Color.Green;
        }

        private void ColorearEtiqueta2(bool usarAzul)
        {
            if (usarAzul)
                LabelInternet2.SetDynamicResource(Label.TextColorProperty, "Color2Azul");
            else
                LabelInternet2.SetDynamicResource(Label.TextColorProperty, "Color2Rojo");
        }
        private void btnUsarColor2Azul_Clicked(object sender, EventArgs e)
        {
            ColorearEtiqueta2(true);
        }
        private void btnUsar2ColorRojo_Clicked(object sender, EventArgs e)
        {
            ColorearEtiqueta2(false);
        }
        private void btnUsarPredeterminado2_Clicked(object sender, EventArgs e)
        {
            LabelInternet2.TextColor = Color.Green;
        }

        private void ColorearEtiqueta3(bool usarEstiloAzul)
        {
            if (usarEstiloAzul)
                LabelInternet3.SetDynamicResource(Label.StyleProperty, "LabelEjemplo3Azul");
            else
                LabelInternet3.SetDynamicResource(Label.StyleProperty, "LabelEjemplo3Rojo");
        }
        private void btnUsarColor3Azul_Clicked(object sender, EventArgs e)
        {
            ColorearEtiqueta3(true);
        }
        private void btnUsar3ColorRojo_Clicked(object sender, EventArgs e)
        {
            ColorearEtiqueta3(false);
        }
        private void btnUsarPredeterminado3_Clicked(object sender, EventArgs e)
        {
            LabelInternet3.SetDynamicResource(Label.StyleProperty, "LabelEjemplo3");
        }

    }
}