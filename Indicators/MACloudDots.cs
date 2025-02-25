using ATAS.Indicators;
using ATAS.Indicators.Drawing;
using ATAS.Indicators.Technical;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace gambcl.ATAS.Indicators
{
    [DisplayName("MACloudDots")]
    [Category("gambcl-ATAS-Indicators")]
    public class MACloudDots : Indicator
    {
        #region Enums

        public enum MACloudDotsDataSeriesIndexEnum
        {
            FastMAValueDataSeries,
            SlowMAValueDataSeries,
            MACloudDotsValueDataSeries
        }

        public enum MATypeEnum
        {
            SMA,
            EMA
        }

        #endregion

        #region Constants

        const decimal DefaultDisplayLevel = 50m;
        const int DefaultDisplayWidth = 5;

        #endregion

        #region Members

        private MATypeEnum _maType = MATypeEnum.EMA;
        private int _fastPeriod = 9;
        private int _slowPeriod = 21;
        private decimal _displayLevel = DefaultDisplayLevel;
        private int _displayWidth = DefaultDisplayWidth;
        private Color _maCloudDotsBullishTrendColor = DefaultColors.Green;
        private Color _maCloudDotsBearishTrendColor = DefaultColors.Red;
        private SMA _smaFast = new();
        private SMA _smaSlow = new();
        private EMA _emaFast = new();
        private EMA _emaSlow = new();
        private readonly ValueDataSeries _fastMASeries = new("FastMA", "Fast MA")
        {
            VisualType = VisualMode.Hide,
            IsHidden = true
        };
        private readonly ValueDataSeries _slowMASeries = new("SlowMA", "Slow MA")
        {
            VisualType = VisualMode.Hide,
            IsHidden = true
        };
        private readonly ValueDataSeries _maCloudDotsSeries = new("MACloudDots", "MA Cloud Dots")
        {
            VisualType = VisualMode.Dots,
            ShowZeroValue = false,
            ShowCurrentValue = false,
            ShowTooltip = false,
            Color = Color.Transparent.Convert(),
            Width = DefaultDisplayWidth,
            DrawAbovePrice = false,
            IsHidden = true
        };

        #endregion

        #region Properties

        [OFT.Attributes.Parameter]
        [Display(Name = "MA Type", GroupName = "Settings", Description = "The type of Moving Average.", Order = 001)]
        public MATypeEnum MAType
        {
            get => _maType;

            set
            {
                _maType = value;
                _fastMASeries.Name = $"{_fastPeriod} {_maType}";
                _slowMASeries.Name = $"{_slowPeriod} {_maType}";
                _maCloudDotsSeries.Name = $"{_maType} Cloud Dots";
                RecalculateValues();
            }
        }

        [OFT.Attributes.Parameter]
        [Display(Name = "Fast Period", GroupName = "Settings", Description = "The period of the fast Moving Average.", Order = 002)]
        [Range(1, 1000)]
        public int FastPeriod
        {
            get => _fastPeriod;

            set
            {
                _fastPeriod = value;
                _smaFast.Period = value;
                _emaFast.Period = value;
                _fastMASeries.Name = $"{_fastPeriod} {_maType}";
                RecalculateValues();
            }
        }

        [OFT.Attributes.Parameter]
        [Display(Name = "Slow Period", GroupName = "Settings", Description = "The period of the slow Moving Average.", Order = 003)]
        [Range(1, 1000)]
        public int SlowPeriod
        {
            get => _slowPeriod;

            set
            {
                _slowPeriod = value;
                _smaSlow.Period = value;
                _emaSlow.Period = value;
                _slowMASeries.Name = $"{_slowPeriod} {_maType}";
                RecalculateValues();
            }
        }

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
                _maCloudDotsSeries.Width = value;
                RecalculateValues();
            }
        }

        [Display(Name = "Bullish Trend Color", GroupName = "Display", Description = "Dot color used to indicate a bullish trend.", Order = 103)]
        public Color BullishTrendColor
        {
            get => _maCloudDotsBullishTrendColor;

            set
            {
                _maCloudDotsBullishTrendColor = value;
                RecalculateValues();
            }
        }

        [Display(Name = "Bearish Trend Color", GroupName = "Display", Description = "Dot color used to indicate a bearish trend.", Order = 104)]
        public Color BearishTrendColor
        {
            get => _maCloudDotsBearishTrendColor;

            set
            {
                _maCloudDotsBearishTrendColor = value;
                RecalculateValues();
            }
        }

        #endregion

        #region Constructor

        public MACloudDots()
        {
            Panel = IndicatorDataProvider.NewPanel;

            // NOTE: The DataSeries must match the order found in MACloudDotsDataSeriesIndexEnum.
            DataSeries[0] = _fastMASeries;
            DataSeries.Add(_slowMASeries);
            DataSeries.Add(_maCloudDotsSeries);

            DisplayLevel = DefaultDisplayLevel;
            DisplayWidth = DefaultDisplayWidth;
            BullishTrendColor = DefaultColors.Green;
            BearishTrendColor = DefaultColors.Red;

            MAType = MATypeEnum.EMA;
            FastPeriod = 9;
            SlowPeriod = 21;
        }

        #endregion

        #region Indicator methods

        protected override void OnRecalculate()
        {
            base.OnRecalculate();

            DataSeries.ForEach(ds => ds.Clear());

            _smaFast = new() { Period = _fastPeriod };
            _smaSlow = new() { Period = _slowPeriod };
            _emaFast = new() { Period = _fastPeriod };
            _emaSlow = new() { Period = _slowPeriod };
        }

        protected override void OnCalculate(int bar, decimal value)
        {
            if (bar == 0)
                return;

            if (CurrentBar < Math.Max(_fastPeriod, _slowPeriod))
                return;

            decimal fastValue = 0m;
            decimal slowValue = 0m;
            if (MAType == MATypeEnum.EMA)
            {
                fastValue = _emaFast.Calculate(bar, value);
                slowValue = _emaSlow.Calculate(bar, value);
            }
            else
            {
                fastValue = _smaFast.Calculate(bar, value);
                slowValue = _smaSlow.Calculate(bar, value);
            }
            _fastMASeries[bar] = fastValue;
            _slowMASeries[bar] = slowValue;
            _maCloudDotsSeries[bar] = _displayLevel;
            if (fastValue > slowValue)
            {
                _maCloudDotsSeries.Colors[bar] = _maCloudDotsBullishTrendColor;
            }
            else if (fastValue < slowValue)
            {
                _maCloudDotsSeries.Colors[bar] = _maCloudDotsBearishTrendColor;
            }
            else
            {
                _maCloudDotsSeries.Colors[bar] = Color.Transparent;
            }
        }

        #endregion
    }
}
