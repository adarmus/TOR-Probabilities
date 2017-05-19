using GalaSoft.MvvmLight;
using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Media;

namespace Probs.Wpf.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        readonly ProbabilityGenerator _probabilityGenerator;
        readonly int[] _tnList;

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            _probabilityGenerator = new ProbabilityGenerator();
            _tnList = new int[] { 8, 10, 12, 14, 16, 18 };

            this.Series = MakeSeriesCollection();
            this.Labels = MakeLabels();
            YFormatter = value => value.ToString("0%");
        }

        string[] MakeLabels()
        {
            return _tnList.Select(tn => string.Format("TN {0}", tn)).ToArray();
        }

        ColourStack _colours;

        SeriesCollection MakeSeriesCollection()
        {
            var seriesList = new SeriesCollection();

            var dice = new int[] { 0, 1, 2, 3, 4, 5, 6 };

            _colours = new ColourStack();

            IEnumerable<LineSeries> series = dice.Select(MakeLineSeries);

            var x = new SeriesCollection();

            x.AddRange(series);

            return x;
        }

        LineSeries MakeLineSeries(int dice)
        {
            double[] successProbability = _probabilityGenerator.GetProbabilities(dice, _tnList);

            var series = new LineSeries
            {
                Values = new ChartValues<double>(successProbability),
                Title = string.Format("{0}d6", dice),
                Fill = Brushes.Transparent,
                Stroke = _colours.GetNextBrush()
            };

            return series;
        }

        public SeriesCollection Series { get; set; }

        public string [] Labels { get; set; }

        public Func<double, string> YFormatter { get; set; }
    }
}