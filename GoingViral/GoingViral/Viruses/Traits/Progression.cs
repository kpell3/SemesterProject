using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoingViral
{
    /// <summary>
    /// Represents how long symptoms stay active in a host
    /// </summary>
    enum Progression
    {
        /// <summary>
        /// Symptoms come and go within a day or so.
        /// </summary>
        Fleeting,

        /// <summary>
        /// Symptoms come and stay for about a week, but go away after that.
        /// </summary>
        Acute,

        /// <summary>
        /// Symptoms come and the host continues to suffer for months or years,
        /// but given enough time may recover.
        /// </summary>
        Chronic,

        /// <summary>
        /// Symptoms are with the host until the host dies.
        /// </summary>
        Terminal
    }
}
