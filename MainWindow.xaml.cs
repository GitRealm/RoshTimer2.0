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
    using System.ComponentModel;
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

            this.TimeAegis.DataContext = this.aegisTimer;
            this.TimeMinResp.DataContext = this.minRespTimer;
            this.TimeMaxResp.DataContext = this.maxRespTimer;

            var dispatcherTimer = new BackgroundWorker();
            dispatcherTimer.DoWork += this.TimerEvent;
            dispatcherTimer.WorkerReportsProgress = true;
            dispatcherTimer.RunWorkerAsync();
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
        private void TimerEvent(object? sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            while (!worker.CancellationPending)
            {
                if (!this.paused)
                {
                    this.aegisTimer.Tick();
                    this.minRespTimer.Tick();
                    this.maxRespTimer.Tick();
                }
                System.Threading.Thread.Sleep(1000);
            }
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
            
                this.paused = !this.paused;
                this.PauseButton.Content = this.paused ?  "Resume": "Pause";


        }
    }
}
