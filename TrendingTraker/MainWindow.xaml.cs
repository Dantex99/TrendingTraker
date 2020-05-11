using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Tweetinvi;

namespace TrendingTraker
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        //Idioma
        bool idioma = true;
        public MainWindow()
        {
            InitializeComponent();
            Auth.SetUserCredentials(
                "9F948nTxp7DLQlJkNHgC9Zct0",
                "taJoKFzKIaEdxk4wEUdZSZZmHD9FZ5pB9SP9wlHATY0qq37NEp",
                "1235663240224559104-3pZyrD0ZVyiK1lTd5OoONBA979nE3e",
                "hw6OuidUsyT9fSdoLdoxtGt3rZdj2OrUOGB7gMLVBCyrD"
                );

            //Imprime por pantalla las tendencias
            setTrendigns(23424950);

        }

        private void setTrendigns(int location)
        {
            //Bucle recorriendo los objetos
            int i = 0;

            var trends = Trends.GetTrendsAt(location);

            foreach (TextBlock dr in grd_TL.Children)
            {
                dr.Text = (i + 1) + "º " + trends.Trends.ToList()[i].Name;
                i++;
            }

            //Texto del label = i+"º #"+Trends.GetTrendsAt(i);
        }

        private void lbl_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            TextBlock clicked = (TextBlock)sender;
            String pos = clicked.Text.Substring(3);
            StatisticsWindow statistics = new StatisticsWindow(pos, idioma);
            statistics.Show();
            this.Close();
        }

        private void btn_location_Click(object sender, RoutedEventArgs e)
        {

            Button button = (Button)sender;

            if (idioma)
            {
                button.Content = "Mundial";
                idioma = false;
                setTrendigns(1);
            }
            else
            {
                button.Content = "España";
                idioma = true;
                setTrendigns(23424950);
            }
        }
    }
}
