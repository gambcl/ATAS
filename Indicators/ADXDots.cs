using ATAS.Indicators;
using ATAS.Indicators.Drawing;
using ATAS.Indicators.Technical;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace gambcl.ATAS.Indicators
{
    [DisplayName("ADXDots")]
    [Category("gambcl-ATAS-Indicators")]
    public class ADXDots : Indicator
    {
        #region Enums

        public enum ADXDotsDataSeriesIndexEnum
        {
            WeakADXDotsValueDataSeries,
            MediumADXDotsValueDataSeries,
            StrongADXDotsValueDataSeries
        }

        #endregion

        #region Members

        private readonly ADX _adx = new();
        private decimal _displayLevel = 50m;
        private int _displayWidth = 9;
        private decimal _mediumTrendThreshold = 14m;
        private decimal _strongTrendThreshold = 25m;
        private readonly ValueDataSeries _adxDotsWeakSeries = new("WeakADXDots", "Weak ADX Dots")
        {
            VisualType = VisualMode.Dots,
            ShowZeroValue = false,
            ShowCurrentValue = false,
            ShowTooltip = false,
            Color = DefaultColors.White.Convert(),
            Width = 9,
            DrawAbovePrice = false,
            IsHidden = true
        };
        private readonly ValueDataSeries _adxDotsMediumSeries = new("MediumADXDots", "Medium ADX Dots")
        {
            VisualType = VisualMode.Dots,
            ShowZeroValue = false,
            ShowCurrentValue = false,
            ShowTooltip = false,
            Color = DefaultColors.White.Convert(),
            Width = 9,
            DrawAbovePrice = false,
            IsHidden = true
        };
        private readonly ValueDataSeries _adxDotsStrongSeries = new("StrongADXDots", "Strong ADX Dots")
        {
            VisualType = VisualMode.Dots,
            ShowZeroValue = false,
            ShowCurrentValue = false,
            ShowTooltip = false,
            Color = DefaultColors.White.Convert(),
            Width = 9,
            DrawAbovePrice = false,
            IsHidden = true
        };

        #endregion

        #region Properties

        [OFT.Attributes.Parameter]
        [Display(Name = "ADX Period", GroupName = "Settings", Order = 001)]
        [Range(1, 10000)]
        public int Period
        {
            get => _adx.Period;

            set
            {
                _adx.Period = value;
                RecalculateValues();
            }
        }

        [OFT.Attributes.Parameter]
        [Display(Name = "ADX Smoothing Period", GroupName = "Settings", Order = 002)]
        [Range(1, 10000)]
        public int SmoothPeriod
        {
            get => _adx.SmoothPeriod;

            set
            {
                _adx.SmoothPeriod = value;
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
                _adxDotsWeakSeries.Width = value;
                _adxDotsMediumSeries.Width = value;
                _adxDotsStrongSeries.Width = value;
                RecalculateValues();
            }
        }

        [Display(Name = "Medium Trend Threshold", GroupName = "Display", Description = "Minimum ADX value to be considered a medium trend.", Order = 103)]
        public decimal MediumTrendThreshold
        {
            get => _mediumTrendThreshold;

            set
            {
                _mediumTrendThreshold = value;
                RecalculateValues();
            }
        }

        [Display(Name = "Strong Trend Threshold", GroupName = "Display", Description = "Minimum ADX value to be considered a strong trend.", Order = 104)]
        public decimal StrongTrendThreshold
        {
            get => _strongTrendThreshold;

            set
            {
                _strongTrendThreshold = value;
                RecalculateValues();
            }
        }

        [Display(Name = "Weak Trend Color", GroupName = "Display", Description = "Dot color used to indicate a weak trend.", Order = 105)]
        public Color WeakTrendColor
        {
            get => _adxDotsWeakSeries.Color.Convert();

            set
            {
                _adxDotsWeakSeries.Color = value.Convert();
                RecalculateValues();
            }
        }

        [Display(Name = "Medium Trend Color", GroupName = "Display", Description = "Dot color used to indicate a medium trend.", Order = 106)]
        public Color MediumTrendColor
        {
            get => _adxDotsMediumSeries.Color.Convert();

            set
            {
                _adxDotsMediumSeries.Color = value.Convert();
                RecalculateValues();
            }
        }

        [Display(Name = "Strong Trend Color", GroupName = "Display", Description = "Dot color used to indicate a strong trend.", Order = 107)]
        public Color StrongTrendColor
        {
            get => _adxDotsStrongSeries.Color.Convert();

            set
            {
                _adxDotsStrongSeries.Color = value.Convert();
                RecalculateValues();
            }
        }

        #endregion

        #region Constructor

        public ADXDots() : base(true)
        {
            Panel = IndicatorDataProvider.NewPanel;

            DataSeries[0] = _adxDotsWeakSeries;
            DataSeries.Add(_adxDotsMediumSeries);
            DataSeries.Add(_adxDotsStrongSeries);

            Period = 14;
            SmoothPeriod = 14;
            DisplayLevel = 50m;
            DisplayWidth = 9;
            MediumTrendThreshold = 14m;
            StrongTrendThreshold = 25m;
            WeakTrendColor = Color.FromArgb(255, 225, 190, 231);
            MediumTrendColor = Color.FromArgb(255, 186, 104, 200);
            StrongTrendColor = Color.FromArgb(255, 123, 31, 162);

            Add(_adx);
        }

        #endregion

        #region Indicator methods

        protected override void OnCalculate(int bar, decimal value)
        {
            if (bar == 0)
            {
                _adxDotsWeakSeries.Clear();
                _adxDotsMediumSeries.Clear();
                _adxDotsStrongSeries.Clear();
                return;
            }

            if (InstrumentInfo is null)
                return;

            if (CurrentBar < Math.Max(Period, SmoothPeriod))
                return;

            var adx = _adx[bar];
            if (adx > _strongTrendThreshold)
            {
                _adxDotsWeakSeries[bar] = 0m;
                _adxDotsMediumSeries[bar] = 0m;
                _adxDotsStrongSeries[bar] = _displayLevel;
            }
            else if (adx > _mediumTrendThreshold)
            {
                _adxDotsWeakSeries[bar] = 0m;
                _adxDotsMediumSeries[bar] = _displayLevel;
                _adxDotsStrongSeries[bar] = 0m;
            }
            else
            {
                _adxDotsWeakSeries[bar] = _displayLevel;
                _adxDotsMediumSeries[bar] = 0m;
                _adxDotsStrongSeries[bar] = 0m;
            }
        }

        #endregion
    }
}
