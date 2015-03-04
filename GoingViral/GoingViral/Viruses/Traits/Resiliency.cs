using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoingViral
{
    /// <summary>
    /// Represents how long a virus can survive outside the host's body
    /// </summary>
    enum Resiliency
    {
        /// <summary>
        /// The virus dies instantly
        /// </summary>
        Instant,

        /// <summary>
        /// The virus lives for seconds. Does not travel very far.
        /// </summary>
        Seconds,

        /// <summary>
        /// The virus lives for minutes. Travels a little farther.
        /// </summary>
        Minutes,

        /// <summary>
        /// The virus lives for hours. May now infect water sources.
        /// </summary>
        Hours,

        /// <summary>
        /// The virus lives for days. May now infect water sources
        /// more effectively, and also the air.
        /// </summary>
        Days,

        /// <summary>
        /// The virus lives for weeks. It may now infect the air more
        /// effectively.
        /// </summary>
        Weeks,

        /// <summary>
        /// The virus lives for months. Water and Air sources are now
        /// resistent to disinfection.
        /// </summary>
        Months,

        /// <summary>
        /// The virus now lives for years. Disinfection is nearly impossible.
        /// </summary>
        Years,

        /// <summary>
        /// Water sources and Air no longer ever disinfect, and actually
        /// progressively infect more.
        /// </summary>
        Forever
    }
}
