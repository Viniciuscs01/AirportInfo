using System;
using System.Threading;
using System.Threading.Tasks;
using AirportInfo.ViewModels;
using Xamarin.Forms;

namespace AirportInfo
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            IATACode.Keyboard = Keyboard.Create(KeyboardFlags.CapitalizeCharacter);
        }

        //private void Process_Clicked(object sender, EventArgs e)
        //{
        //    //ToggleProcessing();

        //    ((MainPageViewModel)BindingContext).GetInfo.Execute(null);

        //    //ToggleProcessing();
        //}

        //    private void ToggleProcessing()
        //    {
        //        var start = IATACode.IsEnabled;

        //        ProcessIndicator.IsVisible = start;
        //        ProcessIndicator.IsRunning = start;
        //        Process.IsEnabled = !start;
        //        IATACode.IsEnabled = !start;
        //    }
    }
}
