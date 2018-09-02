using System;
using System.Threading;
using System.Threading.Tasks;
using AirportInfo.Models;
using Xamarin.Forms;

namespace AirportInfo
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainPageViewModel();
        }

        private async void Process_Clicked(object sender, EventArgs e)
        {
            ToggleProcessing();

            await Wait();

            AirportInfo.Text = "Hue";

            ToggleProcessing();
        }

        private void ToggleProcessing()
        {
            var start = IATACode.IsEnabled;

            ProcessIndicator.IsVisible = start;
            ProcessIndicator.IsRunning = start;
            Process.IsEnabled = !start;
            IATACode.IsEnabled = !start;
        }

        private async Task Wait() => await Task.Run(action: () => { Thread.Sleep(5000); });
    }
}
