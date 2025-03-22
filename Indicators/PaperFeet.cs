using ATAS.Indicators;
using ATAS.Indicators.Drawing;
using OFT.Rendering.Context;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace gambcl.ATAS.Indicators
{
    [DisplayName("PaperFeet")]
    [Category("gambcl-ATAS-Indicators")]
    public class PaperFeet : LaguerreRSI
    {
        #region Enums

        public enum PaperFeetDataSeriesIndexEnum
        {
            LaguerreRSIValueDataSeries,
            Internal0,
            Internal1,
            Internal2,
            Internal3,
            Internal4,
            Internal5,
            Internal6,
            Internal7,
            SignalsValueDataSeries
        }

        #endregion

        #region Members

        private bool _isRsiInitialized = false;
        private int _lastEnterLongSignalAlertBar = 0;
        private int _lastEnterShortSignalAlertBar = 0;
        private readonly ValueDataSeries _signals = new("Signals")
        {
            VisualType = VisualMode.Hide,
            IsHidden = true
        };

        #endregion

        #region Properties

        [Display(Name = "Enter LONG", GroupName = "Entry Signals", Description = "When enabled, LONG entry signals will be highlighted in the specified color.", Order = 351)]
        public FilterColor EnterLongSignalColor {  get; set; }

        [Display(Name = "Enter SHORT", GroupName = "Entry Signals", Description = "When enabled, SHORT entry signals will be highlighted in the specified color.", Order = 352)]
        public FilterColor EnterShortSignalColor { get; set; }

        [Display(Name = "Enter LONG", GroupName = "Alerts", Description = "When enabled, an alert is triggered by a LONG entry signal, using the specified sound file.", Order = 391)]
        public FilterString EnterLongSignalAlertFilter { get; set; }

        [Display(Name = "Enter SHORT", GroupName = "Alerts", Description = "When enabled, an alert is triggered by a SHORT entry signal, using the specified sound file.", Order = 392)]
        public FilterString EnterShortSignalAlertFilter { get; set; }

        #endregion

        #region Constructor

        public PaperFeet()
        {
            // NOTE: The DataSeries must match the order found in PaperFeetDataSeriesIndexEnum.
            DataSeries.Add(_signals);

            EnterLongSignalColor = new(true) { Enabled = true, Value = DefaultColors.Green.GetWithTransparency(50).Convert() };
            EnterShortSignalColor = new(true) { Enabled = true, Value = DefaultColors.Red.GetWithTransparency(50).Convert() };

            EnterLongSignalAlertFilter = new(true) { Enabled = true, Value = "alert1" };
            EnterShortSignalAlertFilter = new(true) { Enabled = true, Value = "alert1" };

            EnterLongSignalColor.PropertyChanged += OnSignalPropertyChanged;
            EnterShortSignalColor.PropertyChanged += OnSignalPropertyChanged;

            _isRsiInitialized = false;
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

            if (bar == 0)
                return;

            if (CurrentBar < 2)
                return;

            // Wait for first actual RSI value to appear
            if (!_isRsiInitialized && this[bar - 1] != 0m)
                _isRsiInitialized = true;

            if (!_isRsiInitialized)
                return;

            if (this[bar - 1] <= OversoldLevel && this[bar] > OversoldLevel)
            {
                // Enter LONG signal
                _signals[bar] = 1m;
            }
            else if (this[bar - 1] >= OverboughtLevel && this[bar] < OverboughtLevel)
            {
                // Enter SHORT signal
                _signals[bar] = -1m;
            }
            else
            {
                // No signal
                _signals[bar] = 0m;
            }

            // Alerts
            if (bar == (CurrentBar - 1) && InstrumentInfo is not null)
            {
                if (EnterLongSignalColor.Enabled && EnterLongSignalAlertFilter.Enabled && (bar != _lastEnterLongSignalAlertBar) && (_signals[bar] > 0))
                {
                    AddAlert(EnterLongSignalAlertFilter.Value, InstrumentInfo.Instrument, $"Enter LONG: Laguerre RSI leaving oversold region {this[bar]:0.#####}", DefaultColors.Black.Convert(), EnterLongSignalColor.Value);
                    _lastEnterLongSignalAlertBar = bar;
                }

                if (EnterShortSignalColor.Enabled && EnterShortSignalAlertFilter.Enabled && (bar != _lastEnterShortSignalAlertBar) && (_signals[bar] < 0))
                {
                    AddAlert(EnterShortSignalAlertFilter.Value, InstrumentInfo.Instrument, $"Enter SHORT: Laguerre RSI leaving overbought region {this[bar]:0.#####}", DefaultColors.Black.Convert(), EnterShortSignalColor.Value);
                    _lastEnterShortSignalAlertBar = bar;
                }
            }
        }

        protected override void OnRender(RenderContext context, DrawingLayouts layout)
        {
            base.OnRender(context, layout);

            if (ChartInfo is null)
                return;

            if (Container is null)
                return;

            if (!EnterLongSignalColor.Enabled && !EnterShortSignalColor.Enabled)
                return;

            Color enterLongColor = EnterLongSignalColor.Value.Convert();
            Color enterShortColor = EnterShortSignalColor.Value.Convert();
            int topY = Container.Region.Top;
            int bottomY = Container.Region.Bottom;
            int height = bottomY - topY;

            for (int i = FirstVisibleBarNumber; i <= LastVisibleBarNumber; i++)
            {
                bool enterLongSignal = _signals[i] > 0;
                bool enterShortSignal = _signals[i] < 0;

                if ((enterLongSignal && EnterLongSignalColor.Enabled) || (enterShortSignal && EnterShortSignalColor.Enabled))
                {
                    int leftX = ChartInfo.GetXByBar(i, true) - 1;
                    int rightX = ChartInfo.GetXByBar(i + 1, true) - 1;
                    int width = (rightX - leftX) - 1;
                    Rectangle signalRect = new Rectangle(leftX, topY, width, height);

                    context.FillRectangle(enterLongSignal ? enterLongColor : enterShortColor, signalRect);
                }
            }
        }

        #endregion

        #region Private methods

        private void OnSignalPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            RecalculateValues();
        }

        #endregion
    }
}
