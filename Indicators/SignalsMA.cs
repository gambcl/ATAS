using ATAS.Indicators;
using ATAS.Indicators.Drawing;
using ATAS.Indicators.Technical;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace gambcl.ATAS.Indicators
{
    [DisplayName("SignalsMA")]
    [Category("gambcl-ATAS-Indicators")]
    public class SignalsMA : Indicator
    {
        #region Enums

        public enum SignalsMADataSeriesIndexEnum
        {
            MAValueDataSeries,
            BuySignalValueDataSeries,
            SellSignalValueDataSeries
        }

        public enum MATypeEnum
        {
            SMA,
            EMA
        }

        #endregion

        #region Members

        private MATypeEnum _maType = MATypeEnum.SMA;
        private int _period = 9;
        private int _signalOffset = 0;
        private SMA _sma = new();
        private EMA _ema = new();
        private readonly ValueDataSeries _maSeries = new("MA", "Moving Average")
        {
            VisualType = VisualMode.Line,
            Color = DefaultColors.Blue.Convert(),
            Width = 2
        };
        private readonly ValueDataSeries _buySignalsSeries = new("BuySignal", "Buy Signal")
        {
            VisualType = VisualMode.UpArrow,
            Color = DefaultColors.Green.Convert(),
            Width = 2,
            ShowTooltip = false
        };
        private readonly ValueDataSeries _sellSignalsSeries = new("SellSignal", "Sell Signal")
        {
            VisualType = VisualMode.DownArrow,
            Color = DefaultColors.Red.Convert(),
            Width = 2,
            ShowTooltip = false
        };
        private int _lastBar = 0;

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
                _maSeries.Name = $"{_period} {_maType}";
                RecalculateValues();
            }
        }

        [OFT.Attributes.Parameter]
        [Display(Name = "Period", GroupName = "Settings", Description = "The period of the Moving Average.", Order = 002)]
        [Range(1, 1000)]
        public int Period
        {
            get => _period;

            set
            {
                _period = value;
                _sma.Period = value;
                _ema.Period = value;
                _maSeries.Name = $"{_period} {_maType}";
                RecalculateValues();
            }
        }

        [Display(Name = "Offset", GroupName = "Signals", Description = "The vertical offset between signal and bar.", Order = 101)]
        [Range(0, 1000)]
        public int SignalOffset
        {
            get => _signalOffset;

            set
            {
                _signalOffset = value;
                RecalculateValues();
            }
        }

        [Display(Name = "Buy Alerts", GroupName = "Alerts", Description = "When enabled, an alert is triggered when price crosses and closes above the Moving Average, using the specified sound file.", Order = 201)]
        public FilterString BuyAlertFilter { get; set; }

        [Display(Name = "Sell Alerts", GroupName = "Alerts", Description = "When enabled, an alert is triggered when price crosses and closes below the Moving Average, using the specified sound file.", Order = 202)]
        public FilterString SellAlertFilter { get; set; }

        #endregion

        #region Constructor

        public SignalsMA()
        {
            // NOTE: The DataSeries must match the order found in SignalsMADataSeriesIndexEnum.
            DataSeries[0] = _maSeries;
            DataSeries.Add(_buySignalsSeries);
            DataSeries.Add(_sellSignalsSeries);

            MAType = MATypeEnum.SMA;
            Period = 9;
            SignalOffset = 1;

            BuyAlertFilter = new(true) { Value = "alert1" };
            SellAlertFilter = new(true) { Value = "alert1" };
        }

        #endregion

        #region Indicator methods

        protected override void OnRecalculate()
        {
            base.OnRecalculate();

            DataSeries.ForEach(ds => ds.Clear());

            _sma = new() { Period = _period };
            _ema = new() { Period = _period };
        }

        protected override void OnCalculate(int bar, decimal value)
        {
            if (bar == 0)
                return;

            if (CurrentBar < (Period + 1) || InstrumentInfo is null)
                return;

            // Alerts
            if ((_lastBar != bar) && (bar == CurrentBar - 1))
            {
                if (BuyAlertFilter.Enabled && _buySignalsSeries[bar - 1] != 0)
                {
                    AddAlert(BuyAlertFilter.Value, InstrumentInfo.Instrument, $"BUY SIGNAL: Price crossed and closed above the {Period} {MAType}", DefaultColors.Black.Convert(), _buySignalsSeries.ValuesColor.Convert());
                }
                if (SellAlertFilter.Enabled && _sellSignalsSeries[bar - 1] != 0)
                {
                    AddAlert(SellAlertFilter.Value, InstrumentInfo.Instrument, $"SELL SIGNAL: Price crossed and closed below the {Period} {MAType}", DefaultColors.Black.Convert(), _sellSignalsSeries.ValuesColor.Convert());
                }
            }

            // MA
            var maValue = (_maType == MATypeEnum.EMA) ? _ema.Calculate(bar, value) : _sma.Calculate(bar, value);
            _maSeries[bar] = maValue;

            // Signals
            var prevCandle = GetCandle(bar - 1);
            var currCandle = GetCandle(bar);

            bool buySignal = (prevCandle.Close <= _maSeries[bar - 1]) && currCandle.Close > maValue;
            _buySignalsSeries[bar] = buySignal ? (currCandle.Low - (InstrumentInfo.TickSize * SignalOffset)) : 0;

            bool sellSignal = (prevCandle.Close >= _maSeries[bar - 1]) && currCandle.Close < maValue;
            _sellSignalsSeries[bar] = sellSignal ? (currCandle.High + (InstrumentInfo.TickSize * SignalOffset)) : 0;

            /*
            if (buySignal || sellSignal)
                this.LogInfo($"BAR {bar}, PREV CLOSE {prevCandle.Close}, PREV MA {_maSeries[bar - 1]}, CLOSE {currCandle.Close}, MA {maValue}, BUY SIG {buySignal}, SELL SIG {sellSignal}");
            */

            _lastBar = bar;
        }

        #endregion
    }
}
