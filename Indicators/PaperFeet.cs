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
        private int _lastBuySignalAlertBar = 0;
        private int _lastSellSignalAlertBar = 0;
        private readonly ValueDataSeries _signals = new("Signals")
        {
            VisualType = VisualMode.Hide,
            IsHidden = true
        };

        #endregion

        #region Properties

        [Display(Name = "Buy Signal", GroupName = "Signals", Description = "When enabled, buy signals will be highlighted in the specified color.", Order = 351)]
        public FilterColor BuySignalColor {  get; set; }

        [Display(Name = "Sell Signal", GroupName = "Signals", Description = "When enabled, sell signals will be highlighted in the specified color.", Order = 352)]
        public FilterColor SellSignalColor { get; set; }

        [Display(Name = "Buy Signal", GroupName = "Alerts", Description = "When enabled, an alert is triggered by a buy signal, using the specified sound file.", Order = 391)]
        public FilterString BuySignalAlertFilter { get; set; }

        [Display(Name = "Sell Signal", GroupName = "Alerts", Description = "When enabled, an alert is triggered by a sell signal, using the specified sound file.", Order = 392)]
        public FilterString SellSignalAlertFilter { get; set; }

        #endregion

        #region Constructor

        public PaperFeet()
        {
            // NOTE: The DataSeries must match the order found in PaperFeetDataSeriesIndexEnum.
            DataSeries.Add(_signals);

            BuySignalColor = new(true) { Enabled = true, Value = DefaultColors.Green.GetWithTransparency(50).Convert() };
            SellSignalColor = new(true) { Enabled = true, Value = DefaultColors.Red.GetWithTransparency(50).Convert() };

            BuySignalAlertFilter = new(true) { Enabled = true, Value = "alert1" };
            SellSignalAlertFilter = new(true) { Enabled = true, Value = "alert1" };

            BuySignalColor.PropertyChanged += OnSignalPropertyChanged;
            SellSignalColor.PropertyChanged += OnSignalPropertyChanged;

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
                // Buy signal
                _signals[bar] = 1m;
            }
            else if (this[bar - 1] >= OverboughtLevel && this[bar] < OverboughtLevel)
            {
                // Sell signal
                _signals[bar] = -1m;
            }

            // Alerts
            if (bar == (CurrentBar - 1) && InstrumentInfo is not null)
            {
                if (BuySignalColor.Enabled && BuySignalAlertFilter.Enabled && (bar != _lastBuySignalAlertBar) && (_signals[bar] > 0))
                {
                    AddAlert(BuySignalAlertFilter.Value, InstrumentInfo.Instrument, $"BUY SIGNAL: Laguerre RSI leaving oversold region {this[bar]:0.#####}", DefaultColors.Black.Convert(), BuySignalColor.Value);
                    _lastBuySignalAlertBar = bar;
                }

                if (SellSignalColor.Enabled && SellSignalAlertFilter.Enabled && (bar != _lastSellSignalAlertBar) && (_signals[bar] < 0))
                {
                    AddAlert(SellSignalAlertFilter.Value, InstrumentInfo.Instrument, $"SELL SIGNAL: Laguerre RSI leaving overbought region {this[bar]:0.#####}", DefaultColors.Black.Convert(), SellSignalColor.Value);
                    _lastSellSignalAlertBar = bar;
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

            if (!BuySignalColor.Enabled && !SellSignalColor.Enabled)
                return;

            Color buyColor = BuySignalColor.Value.Convert();
            Color sellColor = SellSignalColor.Value.Convert();
            int topY = Container.Region.Top;
            int bottomY = Container.Region.Bottom;
            int height = bottomY - topY;

            for (int i = FirstVisibleBarNumber; i <= LastVisibleBarNumber; i++)
            {
                bool buySignal = _signals[i] > 0;
                bool sellSignal = _signals[i] < 0;

                if ((buySignal && BuySignalColor.Enabled) || (sellSignal && SellSignalColor.Enabled))
                {
                    int leftX = ChartInfo.GetXByBar(i, true) - 1;
                    int rightX = ChartInfo.GetXByBar(i + 1, true) - 1;
                    int width = (rightX - leftX) - 1;
                    Rectangle signalRect = new Rectangle(leftX, topY, width, height);

                    context.FillRectangle(buySignal ? buyColor : sellColor, signalRect);
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
