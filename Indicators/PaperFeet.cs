using ATAS.Indicators;
using ATAS.Indicators.Drawing;
using OFT.Rendering.Context;
using System.ComponentModel;
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
        private readonly ValueDataSeries _signals = new("Signals")
        {
            VisualType = VisualMode.Hide,
            IsHidden = true
        };

        #endregion

        #region Properties
        #endregion

        #region Constructor

        public PaperFeet()
        {
            // NOTE: The DataSeries must match the order found in PaperFeetDataSeriesIndexEnum.
            DataSeries.Add(_signals);

            _isRsiInitialized = false;
        }

        #endregion

        #region Indicator methods

        protected override void OnCalculate(int bar, decimal value)
        {
            base.OnCalculate(bar, value);

            if (bar == 0)
            {
                _signals.Clear();
            }

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
        }

        protected override void OnRender(RenderContext context, DrawingLayouts layout)
        {
            base.OnRender(context, layout);

            if (ChartInfo is null)
                return;

            if (Container is null)
                return;

            Color buyColor = DefaultColors.Green.GetWithTransparency(50);
            Color sellColor = DefaultColors.Red.GetWithTransparency(50);
            int topY = Container.Region.Top;
            int bottomY = Container.Region.Bottom;
            int height = bottomY - topY;

            for (int i = FirstVisibleBarNumber; i <= LastVisibleBarNumber; i++)
            {
                bool buySignal = _signals[i] > 0;
                bool sellSignal = _signals[i] < 0;

                if (buySignal || sellSignal)
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
    }
}
