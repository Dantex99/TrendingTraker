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

            int count = 0;
            int en = 0;
            int es = 0;
            int fr = 0;
            int df = 0;

            var stream = Stream.CreateFilteredStream();
            stream.AddTrack(obj);
            stream.MatchingTweetReceived += (sender, args) =>
            {
                count++;

                this.Dispatcher.Invoke(() =>
                {

                    switch (args.Tweet.Language.ToString())
                    {
                        case "English":
                            en++;
                            lbl_InglesEn.Content = "Tweets en ingles: " + en;
                            break;

                        case "Spanish":
                            es++;
                            lbl_EspanolEn.Content = "Tweets en español: " + es;
                            break;

                        case "French":
                            fr++;
                            lbl_FrancesEn.Content = "Tweets en frances: " + fr;
                            break;

                        default:
                            df++;
                            break;
                    }

                

                    lbl_Tweets.Content = "Tweets: " + count;

                });


            };

            stream.StartStreamMatchingAllConditions();

        }

        #endregion

        #region chart
            private void Chart()
        {
            PointLabel = chartPoint =>  
            string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation);

            DataContext = this;
        }

        public Func<ChartPoint, string> PointLabel { get; set; }

        private void Chart_OnDataClick(object sender, ChartPoint chartpoint)
        {
            var chart = (LiveCharts.Wpf.PieChart)chartpoint.ChartView;

            //clear selected slice.
            foreach (PieSeries series in chart.Series)
                series.PushOut = 0;

            var selectedSeries = (PieSeries)chartpoint.SeriesView;
            selectedSeries.PushOut = 8;
        }
        #endregion
    }
}
