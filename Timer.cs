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
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;

    /// <summary>
    /// The timer.
    /// </summary>
    internal class Timer
    {
        /// <summary>
        /// Initial seconds.
        /// </summary>
        private readonly int initialSeconds;

        /// <summary>
        /// Initializes a new instance of the <see cref="Timer"/> class.
        /// </summary>
        /// <param name="inputSeconds">
        /// The seconds.
        /// </param>
        public Timer(int inputSeconds)
        {
            this.Seconds = inputSeconds;
            this.initialSeconds = inputSeconds;
        }

        /// <summary>
        /// Gets or sets the seconds.
        /// </summary>
        public int Seconds { get; set; }

        /// <summary>
        /// Gets time string.
        /// </summary>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public string GetTimeString()
        {
            return TimeSpan.FromSeconds(this.Seconds).ToString("mm':'ss");
        }

        /// <summary>
        /// Resets the timer to the initial value.
        /// </summary>
        public void Reset()
        {
            this.Seconds = this.initialSeconds;
        }
    }
}
