using System;
using System.Text;

using elGuilleEjemplos.elGuille;

using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace elGuilleEjemplos
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }
        /// <summary>
        /// Ir a la página indicada.
        /// </summary>
        /// <param name="pagina">La página a la que se quiere ir.</param>
        async public static void IrPagina(Page pagina)
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
        /// <summary>
        /// Ir a la página anterior.
        /// </summary>
        async public static void IrAtras()
        {
            //
            // Se supone que si se cumple que NavigationStack.Count es cero
            // es que iOS o la plataforma no soporta la navegación no modal
            //
            if (Current.MainPage.Navigation.NavigationStack.Count == 0)
                await Current.MainPage.Navigation.PopModalAsync();
            else
                await Current.MainPage.Navigation.PopAsync();
        }
        /// <summary>
        /// Ir a la página de inicio.
        /// </summary>
        async public static void IrInicio()
        {
            try
            {
                await Shell.Current.GoToAsync("//MenuEjemplos");
            }
            catch
            {
                Current.MainPage = MenuEjemplos.Current;
            }
        }
        /// <summary>
        /// Navegar a la dirección indicada.
        /// </summary>
        /// <param name="url">La página web a la que queremos navegar.</param>
        async public static void NavegarA(string url)
        {
            var uri = new Uri(url);
            await Browser.OpenAsync(uri, BrowserLaunchMode.SystemPreferred);
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
