using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using QuickWeather.Core.Proxy;

namespace QuickWeather.WindowsPhone
{
    public partial class MainPage : PhoneApplicationPage
    {
        public MainPage()
        {
            InitializeComponent();


            var textBlock = new TextBlock
            {
                Text = "Hello TechEd 2013",
                FontSize = 30,
                FontFamily = new FontFamily("Arial"),
                FontWeight = FontWeights.Bold
            };

            ContentPanel.Children.Add(textBlock);


            var proxy = new WUndergroundProxy();

            var stations = proxy.LookupStations("37.776289", "-122.395234");

            textBlock.Text = stations.NearbyWeatherStations.Airport.Station.First().City;

        }
    }
}