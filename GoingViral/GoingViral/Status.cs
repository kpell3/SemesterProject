using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoingViral
{
	/// <summary>
	/// This is an enum representing the Status of a host.
	/// A host can be either Uninfected, Dead, or Still Infected
	/// </summary>
	public enum Status
	{
		/// <summary>
		/// The host is not infected. This signals removal of the host
		/// from tracking without increasing the dead count.
		/// </summary>
		Uninfected,
		/// <summary>
		/// This host is dead. It should be removed from the list and added
		/// to the dead count.
		/// </summary>
		Dead,
		/// <summary>
		/// This host is still infected. It should continue to be tracked.
		/// </summary>
		StillInfected
	}
}

