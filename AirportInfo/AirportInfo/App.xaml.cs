using AirportInfo.Abstractions;
using AirportInfo.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

namespace AirportInfo
{
    public partial class App : Application
    {
        public App()
        {
#if DEBUG
            LiveReload.Init();
#endif

            InitializeComponent();

            RegisterDependencies();

            MainPage = new MainPage();
        }

        private void RegisterDependencies() => DependencyService.Register<IAirportInfoService, AirportInfoService>();

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
