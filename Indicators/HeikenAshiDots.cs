using ATAS.Indicators;
using ATAS.Indicators.Drawing;
using ATAS.Indicators.Technical;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace gambcl.ATAS.Indicators
{
    [DisplayName("HeikenAshiDots")]
    [Category("gambcl-ATAS-Indicators")]
    public class HeikenAshiDots : Indicator
    {
        #region Enums

        public enum HeikenAshiDotsDataSeriesIndexEnum
        {
            BullishTrendDotsValueDataSeries,
            ChangingTrendDotsValueDataSeries,
            BearishTrendDotsValueDataSeries
        }

        #endregion

        #region Members

        private readonly HeikenAshi _ha = new();
        private decimal _displayLevel = 50m;
        private int _displayWidth = 9;
        private readonly ValueDataSeries _trendDotsBullishSeries = new("BullishTrendDots", "Bullish Trend Dots")
        {
            VisualType = VisualMode.Dots,
            ShowZeroValue = false,
            ShowCurrentValue = false,
            ShowTooltip = false,
            Color = DefaultColors.Green.Convert(),
            Width = 9,
            DrawAbovePrice = false,
            IsHidden = true
        };
        private readonly ValueDataSeries _trendDotsChangingSeries = new("ChangingTrendDots", "Changing Trend Dots")
        {
            VisualType = VisualMode.Dots,
            ShowZeroValue = false,
            ShowCurrentValue = false,
            ShowTooltip = false,
            Color = DefaultColors.Yellow.Convert(),
            Width = 9,
            DrawAbovePrice = false,
            IsHidden = true
        };
        private readonly ValueDataSeries _trendDotsBearishSeries = new("BearishTrendDots", "Bearish Trend Dots")
        {
            VisualType = VisualMode.Dots,
            ShowZeroValue = false,
            ShowCurrentValue = false,
            ShowTooltip = false,
            Color = DefaultColors.Red.Convert(),
            Width = 9,
            DrawAbovePrice = false,
            IsHidden = true
        };

        #endregion

        #region Properties

        [Display(Name = "Display Level", GroupName = "Display", Description = "Value level at which the row of dots will be displayed.", Order = 101)]
        public decimal DisplayLevel
        {
            get => _displayLevel;

            set
            {
                _displayLevel = value;
                RecalculateValues();
            }
        }

        [Display(Name = "Display Width", GroupName = "Display", Description = "Width of dots.", Order = 102)]
        public int DisplayWidth
        {
            get => _displayWidth;

            set
            {
                _displayWidth = value;
                _trendDotsBullishSeries.Width = value;
                _trendDotsChangingSeries.Width = value;
                _trendDotsBearishSeries.Width = value;
                RecalculateValues();
            }
        }

        [Display(Name = "Bullish Trend Color", GroupName = "Display", Description = "Dot color used to indicate a bullish trend.", Order = 105)]
        public Color BullishTrendColor
        {
            get => _trendDotsBullishSeries.Color.Convert();

            set
            {
                _trendDotsBullishSeries.Color = value.Convert();
                RecalculateValues();
            }
        }

        [Display(Name = "Changing Trend Color", GroupName = "Display", Description = "Dot color used to indicate a changing trend.", Order = 106)]
        public Color ChangingTrendColor
        {
            get => _trendDotsChangingSeries.Color.Convert();

            set
            {
                _trendDotsChangingSeries.Color = value.Convert();
                RecalculateValues();
            }
        }

        [Display(Name = "Bearish Trend Color", GroupName = "Display", Description = "Dot color used to indicate a bearish trend.", Order = 107)]
        public Color BearishTrendColor
        {
            get => _trendDotsBearishSeries.Color.Convert();

            set
            {
                _trendDotsBearishSeries.Color = value.Convert();
                RecalculateValues();
            }
        }

        #endregion

        #region Constructor

        public HeikenAshiDots() : base(true)
        {
            Panel = IndicatorDataProvider.NewPanel;

            DataSeries[0] = _trendDotsBullishSeries;
            DataSeries.Add(_trendDotsChangingSeries);
            DataSeries.Add(_trendDotsBearishSeries);

            DisplayLevel = 50m;
            DisplayWidth = 9;
            BullishTrendColor = DefaultColors.Green;
            ChangingTrendColor = DefaultColors.Yellow;
            BearishTrendColor = DefaultColors.Red;

            Add(_ha);
        }

        #endregion

        #region Indicator methods

        protected override void OnCalculate(int bar, decimal value)
        {
            if (bar == 0)
            {
                _trendDotsBullishSeries.Clear();
                _trendDotsChangingSeries.Clear();
                _trendDotsBearishSeries.Clear();
                return;
            }

            if (InstrumentInfo is null)
                return;

            if (CurrentBar < 3)
                return;

            var haCandles = (CandleDataSeries)(_ha.DataSeries[1]);
            var prevHACandle = haCandles[bar-1];
            var currHACandle = haCandles[bar];
            var prevCandleTrend = (prevHACandle.Close >= prevHACandle.Open) ? 1 : -1;
            var currCandleTrend = (currHACandle.Close >= currHACandle.Open) ? 1 : -1;
            if (currCandleTrend == prevCandleTrend && currCandleTrend > 0)
            {
                _trendDotsBullishSeries[bar] = _displayLevel;
                _trendDotsChangingSeries[bar] = 0m;
                _trendDotsBearishSeries[bar] = 0m;
            }
            else if (currCandleTrend == prevCandleTrend && currCandleTrend < 0)
            {
                _trendDotsBullishSeries[bar] = 0m;
                _trendDotsChangingSeries[bar] = 0m;
                _trendDotsBearishSeries[bar] = _displayLevel;
            }
            else
            {
                _trendDotsBullishSeries[bar] = 0m;
                _trendDotsChangingSeries[bar] = _displayLevel;
                _trendDotsBearishSeries[bar] = 0m;
            }
        }

        #endregion
    }
}
