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
            HeikenAshiDotsValueDataSeries
        }

        #endregion

        #region Members

        private readonly HeikenAshi _ha = new();
        private decimal _displayLevel = 50m;
        private int _displayWidth = 9;
        private Color _haDotsBullishColor = DefaultColors.Green;
        private Color _haDotsChangingColor = DefaultColors.Yellow;
        private Color _haDotsBearishColor = DefaultColors.Red;
        private readonly ValueDataSeries _haDotsSeries = new("HeikenAshiDots", "Heiken Ashi Dots")
        {
            VisualType = VisualMode.Dots,
            ShowZeroValue = false,
            ShowCurrentValue = false,
            ShowTooltip = false,
            Color = DefaultColors.White.Convert(),
            Width = 10,
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
                _haDotsSeries.Width = value;
                RecalculateValues();
            }
        }

        [Display(Name = "Bullish Trend Color", GroupName = "Display", Description = "Dot color used to indicate a bullish trend.", Order = 105)]
        public Color BullishTrendColor
        {
            get => _haDotsBullishColor;

            set
            {
                _haDotsBullishColor = value;
                RecalculateValues();
            }
        }

        [Display(Name = "Changing Trend Color", GroupName = "Display", Description = "Dot color used to indicate a changing trend.", Order = 106)]
        public Color ChangingTrendColor
        {
            get => _haDotsChangingColor;

            set
            {
                _haDotsChangingColor = value;
                RecalculateValues();
            }
        }

        [Display(Name = "Bearish Trend Color", GroupName = "Display", Description = "Dot color used to indicate a bearish trend.", Order = 107)]
        public Color BearishTrendColor
        {
            get => _haDotsBearishColor;

            set
            {
                _haDotsBearishColor = value;
                RecalculateValues();
            }
        }

        #endregion

        #region Constructor

        public HeikenAshiDots() : base(true)
        {
            Panel = IndicatorDataProvider.NewPanel;

            // NOTE: The DataSeries must match the order found in HeikenAshiDotsDataSeriesIndexEnum.
            DataSeries[0] = _haDotsSeries;

            DisplayLevel = 50m;
            DisplayWidth = 10;
            BullishTrendColor = DefaultColors.Green;
            ChangingTrendColor = DefaultColors.Yellow;
            BearishTrendColor = DefaultColors.Red;

            Add(_ha);
        }

        #endregion

        #region Indicator methods

        protected override void OnRecalculate()
        {
            base.OnRecalculate();

            _haDotsSeries.Clear();
        }

        protected override void OnCalculate(int bar, decimal value)
        {
            if (InstrumentInfo is null)
                return;

            if (CurrentBar < 3)
                return;

            var haCandles = (CandleDataSeries)(_ha.DataSeries[1]);
            var prevHACandle = haCandles[bar-1];
            var currHACandle = haCandles[bar];
            var prevCandleTrend = (prevHACandle.Close >= prevHACandle.Open) ? 1 : -1;
            var currCandleTrend = (currHACandle.Close >= currHACandle.Open) ? 1 : -1;
            _haDotsSeries[bar] = _displayLevel;
            if (currCandleTrend == prevCandleTrend && currCandleTrend > 0)
            {
                _haDotsSeries.Colors[bar] = _haDotsBullishColor;
            }
            else if (currCandleTrend == prevCandleTrend && currCandleTrend < 0)
            {
                _haDotsSeries.Colors[bar] = _haDotsBearishColor;
            }
            else
            {
                _haDotsSeries.Colors[bar] = _haDotsChangingColor;
            }
        }

        #endregion
    }
}
