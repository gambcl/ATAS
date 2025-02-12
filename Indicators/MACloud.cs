using ATAS.Indicators;
using ATAS.Indicators.Drawing;
using ATAS.Indicators.Technical;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace gambcl.ATAS.Indicators
{
    [DisplayName("MACloud")]
    [Category("gambcl-ATAS-Indicators")]
    public class MACloud : Indicator
    {
        #region Enums

        public enum MACloudDataSeriesIndexEnum
        {
            BullishCloudRangeDataSeries,
            BearishCloudRangeDataSeries,
            FastMAValueDataSeries,
            SlowMAValueDataSeries
        }

        public enum MATypeEnum
        {
            SMA,
            EMA
        }

        #endregion

        #region Members

        private MATypeEnum _maType = MATypeEnum.EMA;
        private int _fastPeriod = 9;
        private int _slowPeriod = 21;
        private SMA _smaFast = new();
        private SMA _smaSlow = new();
        private EMA _emaFast = new();
        private EMA _emaSlow = new();
        private readonly RangeDataSeries _bullishCloudSeries = new("BullishCloud", "Bullish Cloud")
        {
            RangeColor = DefaultColors.Green.GetWithTransparency(60).Convert(),
            DrawAbovePrice = false
        };
        private readonly RangeDataSeries _bearishCloudSeries = new("BearishCloud", "Bearish Cloud")
        {
            RangeColor = DefaultColors.Red.GetWithTransparency(60).Convert(),
            DrawAbovePrice = false
        };
        private readonly ValueDataSeries _fastMASeries = new("FastMA", "Fast MA")
        {
            VisualType = VisualMode.Line,
            Color = DefaultColors.Green.Convert(),
            Width = 2,
            DrawAbovePrice = false
        };
        private readonly ValueDataSeries _slowMASeries = new("SlowMA", "Slow MA")
        {
            VisualType = VisualMode.Line,
            Color = DefaultColors.Red.Convert(),
            Width = 2,
            DrawAbovePrice = false
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

        #endregion

        #region Constructor

        public MACloud()
        {
            DenyToChangePanel = true;

            // NOTE: The DataSeries must match the order found in MACloudDataSeriesIndexEnum.
            DataSeries[0] = _bullishCloudSeries;
            DataSeries.Add(_bearishCloudSeries);
            DataSeries.Add(_fastMASeries);
            DataSeries.Add(_slowMASeries);

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
            if (fastValue >= slowValue || (_fastMASeries[bar - 1] > _slowMASeries[bar - 1]))
            {
                // Bullish cloud
                _bullishCloudSeries[bar].Upper = fastValue;
                _bullishCloudSeries[bar].Lower = slowValue;
            }
            if (fastValue <= slowValue || (_fastMASeries[bar - 1] < _slowMASeries[bar - 1]))
            {
                // Bearish cloud
                _bearishCloudSeries[bar].Upper = slowValue;
                _bearishCloudSeries[bar].Lower = fastValue;
            }
        }

        #endregion
    }
}
