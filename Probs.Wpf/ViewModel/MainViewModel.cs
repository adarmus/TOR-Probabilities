using GalaSoft.MvvmLight;
using LiveCharts;
using LiveCharts.Wpf;
using System.Collections.Generic;
using System.Linq;

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
        }

        SeriesCollection MakeSeriesCollection()
        {
            var seriesList = new SeriesCollection();

            var dice = new int[] { 0, 1, 2, 3, 4, 5, 6 };

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
                Values = new ChartValues<double>(successProbability)
            };

            return series;
        }

        public SeriesCollection Series { get; set; }
    }
}