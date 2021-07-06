// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Timer.cs" company="N/A">
//   Mike Medford
// </copyright>
// <summary>
//   The timer.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RoshTime2._0
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls.Primitives;

    using RoshTime2._0.Annotations;

    /// <summary>
    /// The timer.
    /// </summary>
    internal class Timer: INotifyPropertyChanged
    {
        /// <summary>
        /// Initial seconds.
        /// </summary>
        private readonly int initialSeconds;

        private TimeSpan seconds;

        /// <summary>
        /// Initializes a new instance of the <see cref="Timer"/> class.
        /// </summary>
        /// <param name="inputSeconds">
        /// The seconds.
        /// </param>
        public Timer(int inputSeconds)
        {
            this.Seconds = new TimeSpan(0,0,inputSeconds);
            this.initialSeconds = inputSeconds;
        }

        public void Tick()
        {
            this.Seconds = this.Seconds.Add(new TimeSpan(0, 0, -1));
        }

        /// <summary>
        /// Gets or sets the seconds.
        /// </summary>
        public TimeSpan Seconds
        {
            get => this.seconds;
            set
            {

                this.seconds = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Resets the timer to the initial value.
        /// </summary>
        public void Reset()
        {
            this.Seconds = new TimeSpan(0,0,this.initialSeconds);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
