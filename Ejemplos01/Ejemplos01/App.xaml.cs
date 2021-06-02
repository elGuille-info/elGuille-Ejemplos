using System;
using System.Text;

using Ejemplos01.elGuille;

using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ejemplos01
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }

        async public static void NavegarA(Page pagina)
        {
            if (pagina == null)
                throw new ArgumentException("El valor de 'pagina' no está instanciado.");

            try
            {
                await Current.MainPage.Navigation.PushAsync(pagina);
            }
            catch
            {
                await Current.MainPage.Navigation.PushModalAsync(pagina);
            }
        }

        async public static void IrAtras()
        {
            //
            // Se supone que si se cumple que NavigationStack.Count es cero
            // es que iOS o la plataforma no soporta la navegación no modal
            //
            var stack = Current.MainPage.Navigation.NavigationStack;
            if (stack.Count == 0)
                await Current.MainPage.Navigation.PopModalAsync();
            else
                await Current.MainPage.Navigation.PopAsync();
        }

        /// <summary>
        /// Comprueba la conexión a Internet y si hay una versión más reciente.
        /// Y muestra la información del dispositivo.
        /// </summary>
        /// <returns>Devuelve una cadena con la información.</returns>
        public static string InformacionDispositivo()
        {
            string msgVersion;

            if (!App.HayConexionInternet())
                msgVersion = $"ATENCIÓN {App.TipoConexion}";
            else
                msgVersion = $"{App.TipoConexion}";

            // Idiom es Phone, Tablet, Desktop (en UWP)
            msgVersion += $" - Info dispositivo: ({DeviceInfo.Platform}; {DeviceInfo.Idiom}; {DeviceInfo.DeviceType}).";

            return msgVersion;
        }

        /// <summary>
        /// El mensaje de si hay o no conexión a internet
        /// </summary>
        public static string TipoConexion { get; private set; }

        /// <summary>
        /// Comprobar si hay conexión a internet.
        /// Asigna también <see cref="TipoConexion"/>.
        /// </summary>
        /// <returns>Un valor verdadero si hay conexión a Internet.</returns>
        /// <remarks>También devuelve los tipos de conexiones del dispositivo.</remarks>
        public static bool HayConexionInternet()
        {
            var current = Connectivity.NetworkAccess;

            var sb = new StringBuilder();
            sb.Append("(");
            foreach (var cp in Connectivity.ConnectionProfiles)
            {
                sb.Append($"{cp.ToString()}; ");
            }
            var cnnPro = sb.ToString().TrimEnd(new char[] { ';', ' ' }) + ")";

            if (current == NetworkAccess.Internet)
            {
                // Connection to internet is available
                TipoConexion = $"Hay conexión a Internet. {cnnPro}";
                return true;
            }
            else if (current == NetworkAccess.ConstrainedInternet)
            {
                TipoConexion = $"Sin conexión a Internet. {cnnPro}";
                return false;
            }
            else if (current == NetworkAccess.Local)
            {
                TipoConexion = $"Sin conexión a Internet. {cnnPro}";
                return false;
            }
            else if (current == NetworkAccess.Unknown)
            {
                TipoConexion = $"Sin conexión a Internet. {cnnPro}";
                return false;
            }
            else //if (current == NetworkAccess.None)
            {
                TipoConexion = $"Sin conexión a Internet. {cnnPro}";
                return false;
            }
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
