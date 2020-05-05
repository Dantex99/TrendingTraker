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

        //Tweets por idioma
        String[] idiomas = { "Ingles", "Español", "Malayo", "Japones", "Portugues", "Frances", "Arábico", "Turco", "Thai", "Coreano", "otros" };
        int[] tweets = new int[11];

        public StatisticsWindow(String obj)
        {
            InitializeComponent();
            Auth.SetUserCredentials(
                "9F948nTxp7DLQlJkNHgC9Zct0",
                "taJoKFzKIaEdxk4wEUdZSZZmHD9FZ5pB9SP9wlHATY0qq37NEp",
                "1235663240224559104-3pZyrD0ZVyiK1lTd5OoONBA979nE3e",
                "hw6OuidUsyT9fSdoLdoxtGt3rZdj2OrUOGB7gMLVBCyrD"
                );

            Chart();

            lbl_SelectTt.Content = obj;

            //Stream
            Thread hiloStream = new Thread(() => TweetTraker(obj));

            hiloStream.Start();

        }

        //Actividad en vivo del #
        #region Live
        private void TweetTraker(String obj)
        {

            var stream = Stream.CreateFilteredStream();
            stream.AddTrack(obj);
            stream.MatchingTweetReceived += (sender, args) =>
            {
                
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


            };

            stream.StartStreamMatchingAllConditions();

        }

        #endregion

        #region chart
        private void Chart()
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
    }
}
