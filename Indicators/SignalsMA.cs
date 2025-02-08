using ATAS.Indicators;
using ATAS.Indicators.Drawing;
using ATAS.Indicators.Technical;
using OFT.Rendering.Context;
using OFT.Rendering.Tools;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using Utils.Common.Logging;
using CrossColor = System.Windows.Media.Color;

namespace gambcl.ATAS.Indicators
{
    [DisplayName("SignalsMA")]
    [Category("gambcl-ATAS-Indicators")]
    public class SignalsMA : Indicator
    {
        public enum MATypeEnum
        {
            SMA,
            EMA
        }

        #region Members

        private MATypeEnum _maType = MATypeEnum.SMA;
        private int _period = 9;
        private int _signalOffset = 0;
        private readonly SMA _sma = new();
        private readonly EMA _ema = new();
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

        [Display(Name = "MA Type", GroupName = "Parameters", Description = "The type of MA")]
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
        [Display(Name = "Period", GroupName = "Parameters", Description = "The period of the MA")]
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

        [OFT.Attributes.Parameter]
        [Display(Name = "Offset", GroupName = "Signals", Description = "The offset between signal and bar")]
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

        [Display(Name = "Use Alerts", GroupName = "Alerts", Description = "Show alerts when price crosses and closes beyond the MA")]
        public bool UseAlerts { get; set; }

        [Display(Name = "Alert File", GroupName = "Alerts", Description = "Alert sound")]
        public string AlertFile { get; set; } = "alert1";

        [Display(Name = "Font Color", GroupName = "Alerts", Description = "Font color for alerts")]
        public CrossColor FontColor { get; set; } = System.Drawing.Color.White.Convert();

        [Display(Name = "Background Color", GroupName = "Alerts", Description = "Background color for alerts")]
        public CrossColor BackgroundColor { get; set; } = System.Drawing.Color.DimGray.Convert();

        #endregion

        #region Constructor

        public SignalsMA()
        {
            DataSeries[0] = _maSeries;
            DataSeries.Add(_buySignalsSeries);
            DataSeries.Add(_sellSignalsSeries);

            MAType = MATypeEnum.SMA;
            Period = 9;
            SignalOffset = 1;
        }

        #endregion

        #region Indicator methods

        protected override void OnCalculate(int bar, decimal value)
        {
            if (bar == 0)
            {
                _maSeries.Clear();
                _buySignalsSeries.Clear();
                _sellSignalsSeries.Clear();
            }
            else
            {
                if (CurrentBar < (Period + 1) || InstrumentInfo is null)
                    return;

                // Alerts
                if (UseAlerts && (_lastBar != bar) && (bar == CurrentBar - 1))
                {
                    if (_buySignalsSeries[bar - 1] != 0)
                    {
                        AddAlert(AlertFile, InstrumentInfo.Instrument, $"BUY SIGNAL: Price crossed and closed above the {Period} {MAType}", BackgroundColor, FontColor);
                    }
                    if (_sellSignalsSeries[bar - 1] != 0)
                    {
                        AddAlert(AlertFile, InstrumentInfo.Instrument, $"SELL SIGNAL: Price crossed and closed below the {Period} {MAType}", BackgroundColor, FontColor);
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
        }

        #endregion
    }
}
