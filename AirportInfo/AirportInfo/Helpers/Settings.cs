using System;
using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace AirportInfo.Helpers
{
    /// <summary>
    /// This is the Settings static class that can be used in your Core solution or in any
    /// of your client applications. All settings are laid out the same exact way with getters
    /// and setters.
    /// </summary>
    public static class Settings
    {
        public static Uri AirportApiUrl
        {
            get => new Uri(AppSettings.GetValueOrDefault(airportApiUrlKey, airportApiUrlDefault));
            set => AppSettings.AddOrUpdateValue(airportApiUrlKey, value.ToString());
        }

        private static ISettings AppSettings => CrossSettings.Current;

        #region Setting Constants

        private const string airportApiUrlKey = "airport_api_url_key";
        private static readonly string airportApiUrlDefault = "https://places-dev.cteleport.com/airports/";

        #endregion Setting Constants
    }
}
