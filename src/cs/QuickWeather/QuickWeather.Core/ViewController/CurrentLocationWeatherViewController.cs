﻿using System;
using System.Linq;
using QuickWeather.Core.Model;
using QuickWeather.Core.Services;

namespace QuickWeather.Core.ViewController
{
    public partial class CurrentLocationWeatherViewController
    {
        private readonly ICurrentLocationWeatherView _view;
        private readonly IWeatherService _weatherService;
        private readonly GeoLocationService _geoLocationService;

        public void FetchLocalWeather()
        {
            FetchPosition();
        }

        public void FetchLocations(GeoLocation geoLocation)
        {
            var callback = new ServiceCallback<OfficialStations>(HandleLocationsReceived, HandleError);
            _weatherService.LookupStationsAsync(geoLocation.Latitude, geoLocation.Longitude, callback);
        }

        public void FetchWeather(GeoLocation geoLocation)
        {
            var callback = new ServiceCallback<ForecastDays>(HandleForecastReceived, HandleError);
            _weatherService.LookupForecastAsync(geoLocation.Latitude, geoLocation.Longitude, callback);
        }

        public void FetchPosition()
        {
            _view.DisplayProgressUpdate("Fetching position");
            var callback = new ServiceCallback<GeoLocation>(HandleGeoLocatioReceived, HandleError);
            _geoLocationService.GetPositionAsync(callback);
        }

        private void HandleGeoLocatioReceived(GeoLocation geoLocation)
        {
            InvokeOnSafeThread(() =>
                {
                    var message = string.Format("searching station for {0}", geoLocation.ToFriendlyString());
                    _view.DisplayProgressUpdate(message);
                    FetchLocations(geoLocation);
                });
        }

        private void HandleLocationsReceived(OfficialStations stations)
        {
            InvokeOnSafeThread(() =>
                {
                    if (stations == null)
                    {
                        _view.DisplayError(new Exception("No stations found"));
                        return;
                    }
                    var station = stations.First();
                    _view.DisplayProgressUpdate(station.ToString());
                    FetchWeather(station.Location);
                });
        }

        private void HandleForecastReceived(ForecastDays forecast)
        {
            InvokeOnSafeThread(() =>
                {
                    if (forecast == null)
                    {
                        _view.DisplayProgressUpdate("No forecast found");
                        return;
                    }
                    var forecastDay = forecast.First();
                    _view.DisplayForecast(forecastDay);
                });
        }

        private void HandleError(Exception exception)
        {
            InvokeOnSafeThread(() =>
                {
                    _view.DisplayError(exception);
                });
        }

        public void InvokeOnSafeThread(Action action)
        {
#if ANDROID
    _activity.RunOnUiThread(action);
#elif IOS
    new MonoTouch.Foundation.NSObject().InvokeOnMainThread(() => action());
#elif WINDOWS_PHONE
            System.Windows.Deployment.Current.Dispatcher.BeginInvoke(action);
#else
#error No device specified
#endif
        }

        public PortableColor GetTemperatureColour(int celsuis)
        {
            if (celsuis >= 30)
                return new PortableColor(207, 68, 0);
            if (celsuis >= 24)
                return new PortableColor(207, 141, 0);
            if (celsuis >= 21)
                return new PortableColor(0, 149, 137);
            if (celsuis >= 15)
                return new PortableColor(0, 117, 207);
            if (celsuis >= 10)
                return new PortableColor(0, 156, 207);
            return new PortableColor(0, 195, 207);
        }

        public string GetMeteoconCharacter(ForecastDay forecastDay)
        {
            if (forecastDay == null)
                return ")";

            switch (forecastDay.Icon)
            {
                case "chanceflurries":
                case "chancesleet":
                case "flurries":
                case "sleet":
                    return "X";
                case "chancerain":
                case "rain":
                    return "R";
                case "chancesnow":
                case "snow":
                    return "W";
                case "chancetstorms":
                case "tstorms":
                    return "O";
                case "unknown":
                case "sunny":
                case "clear":
                    return "B";
                case "cloudy":
                    return "Y";
                case "fog":
                    return "M";
                case "hazy":
                    return "J";
                case "mostlycloudy":
                case "partlycloudy":
                    return "Y";
                case "mostlysunny":
                case "partlysunny":
                    return "H";
            }
            return ")";
        }
    }
}
