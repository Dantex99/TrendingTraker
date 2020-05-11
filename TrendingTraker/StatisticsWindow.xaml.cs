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
using System.Windows.Shapes;
using Tweetinvi;
using System.Threading;
using Tweetinvi.Parameters;
using Tweetinvi.Models;
using LiveCharts;
using LiveCharts.Wpf;

namespace TrendingTraker
{
    /// <summary>
    /// Lógica de interacción para Window1.xaml
    /// </summary>
    public partial class StatisticsWindow : Window
    {

        //Inicia los procesos de analisis y creado de gráficas
        //muestra por pantalla el elemento de búsqueda
        public StatisticsWindow(String obj, bool idioma)
        {
            //Autorización
            InitializeComponent();
            Auth.SetUserCredentials(
                "9F948nTxp7DLQlJkNHgC9Zct0",
                "taJoKFzKIaEdxk4wEUdZSZZmHD9FZ5pB9SP9wlHATY0qq37NEp",
                "1235663240224559104-3pZyrD0ZVyiK1lTd5OoONBA979nE3e",
                "hw6OuidUsyT9fSdoLdoxtGt3rZdj2OrUOGB7gMLVBCyrD"
                );

            lbl_SelectTt.Content = obj;
            Thread hiloStream;

            PopularTweet(obj);

            if (idioma)
            {
                //genera las gráficas
                GraficaEsp();

                //inicia recogida del trafico de tweets
                hiloStream = new Thread(() => TweetTrakerEsp(obj));
            }
            else
            {
                //genera las gráficas
                GraficaGlobal();

                //inicia recogida del trafico de tweets
                hiloStream = new Thread(() => TweetTrakerGlobal(obj));
            }


            hiloStream.Start();

            Thread tweetsStream = new Thread(() => CuentaGlobal());
            tweetsStream.Start();

        }

        #region España
        #region Tweets en vivo
        private void TweetTrakerEsp(String obj)
        {
            //Data
            int tweetsTotales = 0;


            int[] tweets = new int[5];
            var stream = Stream.CreateFilteredStream();
            stream.AddTrack(obj);
            //Clasifica cada tweet recogido
            stream.MatchingTweetReceived += (sender, args) =>
            {
                //Clasificación por lenguage
                switch (args.Tweet.Language.ToString())
                {
                    case "English":
                        tweets[0]++;
                        myPieChart.Series[0].Values[0] = tweets[0];
                        break;
                    case "Spanish":
                        tweets[1]++;
                        myPieChart.Series[1].Values[0] = tweets[1];
                        break;
                    case "Portuguese":
                        tweets[2]++;
                        myPieChart.Series[2].Values[0] = tweets[2];
                        break;
                    case "French":
                        tweets[3]++;
                        myPieChart.Series[3].Values[0] = tweets[3];
                        break;
                    default:
                        tweets[4]++;
                        myPieChart.Series[4].Values[0] = tweets[4];
                        break;
                }

                tweetsTotales++;

                //Datos
                this.Dispatcher.Invoke(() =>
                {
                    lbl_tTweets.Content = "Tweets: " + Formato(tweetsTotales);
                });


            };

            stream.StartStreamMatchingAllConditions();

        }
        #endregion
        #region gráfica
        private void GraficaEsp()
        {
            myPieChart.Series.Add(new PieSeries { Title = "Ingles", Fill = Brushes.Blue, StrokeThickness = 0, Values = new ChartValues<int> { 0 } });
            myPieChart.Series.Add(new PieSeries { Title = "Español", Fill = Brushes.Red, StrokeThickness = 0, Values = new ChartValues<int> { 0 } });
            myPieChart.Series.Add(new PieSeries { Title = "Portugues", Fill = Brushes.Green, StrokeThickness = 0, Values = new ChartValues<int> { 0 } });
            myPieChart.Series.Add(new PieSeries { Title = "Frances", Fill = Brushes.AliceBlue, StrokeThickness = 0, Values = new ChartValues<int> { 0 } });
            myPieChart.Series.Add(new PieSeries { Title = "Otros", Fill = Brushes.Gray, StrokeThickness = 0, Values = new ChartValues<int> { 1 } });

            DataContext = this;
        }
        #endregion
        #endregion

        #region Global
        #region Tweets en vivo
        private void TweetTrakerGlobal(String obj)
        {
            //Data
            int tweetsTotales = 0;

            int[] tweets = new int[11];
            var stream = Stream.CreateFilteredStream();
            stream.AddTrack(obj);
            //Clasifica cada tweet recogido
            stream.MatchingTweetReceived += (sender, args) =>
            {

                //Lenguage
                switch (args.Tweet.Language.ToString())
                {
                    case "English":
                        tweets[0]++;
                        myPieChart.Series[0].Values[0] = tweets[0];
                        break;

                    case "Spanish":
                        tweets[1]++;
                        myPieChart.Series[1].Values[0] = tweets[1];
                        break;

                    case "Malayalam":
                        tweets[2]++;
                        myPieChart.Series[2].Values[0] = tweets[2];
                        break;
                    case "Japanese":
                        tweets[3]++;
                        myPieChart.Series[3].Values[0] = tweets[3];
                        break;
                    case "Portuguese":
                        tweets[4]++;
                        myPieChart.Series[4].Values[0] = tweets[4];
                        break;
                    case "French":
                        tweets[5]++;
                        myPieChart.Series[5].Values[0] = tweets[5];
                        break;
                    case "Arabic":
                        tweets[6]++;
                        myPieChart.Series[6].Values[0] = tweets[6];
                        break;
                    case "Turkish":
                        tweets[7]++;
                        myPieChart.Series[7].Values[0] = tweets[7];
                        break;
                    case "Thai":
                        tweets[8]++;
                        myPieChart.Series[8].Values[0] = tweets[8];
                        break;
                    case "Korean":
                        tweets[9]++;
                        myPieChart.Series[9].Values[0] = tweets[9];
                        break;

                    default:
                        tweets[10]++;
                        myPieChart.Series[10].Values[0] = tweets[10];
                        break;
                }

                tweetsTotales++;

                //Datos
                this.Dispatcher.Invoke(() =>
                {
                    lbl_tTweets.Content = "Tweets: " + Formato(tweetsTotales);
                });
            };

            stream.StartStreamMatchingAllConditions();

        }

        #endregion

        #region Gráfica
        private void GraficaGlobal()
        {
            myPieChart.Series.Add(new PieSeries { Title = "Ingles", Fill = Brushes.Blue, StrokeThickness = 0, Values = new ChartValues<int> { 0 } });
            myPieChart.Series.Add(new PieSeries { Title = "Español", Fill = Brushes.Red, StrokeThickness = 0, Values = new ChartValues<int> { 0 } });
            myPieChart.Series.Add(new PieSeries { Title = "Malayo", Fill = Brushes.Beige, StrokeThickness = 0, Values = new ChartValues<int> { 0 } });
            myPieChart.Series.Add(new PieSeries { Title = "Japones", Fill = Brushes.WhiteSmoke, StrokeThickness = 0, Values = new ChartValues<int> { 0 } });
            myPieChart.Series.Add(new PieSeries { Title = "Portugues", Fill = Brushes.Green, StrokeThickness = 0, Values = new ChartValues<int> { 0 } });
            myPieChart.Series.Add(new PieSeries { Title = "Frances", Fill = Brushes.AliceBlue, StrokeThickness = 0, Values = new ChartValues<int> { 0 } });
            myPieChart.Series.Add(new PieSeries { Title = "Arábico", Fill = Brushes.Yellow, StrokeThickness = 0, Values = new ChartValues<int> { 0 } });
            myPieChart.Series.Add(new PieSeries { Title = "Turco", Fill = Brushes.Brown, StrokeThickness = 0, Values = new ChartValues<int> { 0 } });
            myPieChart.Series.Add(new PieSeries { Title = "Thai", Fill = Brushes.DarkCyan, StrokeThickness = 0, Values = new ChartValues<int> { 0 } });
            myPieChart.Series.Add(new PieSeries { Title = "Coreano", Fill = Brushes.DarkSalmon, StrokeThickness = 0, Values = new ChartValues<int> { 0 } });
            myPieChart.Series.Add(new PieSeries { Title = "Otros", Fill = Brushes.Gray, StrokeThickness = 0, Values = new ChartValues<int> { 1 } });

            DataContext = this;
        }
        #endregion
        #endregion

        #region Popular
        public void PopularTweet(String obj)
        {
            var searchParameter = new SearchTweetsParameters(obj)
            {
                SearchType = SearchResultType.Popular,
                MaximumNumberOfResults = 1,
            };

            var tweets = Search.SearchTweets(searchParameter);

            //Extraemos el tweet
            var tweet = tweets.ToList()[0];

            //Fecha creación
            lbl_tiempo.Content = tweet.CreatedAt.ToString();

            //Texto
            lbl_text.Text = tweet.Text;

            //Interacciones
            lbl_like.Content = Formato(tweet.FavoriteCount);
            lbl_rt.Content = Formato(tweet.RetweetCount);
            //lbl_com.Content = tweet.count;

            //Extraemos el usuario
            var user = tweet.CreatedBy;

            //Imagen de perfil
            img_profile.Source = new BitmapImage(new Uri(user.ProfileImageUrl));

            //Verificado
            if (!user.Verified)
            {
                img_verificado.Visibility = Visibility.Hidden;
            }
            else
            {
                img_verificado.Visibility = Visibility.Visible;
            }

            //Nombre usuario
            lbl_name.Content = user.Name;

            //@Usuario
            lbl_arroba.Content = user.ScreenName;
        }

        public static string Formato(int number)
        {

            if (number > 1000)
            {
                return string.Format("{0:#,0,k}", number);
            }
            else if(number > 0)
            {
                return number.ToString();
            }
            else
            {
                return "0";
            }
        }
        #endregion

        #region Cuenta Global
        public void CuentaGlobal()
        {
            int count = 0;
            var stream = Stream.CreateSampleStream();
            stream.TweetReceived += (sender, args) =>
            {
                count++;
                this.Dispatcher.Invoke(() =>
                {
                    lbl_gTweets.Content = "Tweets globales: " + Formato(count);
                });
            };
            stream.StartStream();
            
        }
        #endregion

    }
}
