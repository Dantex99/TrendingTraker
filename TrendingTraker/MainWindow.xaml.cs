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
    /// Muestra por pantalla los 10 Trending
    /// mundiales o españoles y permite pasar a la ventana
    /// de análisis
    /// </summary>
    public partial class MainWindow : Window
    {

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

            //España por defecto
            setTrendigns(23424950);

        }

        /// <summary>
        /// Recoge y muestra los trendings de la localización
        /// pasada por parámetro
        /// </summary>
        /// <param name="location">Int correspondiente al WOEID de una localización</param>
        private void setTrendigns(int location)
        {
            int i = 0;

            //Extrae los trendings
            var trends = Trends.GetTrendsAt(location);

            //Recorre objetos correspondientes a TextBlock y les pone las trends en orden
            foreach (TextBlock dr in grd_TL.Children)
            {
                dr.Text = (i + 1) + "º " + trends.Trends.ToList()[i].Name;
                i++;
            }

        }

        /// <summary>
        /// Cierra la ventana actual e inicia la de análisis
        /// enviando por parametro el trending e idioma seleccionado
        /// </summary>
        /// <param name="sender">TextBlock Pulsado</param>
        /// <param name="e"></param>
        private void lbl_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            TextBlock clicked = (TextBlock)sender;

            //String del Texblock
            String trend = clicked.Text.Substring(3);

            //Inicio de StatisticsWindow
            StatisticsWindow statistics = new StatisticsWindow(trend, idioma);
            statistics.Show();
            this.Close();
        }

        /// <summary>
        /// Cambia la localización de los trends mostrados
        /// </summary>
        /// <param name="sender">El propio botón</param>
        /// <param name="e"></param>
        private void btn_location_Click(object sender, RoutedEventArgs e)
        {

            Button button = (Button)sender;

            //Intercambia la localización
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

        /// <summary>
        /// Muestra las ventanas de ayuda
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void img_ayuda_MouseEnter(object sender, MouseEventArgs e)
        {
            //Pasa a mostrar la ayuda
            grd_ayuda.Visibility = Visibility.Visible;

        }

        /// <summary>
        /// Oculata las ventanas de ayuda
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void img_ayuda_MouseLeft(object sender, MouseEventArgs e)
        {
            grd_ayuda.Visibility = Visibility.Hidden;
        }
    }
}
