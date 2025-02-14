using ATAS.Indicators;
using ATAS.Indicators.Drawing;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Utils.Common.Logging;
using static gambcl.ATAS.Indicators.HeikenAshi;

namespace gambcl.ATAS.Indicators
{
    [DisplayName("PaperArms")]
    [Category("gambcl-ATAS-Indicators")]
    public class PaperArms : MACloud
    {
        #region Enums

        public enum PaperArmsDataSeriesIndexEnum
        {
            // Inherited from MACloud.
            BullishCloudRangeDataSeries,
            BearishCloudRangeDataSeries,
            FastMAValueDataSeries,
            SlowMAValueDataSeries,
            // Added by PaperArms.
            ReenterLongValueDataSeries,
            ReenterShortValueDataSeries,
            ExitValueDataSeries
        }

        #endregion

        #region Constants

        const int DefaultEntrySignalWidth = 1;
        const int DefaultEntrySignalOffset = 4;

        const int DefaultExitSignalWidth = 5;
        const int DefaultExitSignalOffset = 7;

        #endregion

        #region Members

        private gambcl.ATAS.Indicators.HeikenAshi _ha = new();
        private readonly ValueDataSeries _reenterLongSeries = new("ReEnterLong")
        {
            VisualType = VisualMode.UpArrow,
            Width = DefaultEntrySignalWidth,
            Color = DefaultColors.Green.Convert(),
            ShowCurrentValue = false,
            ShowNameOnMouseOver = false,
            ShowTooltip = false,
            DrawAbovePrice = true,
            IsHidden = true
        };
        private readonly ValueDataSeries _reenterShortSeries = new("ReEnterShort")
        {
            VisualType = VisualMode.DownArrow,
            Width = DefaultEntrySignalWidth,
            Color = DefaultColors.Red.Convert(),
            ShowCurrentValue = false,
            ShowNameOnMouseOver = false,
            ShowTooltip = false,
            DrawAbovePrice = true,
            IsHidden = true
        };
        private readonly ValueDataSeries _exitSeries = new("Exit")
        {
            VisualType = VisualMode.Block,
            Width = DefaultExitSignalWidth,
            Color = DefaultColors.White.Convert(),
            ShowCurrentValue = false,
            ShowNameOnMouseOver = false,
            ShowTooltip = false,
            DrawAbovePrice = true,
            IsHidden = true
        };
        private int _reentrySignalWidth = DefaultEntrySignalWidth;
        private int _reentrySignalOffset = DefaultEntrySignalOffset;
        private int _exitSignalWidth = DefaultExitSignalWidth;
        private int _exitSignalOffset = DefaultExitSignalOffset;
        private int _lastReenterLongSignalAlertBar = 0;
        private int _lastReenterShortSignalAlertBar = 0;
        private int _lastExitLongOppFlatTopSignalAlertBar = 0;
        private int _lastExitShortOppFlatBottomSignalAlertBar = 0;
        private int _lastExitLongOppTrendDotSignalAlertBar = 0;
        private int _lastExitShortOppTrendDotSignalAlertBar = 0;

        #endregion

        #region Properties

        [Display(Name = "Re-enter LONG", GroupName = "Re-entry Signals", Description = "When enabled, LONG re-entry signals will be highlighted in the specified color.", Order = 101)]
        public FilterColor ReenterLongSignalColor {  get; set; }

        [Display(Name = "Re-enter SHORT", GroupName = "Re-entry Signals", Description = "When enabled, SHORT re-entry signals will be highlighted in the specified color.", Order = 102)]
        public FilterColor ReenterShortSignalColor { get; set; }

        [Display(Name = "Signal Width", GroupName = "Re-entry Signals", Description = "Controls the size of the re-entry signals on the chart.", Order = 103)]
        [Range(1, 1000)]
        public int ReentrySignalWidth
        {
            get => _reentrySignalWidth;

            set
            {
                _reentrySignalWidth = value;
                _reenterLongSeries.Width = value;
                _reenterShortSeries.Width = value;
                RecalculateValues();
            }
        }

        [Display(Name = "Signal Offset", GroupName = "Re-entry Signals", Description = "The vertical offset between re-entry signal and bar.", Order = 104)]
        [Range(0, 1000)]
        public int ReentrySignalOffset
        {
            get => _reentrySignalOffset;

            set
            {
                _reentrySignalOffset = value;
                RecalculateValues();
            }
        }

        [Display(Name = "Exit LONG - Opposite Flat Top", GroupName = "Exit Signals", Description = "When enabled, LONG exit signals (due to opposite HA candle with flat top) will be highlighted in the specified color.", Order = 201)]
        public FilterColor ExitLongOppFlatTopSignalColor { get; set; }

        [Display(Name = "Exit LONG - Opposite Trend Dot", GroupName = "Exit Signals", Description = "When enabled, LONG exit signals (due to opposite trend dot) will be highlighted in the specified color.", Order = 202)]
        public FilterColor ExitLongOppTrendDotSignalColor { get; set; }

        [Display(Name = "Exit SHORT - Opposite Flat Bottom", GroupName = "Exit Signals", Description = "When enabled, SHORT exit signals (due to opposite HA candle with flat bottom) will be highlighted in the specified color.", Order = 203)]
        public FilterColor ExitShortOppFlatBottomSignalColor { get; set; }

        [Display(Name = "Exit SHORT - Opposite Trend Dot", GroupName = "Exit Signals", Description = "When enabled, SHORT exit signals (due to opposite trend dot) will be highlighted in the specified color.", Order = 204)]
        public FilterColor ExitShortOppTrendDotSignalColor { get; set; }

        [Display(Name = "Signal Width", GroupName = "Exit Signals", Description = "Controls the size of the exit signals on the chart.", Order = 205)]
        [Range(1, 1000)]
        public int ExitSignalWidth
        {
            get => _exitSignalWidth;

            set
            {
                _exitSignalWidth = value;
                _exitSeries.Width = value;
                RecalculateValues();
            }
        }

        [Display(Name = "Signal Offset", GroupName = "Exit Signals", Description = "The vertical offset between exit signal and bar.", Order = 206)]
        [Range(0, 1000)]
        public int ExitSignalOffset
        {
            get => _exitSignalOffset;

            set
            {
                _exitSignalOffset = value;
                RecalculateValues();
            }
        }

        [Display(Name = "Re-enter LONG", GroupName = "Alerts", Description = "When enabled, an alert is triggered by a LONG re-entry signal, using the specified sound file.", Order = 301)]
        public FilterString ReenterLongSignalAlertFilter { get; set; }

        [Display(Name = "Re-enter SHORT", GroupName = "Alerts", Description = "When enabled, an alert is triggered by a SHORT re-entry signal, using the specified sound file.", Order = 302)]
        public FilterString ReenterShortSignalAlertFilter { get; set; }

        [Display(Name = "Exit LONG - Opposite Flat Top", GroupName = "Alerts", Description = "When enabled, an alert is triggered by an exit LONG signal (due to opposite HA candle with flat top), using the specified sound file.", Order = 303)]
        public FilterString ExitLongOppFlatTopSignalAlertFilter { get; set; }

        [Display(Name = "Exit LONG - Opposite Trend Dot", GroupName = "Alerts", Description = "When enabled, an alert is triggered by an exit LONG signal (due to opposite trend dot), using the specified sound file.", Order = 304)]
        public FilterString ExitLongOppTrendDotSignalAlertFilter { get; set; }

        [Display(Name = "Exit SHORT - Opposite Flat Bottom", GroupName = "Alerts", Description = "When enabled, an alert is triggered by an exit SHORT signal (due to opposite HA candle with flat bottom), using the specified sound file.", Order = 305)]
        public FilterString ExitShortOppFlatBottomSignalAlertFilter { get; set; }

        [Display(Name = "Exit SHORT - Opposite Trend Dot", GroupName = "Alerts", Description = "When enabled, an alert is triggered by an exit SHORT signal (due to opposite trend dot), using the specified sound file.", Order = 306)]
        public FilterString ExitShortOppTrendDotSignalAlertFilter { get; set; }

        #endregion

        #region Constructor

        public PaperArms()
        {
            DenyToChangePanel = true;

            DataSeries.Add(_reenterLongSeries);
            DataSeries.Add(_reenterShortSeries);
            DataSeries.Add(_exitSeries);

            ReenterLongSignalColor = new(true) { Enabled = false, Value = DefaultColors.Green.Convert() };
            ReenterShortSignalColor = new(true) { Enabled = false, Value = DefaultColors.Red.Convert() };
            ReentrySignalWidth = DefaultEntrySignalWidth;
            ReentrySignalOffset = DefaultEntrySignalOffset;

            ExitLongOppFlatTopSignalColor = new(true) { Enabled = false, Value = DefaultColors.Green.Convert() };
            ExitLongOppTrendDotSignalColor = new(true) { Enabled = false, Value = DefaultColors.Green.Convert() };
            ExitShortOppFlatBottomSignalColor = new(true) { Enabled = false, Value = DefaultColors.Red.Convert() };
            ExitShortOppTrendDotSignalColor = new(true) { Enabled = false, Value = DefaultColors.Red.Convert() };
            ExitSignalWidth = DefaultExitSignalWidth;
            ExitSignalOffset = DefaultExitSignalOffset;

            ReenterLongSignalAlertFilter = new(true) { Enabled = true, Value = "alert1" };
            ReenterShortSignalAlertFilter = new(true) { Enabled = true, Value = "alert1" };
            ExitLongOppFlatTopSignalAlertFilter = new(true) { Enabled = true, Value = "alert1" };
            ExitLongOppTrendDotSignalAlertFilter = new(true) { Enabled = true, Value = "alert1" };
            ExitShortOppFlatBottomSignalAlertFilter = new(true) { Enabled = true, Value = "alert1" };
            ExitShortOppTrendDotSignalAlertFilter = new(true) { Enabled = true, Value = "alert1" };

            ReenterLongSignalColor.PropertyChanged += ReenterLongSignalFilterPropertyChanged;
            ReenterShortSignalColor.PropertyChanged += ReenterShortSignalFilterPropertyChanged;

            ExitLongOppFlatTopSignalColor.PropertyChanged += ExitSignalFilterPropertyChanged;
            ExitLongOppTrendDotSignalColor.PropertyChanged += ExitSignalFilterPropertyChanged;
            ExitShortOppFlatBottomSignalColor.PropertyChanged += ExitSignalFilterPropertyChanged;
            ExitShortOppTrendDotSignalColor.PropertyChanged += ExitSignalFilterPropertyChanged;

            Add(_ha);
        }

        #endregion

        #region Indicator methods

        protected override void OnRecalculate()
        {
            base.OnRecalculate();

            DataSeries.ForEach(ds => ds.Clear());
        }

        protected override void OnCalculate(int bar, decimal value)
        {
            base.OnCalculate(bar, value);

            if (CurrentBar < 3)
                return;

            if (bar < 2)
                return;

            if (InstrumentInfo is null)
                return;

            decimal emaFast = ((ValueDataSeries)(DataSeries[(int)PaperArmsDataSeriesIndexEnum.FastMAValueDataSeries]))[bar];
            decimal emaSlow = ((ValueDataSeries)(DataSeries[(int)PaperArmsDataSeriesIndexEnum.SlowMAValueDataSeries]))[bar];

            CandleDataSeries haCandleSeries = (CandleDataSeries)(_ha.DataSeries[(int)HeikenAshiDataSeriesIndexEnum.HeikenAshiCandleDataSeries]);
            int trend0 = haCandleSeries[bar].Close - haCandleSeries[bar].Open >= 0 ? 1 : -1;
            int trend1 = haCandleSeries[bar - 1].Close - haCandleSeries[bar - 1].Open >= 0 ? 1 : -1;
            int trend2 = haCandleSeries[bar - 2].Close - haCandleSeries[bar - 2].Open >= 0 ? 1 : -1;

            // Re-enter long - Return to same color trend dot.
            bool reenterLongSameTrendDot = (emaFast > emaSlow) && (trend0 == 1) && (trend1 == 1) && (trend1 != trend2);
            var candle = GetCandle(bar);
            if (reenterLongSameTrendDot && ReenterLongSignalColor.Enabled)
            {
                _reenterLongSeries[bar] = haCandleSeries[bar].Low - (ReentrySignalOffset * InstrumentInfo.TickSize);
                //this.LogInfo($"BAR {bar}, TIME {candle.Time}, EMAFAST {emaFast}, EMASLOW {emaSlow}, trend2 {trend2}, trend1 {trend1}, trend0 {trend0}, series {_reenterLongSeries[bar]}");
            }
            // Re-enter short - Return to same color trend dot.
            bool reenterShortSameTrendDot = (emaFast < emaSlow) && (trend0 == -1) && (trend1 == -1) && (trend1 != trend2);
            if (reenterShortSameTrendDot && ReenterShortSignalColor.Enabled)
            {
                _reenterShortSeries[bar] = haCandleSeries[bar].High + (ReentrySignalOffset * InstrumentInfo.TickSize);
                //this.LogInfo($"BAR {bar}, TIME {candle.Time}, EMAFAST {emaFast}, EMASLOW {emaSlow}, trend2 {trend2}, trend1 {trend1}, trend0 {trend0}, series {_reenterShortSeries[bar]}");
            }

            // Exit long - Opposite flat top.
            bool exitLongOppositeFlatTop = (emaFast > emaSlow) && (haCandleSeries[bar].Close < haCandleSeries[bar].Open) && (haCandleSeries[bar].High == haCandleSeries[bar].Open);
            if (exitLongOppositeFlatTop && ExitLongOppFlatTopSignalColor.Enabled)
            {
                _exitSeries[bar] = haCandleSeries[bar].High + (ExitSignalOffset * InstrumentInfo.TickSize);
                _exitSeries.Colors[bar] = ExitLongOppFlatTopSignalColor.Value.Convert();
            }
            // Exit long - Opposite color trend dot.
            bool exitLongOppositeTrendDot = (emaFast > emaSlow) && (trend0 == -1) && (trend1 == -1) && (trend1 != trend2);
            if (exitLongOppositeTrendDot && ExitLongOppTrendDotSignalColor.Enabled)
            {
                _exitSeries[bar] = haCandleSeries[bar].High + (ExitSignalOffset * InstrumentInfo.TickSize);
                _exitSeries.Colors[bar] = ExitLongOppTrendDotSignalColor.Value.Convert();
            }
            // Exit short - Opposite flat bottom.
            bool exitShortOppositeFlatBottom = (emaFast < emaSlow) && (haCandleSeries[bar].Close > haCandleSeries[bar].Open) && (haCandleSeries[bar].Low == haCandleSeries[bar].Open);
            if (exitShortOppositeFlatBottom && ExitShortOppFlatBottomSignalColor.Enabled)
            {
                _exitSeries[bar] = haCandleSeries[bar].Low - (ExitSignalOffset * InstrumentInfo.TickSize);
                _exitSeries.Colors[bar] = ExitShortOppFlatBottomSignalColor.Value.Convert();
            }
            // Exit short - Opposite color trend dot.
            bool exitShortOppositeTrendDot = (emaFast < emaSlow) && (trend0 == 1) && (trend1 == 1) && (trend1 != trend2);
            if (exitShortOppositeTrendDot && ExitShortOppTrendDotSignalColor.Enabled)
            {
                _exitSeries[bar] = haCandleSeries[bar].Low - (ExitSignalOffset * InstrumentInfo.TickSize);
                _exitSeries.Colors[bar] = ExitShortOppTrendDotSignalColor.Value.Convert();
            }

            // Alerts
            if (bar == (CurrentBar - 1) && InstrumentInfo is not null)
            {
                if (ReenterLongSignalColor.Enabled && ReenterLongSignalAlertFilter.Enabled && reenterLongSameTrendDot && (bar != _lastReenterLongSignalAlertBar))
                {
                    AddAlert(ReenterLongSignalAlertFilter.Value, InstrumentInfo.Instrument, $"Re-enter LONG: Trend returning to bullish", DefaultColors.Black.Convert(), ReenterLongSignalColor.Value);
                    _lastReenterLongSignalAlertBar = bar;
                }

                if (ReenterShortSignalColor.Enabled && ReenterShortSignalAlertFilter.Enabled && reenterShortSameTrendDot && (bar != _lastReenterShortSignalAlertBar))
                {
                    AddAlert(ReenterShortSignalAlertFilter.Value, InstrumentInfo.Instrument, $"Re-enter SHORT: Trend returning to bearish", DefaultColors.Black.Convert(), ReenterShortSignalColor.Value);
                    _lastReenterShortSignalAlertBar = bar;
                }

                if (ExitLongOppFlatTopSignalColor.Enabled && ExitLongOppFlatTopSignalAlertFilter.Enabled && exitLongOppositeFlatTop && (bar != _lastExitLongOppFlatTopSignalAlertBar))
                {
                    AddAlert(ExitLongOppFlatTopSignalAlertFilter.Value, InstrumentInfo.Instrument, $"Exit LONG: Bearish HA candle with flat top", DefaultColors.Black.Convert(), ExitLongOppFlatTopSignalColor.Value);
                    _lastExitLongOppFlatTopSignalAlertBar = bar;
                }

                if (ExitShortOppFlatBottomSignalColor.Enabled && ExitShortOppFlatBottomSignalAlertFilter.Enabled && exitShortOppositeFlatBottom && (bar != _lastExitShortOppFlatBottomSignalAlertBar))
                {
                    AddAlert(ExitShortOppFlatBottomSignalAlertFilter.Value, InstrumentInfo.Instrument, $"Exit SHORT: Bullish HA candle with flat bottom", DefaultColors.Black.Convert(), ExitShortOppFlatBottomSignalColor.Value);
                    _lastExitShortOppFlatBottomSignalAlertBar = bar;
                }

                if (ExitLongOppTrendDotSignalColor.Enabled && ExitLongOppTrendDotSignalAlertFilter.Enabled && exitLongOppositeTrendDot && (bar != _lastExitLongOppTrendDotSignalAlertBar))
                {
                    AddAlert(ExitLongOppTrendDotSignalAlertFilter.Value, InstrumentInfo.Instrument, $"Exit LONG: Opposite trend dot", DefaultColors.Black.Convert(), ExitLongOppTrendDotSignalColor.Value);
                    _lastExitLongOppTrendDotSignalAlertBar = bar;
                }

                if (ExitShortOppTrendDotSignalColor.Enabled && ExitShortOppTrendDotSignalAlertFilter.Enabled && exitShortOppositeTrendDot && (bar != _lastExitShortOppTrendDotSignalAlertBar))
                {
                    AddAlert(ExitShortOppTrendDotSignalAlertFilter.Value, InstrumentInfo.Instrument, $"Exit SHORT: Opposite trend dot", DefaultColors.Black.Convert(), ExitShortOppTrendDotSignalColor.Value);
                    _lastExitShortOppTrendDotSignalAlertBar = bar;
                }
            }
        }

        #endregion

        #region Private methods

        private void ReenterLongSignalFilterPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            _reenterLongSeries.Color = ReenterLongSignalColor.Value;
            RecalculateValues();
        }

        private void ReenterShortSignalFilterPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            _reenterShortSeries.Color = ReenterShortSignalColor.Value;
            RecalculateValues();
        }

        private void ExitSignalFilterPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            // Exit signal uses BarColors, just need to recalculate.
            RecalculateValues();
        }

        #endregion
    }
}
