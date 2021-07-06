// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MainWindow.xaml.cs" company="N/A">
//  Mike Medford 
// </copyright>
// <summary>
//   Interaction logic for MainWindow
// </summary>
// --------------------------------------------------------------------------------------------------------------------

#nullable enable
namespace RoshTime2._0
{
    using System;
    using System.Windows;
    using System.Windows.Threading;


    /// <summary>
    /// Interaction logic for MainWindow
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// The aegis timer.
        /// </summary>
        private readonly Timer aegisTimer;

        /// <summary>
        /// The min resp timer.
        /// </summary>
        private readonly Timer minRespTimer;

        /// <summary>
        /// The max resp timer.
        /// </summary>
        private readonly Timer maxRespTimer;

        /// <summary>
        /// The paused.
        /// </summary>
        private bool paused = false;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {
            this.InitializeComponent();

            this.aegisTimer = new Timer(300);
            this.minRespTimer = new Timer(480);
            this.maxRespTimer = new Timer(660);

            this.TimeAegis.Content = this.aegisTimer.GetTimeString();
            this.TimeMinResp.Content = this.minRespTimer.GetTimeString();
            this.TimeMaxResp.Content = this.maxRespTimer.GetTimeString();

            var dispatcherTimer = new DispatcherTimer(DispatcherPriority.Normal);
            dispatcherTimer.Tick += new EventHandler(this.TimerEvent);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();
        }

        /// <summary>
        /// The timer event.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void TimerEvent(object? sender, EventArgs e)
        {
            if (this.paused)
            {
                return;
            }

            this.aegisTimer.Seconds--;
            this.TimeAegis.Content = this.aegisTimer.GetTimeString();

            this.minRespTimer.Seconds--;
            this.TimeMinResp.Content = this.minRespTimer.GetTimeString();

            this.maxRespTimer.Seconds--;
            this.TimeMaxResp.Content = this.maxRespTimer.GetTimeString();
        }

        /// <summary>
        /// The reset button_ click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            this.aegisTimer.Reset();
            this.minRespTimer.Reset();
            this.maxRespTimer.Reset();
        }

        /// <summary>
        /// The pause button_ click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void PauseButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.paused)
            {
                this.paused = false;
                this.PauseButton.Content = "Pause";
            }
            else
            {
                this.paused = true;
                this.PauseButton.Content = "Resume";
            }
        }
    }
}
