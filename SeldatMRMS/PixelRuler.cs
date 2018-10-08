using System;
using System.Globalization;
using System.Windows;
using System.Windows.Media;

namespace SeldatMRMS
{
    /// <summary>
    /// A ruler control which displays ruler in pixels.
    /// In order to use it vertically, change the <see cref="Marks">Marks</see> property to <c>Up</c> and rotate it ninety degrees.
    /// </summary>
    /// <remarks>
    /// Rewritten by: Sebestyen Murancsik
    /// 
    /// Contributions from <see
    /// cref="http://www.orbifold.net/default/?p=2295&amp;cpage=1#comment-61500">Raf
    /// Lenfers</see>
    /// <seealso>http://visualizationtools.net/default/wpf-ruler/</seealso>
    /// </remarks>
    public class PixelRuler : FrameworkElement
    {
        #region Fields
        private double SegmentHeight;
        private readonly Pen p = new Pen(Brushes.Black, 1.0);
        private readonly Pen ThinPen = new Pen(Brushes.Black, 0.5);
        private readonly Pen BorderPen = new Pen(Brushes.Gray, 0); //1.0
        private readonly Pen RedPen = new Pen(Brushes.Red, 2.0);
        #endregion

        #region Properties

        #region Length
        /// <summary>
        /// Gets or sets the length of the ruler. If the <see cref="AutoSize"/> property is set to false (default) this
        /// is a fixed length. Otherwise the length is calculated based on the actual width of the ruler.
        /// </summary>
        public double Length
        {
            get
            {
                if (this.AutoSize)
                {
                    return ActualWidth / Zoom;
                }
                else
                {
                    return (double)GetValue(LengthProperty);
                }
            }
            set
            {
                SetValue(LengthProperty, value);
            }
        }

        /// <summary>
        /// Identifies the Length dependency property.
        /// </summary>
        public static readonly DependencyProperty LengthProperty =
             DependencyProperty.Register(
                  "Length",
                  typeof(double),
                  typeof(PixelRuler),
                  new FrameworkPropertyMetadata(20D, FrameworkPropertyMetadataOptions.AffectsRender));
        #endregion

        #region AutoSize
        /// <summary>
        /// Gets or sets the AutoSize behavior of the ruler.
        /// false (default): the lenght of the ruler results from the <see cref="Length"/> property. If the window size is changed, e.g. wider
        ///						than the rulers length, free space is shown at the end of the ruler. No rescaling is done.
        /// true				 : the length of the ruler is always adjusted to its actual width. This ensures that the ruler is shown
        ///						for the actual width of the window.
        /// </summary>
        public bool AutoSize
        {
            get
            {
                return (bool)GetValue(AutoSizeProperty);
            }
            set
            {
                SetValue(AutoSizeProperty, value);
                this.InvalidateVisual();
            }
        }

        /// <summary>
        /// Identifies the AutoSize dependency property.
        /// </summary>
        public static readonly DependencyProperty AutoSizeProperty =
             DependencyProperty.Register(
                  "AutoSize",
                  typeof(bool),
                  typeof(PixelRuler),
                  new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.AffectsRender));
        #endregion

        #region Zoom
        /// <summary>
        /// Gets or sets the zoom factor for the ruler. The default value is 1.0. 
        /// </summary>
        public double Zoom
        {
            get
            {
                return (double)GetValue(ZoomProperty);
            }
            set
            {
                SetValue(ZoomProperty, value);
                this.InvalidateVisual();
            }
        }

        /// <summary>
        /// Identifies the Zoom dependency property.
        /// </summary>
        public static readonly DependencyProperty ZoomProperty =
            DependencyProperty.Register("Zoom", typeof(double), typeof(PixelRuler),
            new FrameworkPropertyMetadata((double)1.0,
                FrameworkPropertyMetadataOptions.AffectsRender));

        #endregion

        #region SmallStep
        /// <summary>
        /// Gets or sets the small step for the ruler. The default value is 25.0. 
        /// </summary>
        public double SmallStep
        {
            get
            {
                return (double)GetValue(SmallStepProperty);
            }
            set
            {
                SetValue(SmallStepProperty, value);
                this.InvalidateVisual();
            }
        }

        /// <summary>
        /// Identifies the Zoom dependency property.
        /// </summary>
        public static readonly DependencyProperty SmallStepProperty =
            DependencyProperty.Register("SmallStep", typeof(double), typeof(PixelRuler),
            new FrameworkPropertyMetadata((double)25.0,
                FrameworkPropertyMetadataOptions.AffectsRender));

        #endregion

        #region Step
        /// <summary>
        /// Gets or sets the step for the ruler. The default value is 100.0. 
        /// </summary>
        public double Step
        {
            get
            {
                return (double)GetValue(StepProperty);
            }
            set
            {
                SetValue(StepProperty, value);
                this.InvalidateVisual();
            }
        }

        /// <summary>
        /// Identifies the Zoom dependency property.
        /// </summary>
        public static readonly DependencyProperty StepProperty =
            DependencyProperty.Register("Step", typeof(double), typeof(PixelRuler),
            new FrameworkPropertyMetadata((double)100.0,
                FrameworkPropertyMetadataOptions.AffectsRender));

        #endregion

        #region Chip

        /// <summary>
        /// Chip Dependency Property
        /// </summary>
        public static readonly DependencyProperty ChipProperty =
             DependencyProperty.Register("Chip", typeof(double), typeof(PixelRuler),
                  new FrameworkPropertyMetadata((double)-1000,
                        FrameworkPropertyMetadataOptions.AffectsRender));

        /// <summary>
        /// Sets the location of the chip in the units of the ruler.
        /// So, to set the chip to 100px units the chip needs to be set to 100.
        /// Use the <see cref="DipHelper"/> class for conversions.
        /// </summary>
        public double Chip
        {
            get { return (double)GetValue(ChipProperty); }
            set { SetValue(ChipProperty, value); }
        }
        #endregion

        #region CountShift

        /// <summary>
        /// CountShift Dependency Property
        /// </summary>
        public static readonly DependencyProperty CountShiftProperty =
             DependencyProperty.Register("CountShift", typeof(int), typeof(PixelRuler),
                  new FrameworkPropertyMetadata(0,
                        FrameworkPropertyMetadataOptions.AffectsRender));

        /// <summary>
        /// By default the counting of numbers starts at zero, this property allows you to shift
        /// the counting.
        /// </summary>
        public int CountShift
        {
            get { return (int)GetValue(CountShiftProperty); }
            set { SetValue(CountShiftProperty, value); }
        }

        #endregion

        #region Marks

        /// <summary>
        /// Marks Dependency Property
        /// </summary>
        public static readonly DependencyProperty MarksProperty =
             DependencyProperty.Register("Marks", typeof(MarksLocation), typeof(PixelRuler),
                  new FrameworkPropertyMetadata(MarksLocation.Up,
                         FrameworkPropertyMetadataOptions.AffectsRender));

        /// <summary>
        /// Gets or sets where the marks are shown in the ruler.
        /// </summary>
        public MarksLocation Marks
        {
            get { return (MarksLocation)GetValue(MarksProperty); }
            set { SetValue(MarksProperty, value); }
        }

        #endregion
        
        #endregion

        #region Constructor
        static PixelRuler()
        {
            HeightProperty.OverrideMetadata(typeof(PixelRuler), new FrameworkPropertyMetadata(20.0));
        }
        public PixelRuler()
        {
            SegmentHeight = this.Height - 10;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Participates in rendering operations.
        /// </summary>
        /// <param name="drawingContext">The drawing instructions for a specific element. This context is provided to the layout system.</param>
        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);
            double xDest = Length * Zoom;

            drawingContext.DrawRectangle(null, BorderPen, new Rect(new Point(0.0, 0.0), new Point(xDest, Height)));
            drawingContext.DrawLine(RedPen, new Point(Chip, 0), new Point(Chip, Height));

            for (double dUnit = 0; dUnit < Length; dUnit += SmallStep)
            {
                double d = dUnit * this.Zoom;

                double startHeight;
                double endHeight;
                if (Marks == MarksLocation.Up)
                {
                    startHeight = 0;
                    // Main step or small step?
                    endHeight = ((dUnit % Step == 0) ? SegmentHeight : SegmentHeight / 2);
                }
                else
                {
                    startHeight = Height;
                    // Main step or small step?
                    endHeight = ((dUnit % Step == 0) ? SegmentHeight : SegmentHeight * 1.5);
                }

                drawingContext.DrawLine(ThinPen, new Point(d, startHeight), new Point(d, endHeight));

                if ((dUnit != 0.0) && (dUnit % Step == 0) && (dUnit < Length))
                {
                    FormattedText ft = new FormattedText(
                        (dUnit + CountShift).ToString(CultureInfo.CurrentCulture),
                            CultureInfo.CurrentCulture,
                            FlowDirection.LeftToRight,
                            new Typeface("Arial"),
                            DipHelper.PtToDip(6),
                            Brushes.DimGray);
                    ft.SetFontWeight(FontWeights.Regular);
                    ft.TextAlignment = TextAlignment.Center;

                    if (Marks == MarksLocation.Up)
                        drawingContext.DrawText(ft, new Point(d, Height - ft.Height));
                    else
                        drawingContext.DrawText(ft, new Point(d, Height - SegmentHeight - ft.Height));
                }
            }
        }

        #endregion
    }

    public enum MarksLocation
    {
        Up, Down
    }

    /// <summary>
    /// A helper class for DIP (Device Independent Pixels) conversion and scaling operations.
    /// </summary>
    public static class DipHelper
    {
        /// <summary>
        /// Converts font points to DIP (Device Independant Pixels).
        /// </summary>
        /// <param name="pt">A font point value.</param>
        /// <returns>A DIP value.</returns>
        public static double PtToDip(double pt)
        {
            return (pt * 96.0 / 72.0);
        }


        /// <summary>
        /// Gets the system DPI scale factor (compared to 96 dpi).
        /// From http://blogs.msdn.com/jaimer/archive/2007/03/07/getting-system-dpi-in-wpf-app.aspx
        /// Should not be called before the Loaded event (else XamlException mat throw)
        /// </summary>
        /// <returns>A Point object containing the X- and Y- scale factor.</returns>
        private static Point GetSystemDpiFactor()
        {
            PresentationSource source = PresentationSource.FromVisual(Application.Current.MainWindow);
            Matrix m = source.CompositionTarget.TransformToDevice;
            return new Point(m.M11, m.M22);
        }

        private const double DpiBase = 96.0;

        /// <summary>
        /// Gets the system configured DPI.
        /// </summary>
        /// <returns>A Point object containing the X- and Y- DPI.</returns>
        public static Point GetSystemDpi()
        {
            Point sysDpiFactor = GetSystemDpiFactor();
            return new Point(
                 sysDpiFactor.X * DpiBase,
                 sysDpiFactor.Y * DpiBase);
        }
    }
}