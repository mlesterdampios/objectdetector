using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ObjectDetector
{
    /// <summary>
    /// Interaction logic for map.xaml
    /// </summary>
    public partial class map : Window
    {
        public map()
        {
            InitializeComponent();
            
        }

        private void OpenURLInBrowser(string url)
        {

            if (!url.StartsWith("http://") && !url.StartsWith("https://"))
            {
                url = "http://" + url;
            }

            try
            {
                webBrowser1.Navigate(new Uri(url));
            }
            catch (System.UriFormatException)
            {
                return;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenURLInBrowser("https://www.ip-tracker.org/locator/ip-lookup.php?ip=" + txtIP.Text);
        }
    }
}
