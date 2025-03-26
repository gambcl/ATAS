﻿using ATAS.Indicators;
using ATAS.Indicators.Drawing;
using OFT.Rendering.Context;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Utils.Common.Logging;
using static gambcl.ATAS.Indicators.HeikenAshi;

namespace gambcl.ATAS.Indicators
{
    [DisplayName("PaperArms")]
    [Category("gambcl-ATAS-Indicators")]
    public class PaperArms : MACloud, IPropertiesEditorOwner
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
            EnterLongValueDataSeries,
            EnterShortValueDataSeries,
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

        private bool _dummyValue = false;
        private bool _forceRecalculate = false;
        private gambcl.ATAS.Indicators.HeikenAshi _ha = new();
        private gambcl.ATAS.Indicators.PaperFeet _paperFeet = new();
        private readonly ValueDataSeries _enterLongSeries = new("EnterLong")
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
        private readonly ValueDataSeries _enterShortSeries = new("EnterShort")
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
        private int _entrySignalWidth = DefaultEntrySignalWidth;
        private int _entrySignalOffset = DefaultEntrySignalOffset;
        private int _exitSignalWidth = DefaultExitSignalWidth;
        private int _exitSignalOffset = DefaultExitSignalOffset;
        private int _lastEnterLongSignalAlertBar = 0;
        private int _lastEnterShortSignalAlertBar = 0;
        private int _lastReenterLongSignalAlertBar = 0;
        private int _lastReenterShortSignalAlertBar = 0;
        private int _lastExitLongOppFlatTopSignalAlertBar = 0;
        private int _lastExitShortOppFlatBottomSignalAlertBar = 0;
        private int _lastExitLongOppTrendDotSignalAlertBar = 0;
        private int _lastExitShortOppTrendDotSignalAlertBar = 0;

        private IPropertiesEditor? _propertiesEditor;

        #endregion

        #region Properties

        [OFT.Attributes.Parameter]
        [Display(Name = "Toggle to Recalculate", GroupName = "Settings", Order = 000)]
        public bool ToggleToRecalculate
        {
            get => _dummyValue;

            set
            {
                _dummyValue = value;
                RecalculateValues();
            }
        }

        [OFT.Attributes.Parameter]
        [Display(Name = "Use Fractal Energy", GroupName = "LRSI - Settings", Order = 101)]
        public bool UseFractalEnergy
        {
            get => _paperFeet.UseFractalEnergy;

            set
            {
                _paperFeet.UseFractalEnergy = value;
                _propertiesEditor?.SetIsExpandedCategory("LRSI - Laguerre RSI", !value);
                _propertiesEditor?.SetIsExpandedCategory("LRSI - Laguerre RSI with Fractal Energy", value);
                RecalculateValues();
            }
        }

        [OFT.Attributes.Parameter]
        [Display(Name = "Alpha", GroupName = "LRSI - Laguerre RSI", Order = 201)]
        [Range(0, 1)]
        public decimal Alpha
        {
            get => _paperFeet.Alpha;

            set
            {
                _paperFeet.Alpha = value;
                RecalculateValues();
            }
        }

        [OFT.Attributes.Parameter]
        [Display(Name = "NFE", GroupName = "LRSI - Laguerre RSI with Fractal Energy", Description = "Number of bars used in Fractal Energy calculations.", Order = 301)]
        [Range(1, Int32.MaxValue)]
        public int NFE
        {
            get => _paperFeet.NFE;

            set
            {
                _paperFeet.NFE = value;
                RecalculateValues();
            }
        }

        [OFT.Attributes.Parameter]
        [Display(Name = "GLength", GroupName = "LRSI - Laguerre RSI with Fractal Energy", Description = "Period length for Go/Gh/Gl/Gc filter.", Order = 302)]
        [Range(1, Int32.MaxValue)]
        public int GLength
        {
            get => _paperFeet.GLength;

            set
            {
                _paperFeet.GLength = value;
                RecalculateValues();
            }
        }

        [OFT.Attributes.Parameter]
        [Display(Name = "BetaDev", GroupName = "LRSI - Laguerre RSI with Fractal Energy", Description = "Controls reactivity in alpha/beta computations.", Order = 303)]
        [Range(1, Int32.MaxValue)]
        public int BetaDev
        {
            get => _paperFeet.BetaDev;

            set
            {
                _paperFeet.BetaDev = value;
                RecalculateValues();
            }
        }

        [OFT.Attributes.Parameter]
        [Display(Name = "Overbought Level", GroupName = "LRSI - Thresholds", Order = 401)]
        [Range(0, 100)]
        public decimal OverboughtLevel
        {
            get => _paperFeet.OverboughtLevel;

            set
            {
                _paperFeet.OverboughtLevel = value;
                RecalculateValues();
            }
        }

        [OFT.Attributes.Parameter]
        [Display(Name = "Oversold Level", GroupName = "LRSI - Thresholds", Order = 402)]
        [Range(0, 100)]
        public decimal OversoldLevel
        {
            get => _paperFeet.OversoldLevel;

            set
            {
                _paperFeet.OversoldLevel = value;
                RecalculateValues();
            }
        }

        [Display(Name = "Enter LONG", GroupName = "Entry Signals", Description = "When enabled, LONG entry signals will be highlighted in the specified color.", Order = 501)]
        public FilterColor EnterLongSignalColor { get; set; }

        [Display(Name = "Enter SHORT", GroupName = "Entry Signals", Description = "When enabled, SHORT entry signals will be highlighted in the specified color.", Order = 502)]
        public FilterColor EnterShortSignalColor { get; set; }

        [Display(Name = "Re-enter LONG", GroupName = "Entry Signals", Description = "When enabled, LONG re-entry signals will be highlighted in the specified color.", Order = 503)]
        public FilterColor ReenterLongSignalColor {  get; set; }

        [Display(Name = "Re-enter SHORT", GroupName = "Entry Signals", Description = "When enabled, SHORT re-entry signals will be highlighted in the specified color.", Order = 504)]
        public FilterColor ReenterShortSignalColor { get; set; }

        [Display(Name = "Signal Width", GroupName = "Entry Signals", Description = "Controls the size of the entry signals on the chart.", Order = 505)]
        [Range(1, 1000)]
        public int EntrySignalWidth
        {
            get => _entrySignalWidth;

            set
            {
                _entrySignalWidth = value;
                _enterLongSeries.Width = value;
                _enterShortSeries.Width = value;
                _reenterLongSeries.Width = value;
                _reenterShortSeries.Width = value;
                RecalculateValues();
            }
        }

        [Display(Name = "Signal Offset", GroupName = "Entry Signals", Description = "The vertical offset between entry signal and bar.", Order = 506)]
        [Range(0, 1000)]
        public int EntrySignalOffset
        {
            get => _entrySignalOffset;

            set
            {
                _entrySignalOffset = value;
                RecalculateValues();
            }
        }

        [Display(Name = "Exit LONG - Opposite Flat Top", GroupName = "Exit Signals", Description = "When enabled, LONG exit signals (due to opposite HA candle with flat top) will be highlighted in the specified color.", Order = 601)]
        public FilterColor ExitLongOppFlatTopSignalColor { get; set; }

        [Display(Name = "Exit LONG - Opposite Trend Dot", GroupName = "Exit Signals", Description = "When enabled, LONG exit signals (due to opposite trend dot) will be highlighted in the specified color.", Order = 602)]
        public FilterColor ExitLongOppTrendDotSignalColor { get; set; }

        [Display(Name = "Exit SHORT - Opposite Flat Bottom", GroupName = "Exit Signals", Description = "When enabled, SHORT exit signals (due to opposite HA candle with flat bottom) will be highlighted in the specified color.", Order = 603)]
        public FilterColor ExitShortOppFlatBottomSignalColor { get; set; }

        [Display(Name = "Exit SHORT - Opposite Trend Dot", GroupName = "Exit Signals", Description = "When enabled, SHORT exit signals (due to opposite trend dot) will be highlighted in the specified color.", Order = 604)]
        public FilterColor ExitShortOppTrendDotSignalColor { get; set; }

        [Display(Name = "Signal Width", GroupName = "Exit Signals", Description = "Controls the size of the exit signals on the chart.", Order = 605)]
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

        [Display(Name = "Signal Offset", GroupName = "Exit Signals", Description = "The vertical offset between exit signal and bar.", Order = 606)]
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

        [Display(Name = "Enter LONG", GroupName = "Alerts", Description = "When enabled, an alert is triggered by a LONG entry signal, using the specified sound file.", Order = 701)]
        public FilterString EnterLongSignalAlertFilter { get; set; }

        [Display(Name = "Enter SHORT", GroupName = "Alerts", Description = "When enabled, an alert is triggered by a SHORT entry signal, using the specified sound file.", Order = 702)]
        public FilterString EnterShortSignalAlertFilter { get; set; }

        [Display(Name = "Re-enter LONG", GroupName = "Alerts", Description = "When enabled, an alert is triggered by a LONG re-entry signal, using the specified sound file.", Order = 703)]
        public FilterString ReenterLongSignalAlertFilter { get; set; }

        [Display(Name = "Re-enter SHORT", GroupName = "Alerts", Description = "When enabled, an alert is triggered by a SHORT re-entry signal, using the specified sound file.", Order = 704)]
        public FilterString ReenterShortSignalAlertFilter { get; set; }

        [Display(Name = "Exit LONG - Opposite Flat Top", GroupName = "Alerts", Description = "When enabled, an alert is triggered by an exit LONG signal (due to opposite HA candle with flat top), using the specified sound file.", Order = 705)]
        public FilterString ExitLongOppFlatTopSignalAlertFilter { get; set; }

        [Display(Name = "Exit LONG - Opposite Trend Dot", GroupName = "Alerts", Description = "When enabled, an alert is triggered by an exit LONG signal (due to opposite trend dot), using the specified sound file.", Order = 706)]
        public FilterString ExitLongOppTrendDotSignalAlertFilter { get; set; }

        [Display(Name = "Exit SHORT - Opposite Flat Bottom", GroupName = "Alerts", Description = "When enabled, an alert is triggered by an exit SHORT signal (due to opposite HA candle with flat bottom), using the specified sound file.", Order = 707)]
        public FilterString ExitShortOppFlatBottomSignalAlertFilter { get; set; }

        [Display(Name = "Exit SHORT - Opposite Trend Dot", GroupName = "Alerts", Description = "When enabled, an alert is triggered by an exit SHORT signal (due to opposite trend dot), using the specified sound file.", Order = 708)]
        public FilterString ExitShortOppTrendDotSignalAlertFilter { get; set; }

        #endregion

        #region Constructor

        public PaperArms()
        {
            DenyToChangePanel = true;
            EnableCustomDrawing = true;
            SubscribeToDrawingEvents(DrawingLayouts.LatestBar);

            // NOTE: The DataSeries must match the order found in PaperArmsDataSeriesIndexEnum.
            DataSeries.Add(_enterLongSeries);
            DataSeries.Add(_enterShortSeries);
            DataSeries.Add(_reenterLongSeries);
            DataSeries.Add(_reenterShortSeries);
            DataSeries.Add(_exitSeries);

            // Initialise MACloud properties.
            MAType = MATypeEnum.EMA;
            FastPeriod = 9;
            SlowPeriod = 21;

            // Initialise PaperFeet properties.
            UseFractalEnergy = true;
            Alpha = 0.2m;
            NFE = 8;
            GLength = 13;
            BetaDev = 8;

            OverboughtLevel = 80m;
            OversoldLevel = 20m;

            EnterLongSignalColor = new(true) { Enabled = true, Value = DefaultColors.Green.Convert() };
            EnterShortSignalColor = new(true) { Enabled = true, Value = DefaultColors.Red.Convert() };
            ReenterLongSignalColor = new(true) { Enabled = true, Value = DefaultColors.Green.Convert() };
            ReenterShortSignalColor = new(true) { Enabled = true, Value = DefaultColors.Red.Convert() };
            EntrySignalWidth = DefaultEntrySignalWidth;
            EntrySignalOffset = DefaultEntrySignalOffset;

            ExitLongOppFlatTopSignalColor = new(true) { Enabled = true, Value = DefaultColors.Green.Convert() };
            ExitLongOppTrendDotSignalColor = new(true) { Enabled = true, Value = DefaultColors.Green.Convert() };
            ExitShortOppFlatBottomSignalColor = new(true) { Enabled = true, Value = DefaultColors.Red.Convert() };
            ExitShortOppTrendDotSignalColor = new(true) { Enabled = true, Value = DefaultColors.Red.Convert() };
            ExitSignalWidth = DefaultExitSignalWidth;
            ExitSignalOffset = DefaultExitSignalOffset;

            EnterLongSignalAlertFilter = new(true) { Enabled = true, Value = "alert1" };
            EnterShortSignalAlertFilter = new(true) { Enabled = true, Value = "alert1" };
            ReenterLongSignalAlertFilter = new(true) { Enabled = true, Value = "alert1" };
            ReenterShortSignalAlertFilter = new(true) { Enabled = true, Value = "alert1" };
            ExitLongOppFlatTopSignalAlertFilter = new(true) { Enabled = true, Value = "alert1" };
            ExitLongOppTrendDotSignalAlertFilter = new(true) { Enabled = true, Value = "alert1" };
            ExitShortOppFlatBottomSignalAlertFilter = new(true) { Enabled = true, Value = "alert1" };
            ExitShortOppTrendDotSignalAlertFilter = new(true) { Enabled = true, Value = "alert1" };

            EnterLongSignalColor.PropertyChanged += EnterLongSignalFilterPropertyChanged;
            EnterShortSignalColor.PropertyChanged += EnterShortSignalFilterPropertyChanged;
            ReenterLongSignalColor.PropertyChanged += ReenterLongSignalFilterPropertyChanged;
            ReenterShortSignalColor.PropertyChanged += ReenterShortSignalFilterPropertyChanged;

            ExitLongOppFlatTopSignalColor.PropertyChanged += ExitSignalFilterPropertyChanged;
            ExitLongOppTrendDotSignalColor.PropertyChanged += ExitSignalFilterPropertyChanged;
            ExitShortOppFlatBottomSignalColor.PropertyChanged += ExitSignalFilterPropertyChanged;
            ExitShortOppTrendDotSignalColor.PropertyChanged += ExitSignalFilterPropertyChanged;

            Add(_ha);
            Add(_paperFeet);
        }

        #endregion

        #region Indicator methods

        protected override void OnInitialize()
        {
            base.OnInitialize();
            // Work around a bug in ATAS where the child indicators do not seem to get recalculated.
            _forceRecalculate = true;
        }

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

            CandleDataSeries haCandleSeries = (CandleDataSeries)(_ha.DataSeries[(int)HeikenAshiDataSeriesIndexEnum.HeikenAshiCandleDataSeries]);

            // Entry signals.
            decimal entrySignal = ((ValueDataSeries)(_paperFeet.DataSeries[(int)PaperFeet.PaperFeetDataSeriesIndexEnum.SignalsValueDataSeries]))[bar];
            if (entrySignal > 0 && EnterLongSignalColor.Enabled)
            {
                _enterLongSeries[bar] = haCandleSeries[bar].Low - (EntrySignalOffset * InstrumentInfo.TickSize);
            }
            else
            {
                _enterLongSeries[bar] = 0m;
            }

            if (entrySignal < 0 && EnterShortSignalColor.Enabled)
            {
                _enterShortSeries[bar] = haCandleSeries[bar].High + (EntrySignalOffset * InstrumentInfo.TickSize);
            }
            else
            {
                _enterShortSeries[bar] = 0m;
            }

            // Re-entry signals.
            decimal lrsi = ((ValueDataSeries)(_paperFeet.DataSeries[(int)PaperFeet.PaperFeetDataSeriesIndexEnum.LaguerreRSIValueDataSeries]))[bar];
            int trend0 = haCandleSeries[bar].Close - haCandleSeries[bar].Open >= 0 ? 1 : -1;
            int trend1 = haCandleSeries[bar - 1].Close - haCandleSeries[bar - 1].Open >= 0 ? 1 : -1;
            int trend2 = haCandleSeries[bar - 2].Close - haCandleSeries[bar - 2].Open >= 0 ? 1 : -1;

            // Re-enter long - Return to same color trend dot.
            bool reenterLongSameTrendDot = (lrsi > 50m) && (trend0 == 1) && (trend1 == 1) && (trend1 != trend2);
            var candle = GetCandle(bar);
            //this.LogInfo($"BAR {bar}, TIME {candle.Time}, LRSI {lrsi:0.00}");
            if (reenterLongSameTrendDot && ReenterLongSignalColor.Enabled)
            {
                _reenterLongSeries[bar] = haCandleSeries[bar].Low - (EntrySignalOffset * InstrumentInfo.TickSize);
            }
            else
            {
                _reenterLongSeries[bar] = 0m;
            }

            // Re-enter short - Return to same color trend dot.
            bool reenterShortSameTrendDot = (lrsi < 50m) && (trend0 == -1) && (trend1 == -1) && (trend1 != trend2);
            if (reenterShortSameTrendDot && ReenterShortSignalColor.Enabled)
            {
                _reenterShortSeries[bar] = haCandleSeries[bar].High + (EntrySignalOffset * InstrumentInfo.TickSize);
            }
            else
            {
                _reenterShortSeries[bar] = 0m;
            }

            // Exit signals.
            decimal emaFast = ((ValueDataSeries)(DataSeries[(int)PaperArmsDataSeriesIndexEnum.FastMAValueDataSeries]))[bar];
            decimal emaSlow = ((ValueDataSeries)(DataSeries[(int)PaperArmsDataSeriesIndexEnum.SlowMAValueDataSeries]))[bar];
            // Exit long - Opposite flat top.
            bool exitLongOppositeFlatTop = (emaFast > emaSlow) && (haCandleSeries[bar].Close < haCandleSeries[bar].Open) && (haCandleSeries[bar].High == haCandleSeries[bar].Open);
            // Exit long - Opposite color trend dot.
            bool exitLongOppositeTrendDot = (emaFast > emaSlow) && (trend0 == -1) && (trend1 == -1) && (trend1 != trend2);
            // Exit short - Opposite flat bottom.
            bool exitShortOppositeFlatBottom = (emaFast < emaSlow) && (haCandleSeries[bar].Close > haCandleSeries[bar].Open) && (haCandleSeries[bar].Low == haCandleSeries[bar].Open);
            // Exit short - Opposite color trend dot.
            bool exitShortOppositeTrendDot = (emaFast < emaSlow) && (trend0 == 1) && (trend1 == 1) && (trend1 != trend2);

            if (exitLongOppositeFlatTop && ExitLongOppFlatTopSignalColor.Enabled)
            {
                _exitSeries[bar] = haCandleSeries[bar].High + (ExitSignalOffset * InstrumentInfo.TickSize);
                _exitSeries.Colors[bar] = ExitLongOppFlatTopSignalColor.Value.Convert();
            }
            else if (exitLongOppositeTrendDot && ExitLongOppTrendDotSignalColor.Enabled)
            {
                _exitSeries[bar] = haCandleSeries[bar].High + (ExitSignalOffset * InstrumentInfo.TickSize);
                _exitSeries.Colors[bar] = ExitLongOppTrendDotSignalColor.Value.Convert();
            }
            else if (exitShortOppositeFlatBottom && ExitShortOppFlatBottomSignalColor.Enabled)
            {
                _exitSeries[bar] = haCandleSeries[bar].Low - (ExitSignalOffset * InstrumentInfo.TickSize);
                _exitSeries.Colors[bar] = ExitShortOppFlatBottomSignalColor.Value.Convert();
            }
            else if (exitShortOppositeTrendDot && ExitShortOppTrendDotSignalColor.Enabled)
            {
                _exitSeries[bar] = haCandleSeries[bar].Low - (ExitSignalOffset * InstrumentInfo.TickSize);
                _exitSeries.Colors[bar] = ExitShortOppTrendDotSignalColor.Value.Convert();
            }
            else
            {
                _exitSeries[bar] = 0m;
            }

            // Alerts
            if (bar == (CurrentBar - 1) && InstrumentInfo is not null)
            {
                if (EnterLongSignalColor.Enabled && EnterLongSignalAlertFilter.Enabled && (entrySignal > 0) && (bar != _lastEnterLongSignalAlertBar))
                {
                    AddAlert(EnterLongSignalAlertFilter.Value, InstrumentInfo.Instrument, $"Enter LONG: Laguerre RSI leaving oversold region {_paperFeet[bar]:0.#}", DefaultColors.Black.Convert(), EnterLongSignalColor.Value);
                    _lastEnterLongSignalAlertBar = bar;
                }

                if (EnterShortSignalColor.Enabled && EnterShortSignalAlertFilter.Enabled && (entrySignal < 0) && (bar != _lastEnterShortSignalAlertBar))
                {
                    AddAlert(EnterShortSignalAlertFilter.Value, InstrumentInfo.Instrument, $"Enter SHORT: Laguerre RSI leaving overbought region {_paperFeet[bar]:0.#}", DefaultColors.Black.Convert(), EnterShortSignalColor.Value);
                    _lastEnterShortSignalAlertBar = bar;
                }

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

        protected override void OnRender(RenderContext context, DrawingLayouts layout)
        {
            base.OnRender(context, layout);

            // Work around a bug in ATAS where the child indicators do not seem to get recalculated.
            if (_forceRecalculate)
            {
                DoActionInGuiThread(() =>
                {
                    this.LogInfo("Forcing child indicators to recalculate");
                    ToggleToRecalculate = !ToggleToRecalculate;
                });
                _forceRecalculate = false;
            }
        }

        #endregion

        #region IPropertiesEditorOwner

        [Browsable(false)]
        IPropertiesEditor? IPropertiesEditorOwner.PropertiesEditor
        {
            get => _propertiesEditor;

            set
            {
                if (_propertiesEditor == value)
                    return;

                _propertiesEditor = value;
                PropertiesEditorOnChanged(value);
            }
        }

        private void PropertiesEditorOnChanged(IPropertiesEditor? newValue)
        {
            newValue?.BeginInit();

            newValue?.SetIsExpandedCategory("Laguerre RSI", !UseFractalEnergy);
            newValue?.SetIsExpandedCategory("Laguerre RSI with Fractal Energy", UseFractalEnergy);

            newValue?.EndInit();
        }

        #endregion

        #region Private methods

        private void EnterLongSignalFilterPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            _enterLongSeries.Color = EnterLongSignalColor.Value;
            RecalculateValues();
        }

        private void EnterShortSignalFilterPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            _enterShortSeries.Color = EnterShortSignalColor.Value;
            RecalculateValues();
        }

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
