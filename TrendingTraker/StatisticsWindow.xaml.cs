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
        int tweetsGlobales = 1;
        int tweetsTendencia = 1;

        //Inicia los procesos de analisis y creado de gráficas
        //muestra por pantalla el elemento de búsqueda
        public StatisticsWindow(String obj, bool localizacion)
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

            Thread tweetPopular = new Thread(() => PopularTweet(obj));
            tweetPopular.Start();

            if (localizacion)
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

            Thread impacto = new Thread(() => Impacto());
            impacto.Start();


        }

        #region España
        #region Tweets en vivo
        private void TweetTrakerEsp(String obj)
        {

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

                tweetsTendencia++;

                //Datos
                this.Dispatcher.Invoke(() =>
                {
                    lbl_tTweets.Content = "Tweets: " + Formato(tweetsTendencia);
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

                tweetsTendencia++;

                //Datos
                this.Dispatcher.Invoke(() =>
                {
                    lbl_tTweets.Content = "Tweets: " + Formato(tweetsTendencia);
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

        #region Tweet Popular
        public void PopularTweet(String obj)
        {
            do
            {
                var searchParameter = new SearchTweetsParameters(obj)
                {
                    SearchType = SearchResultType.Popular,
                    MaximumNumberOfResults = 1,
                };

                var tweets = Search.SearchTweets(searchParameter);

                for (int i = 0; i < 10; i++)
                {
                    //Extraemos el tweet
                    var tweet = tweets.ToList()[i];

                    //Fecha creación
                    lbl_tiempo.Content = tweet.CreatedAt.ToString();

                    //Texto
                    lbl_text.Text = tweet.Text;

                    //Interacciones
                    lbl_like.Content = Formato(tweet.FavoriteCount);
                    lbl_rt.Content = Formato(tweet.RetweetCount);

                    //Extraemos el usuario
                    var user = tweet.CreatedBy;

                    //Imagen de perfil
                    img_profile.Source = new BitmapImage(new Uri(user.ProfileImageUrl));

                    //Verificado
                    if (!user.Verified)
                    {
                        img_verificado.Visibility = Visibility.Hidden;
                        lbl_verificado.Visibility = Visibility.Hidden;
                    }
                    else
                    {
                        img_verificado.Visibility = Visibility.Visible;
                        lbl_verificado.Visibility = Visibility.Visible;
                    }

                    //Nombre usuario
                    lbl_name.Content = user.Name;

                    //@Usuario
                    lbl_arroba.Content = user.ScreenName;

                    Thread.Sleep(15000);
                }
            } while (true);
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

        #region Datos
        //LLeva la cuenta de los tweets publicados en el mundo
        public void CuentaGlobal()
        {
            var stream = Stream.CreateSampleStream();
            stream.TweetReceived += (sender, args) =>
            {
                tweetsGlobales++;
                this.Dispatcher.Invoke(() =>
                {
                    lbl_gTweets.Content = "Tweets globales: " + Formato(tweetsGlobales);
                    
                });
            };
            stream.StartStream();
            
        }

        //Calcula en % el impacto a nivel mundial
        public void Impacto()
        {
            do
            {
                
                decimal impacto = ((decimal)tweetsTendencia / (decimal)tweetsGlobales * 100m);
                this.Dispatcher.Invoke(() =>
                {
                    lbl_impacto.Content = "Un " + String.Format("{0:0}",impacto) + "% del mundo habla de esto";
                    TopLenguage();
                });
                Thread.Sleep(5000);
            } while (true);
        }

        public void TopLenguage()
        {
            int max = 0;
            int total = 0;
            int Serie = 0;
            for(int i = 0; i < myPieChart.Series.Count; i++)
            {
                int value = (int) myPieChart.Series[i].Values[0];
                if ( value > max && i != myPieChart.Series.Count - 1)
                {
                    max = value;
                    Serie = i;
                }
                total += value;
            }
            decimal porcentaje = ((decimal)max / (decimal)total * 100m);
            lbl_topLenguage.Content = "Lenguaje mas hablado: " + myPieChart.Series[Serie].Title;
            lbl_porcentaje.Content = (String.Format("{0:0}", porcentaje)) + "% respecto al total";
        }
        #endregion
    }
}
