using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Microsoft.Phone.Controls;

namespace HelloWorld.WinPhone
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
        }

    }
}