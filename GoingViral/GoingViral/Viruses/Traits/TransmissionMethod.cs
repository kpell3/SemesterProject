using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoingViral
{
	/// <summary>
	/// Represents how a virus is transferred from one host to another
	/// </summary>
	public enum TransmissionMethod
	{
		/// <summary>
		/// Means a virus is carried in the blood. Not very effective
		/// for transmission, because blood-transfer between humans is rare.
		/// </summary>
		Bloodbourne,

		/// <summary>
		/// Means a virus is transferred via touching another person. This can
		/// be effective, but is easily stopped by gloves and protective
		/// equipment.
		/// </summary>
		SkinTransfer,

		/// <summary>
		/// Means a virus is transferred via infected water. This means it is
		/// carried in saliva and other bodily fluids, as well as in water
		/// sources. This gives the potential for a water supply to become
		/// infected, very quickly spreading the virus in an area.
		/// </summary>
		Waterbourne,

		/// <summary>
		/// Means a virus is transferred through the air. This means that
		/// people who breathe on or near each other can get it. This also
		/// allows the air in an area to become thick with the virus,
		/// drastically increasing infection rates.
		/// </summary>
		Airbourne
	}
}
