using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoingViral
{
	public class Condition
	{
		/// <summary>
		/// The constructor for a new condition
		/// </summary>
		/// <param name="system">The system that this condition belongs to</param>
		/// <param name="name">The name of the condition</param>
		/// <param name="infectiousness">A multiplier for how much more/less infectious the virus becomes</param>
		/// <param name="survivability">A multiplier for how much more/less survivable the virus becomes</param>
		/// <param name="visibility">A multiplier for how much more/less visible the virus becomes</param>
		/// <param name="tooltip">A string containing what will be displayed to the user</param>
		public Condition( string system, string name, double infectiousness, double survivability, double visibility, string tooltip )
		{
			System = system;
			Name = name;
			InfectiousnessMultiplier = infectiousness;
			SurvivabilityMultiplier = survivability;
			VisibilityMultiplier = visibility;
			Tooltip = tooltip;
		}
		/// <summary>
		/// The name of this condition
		/// </summary>
		public string Name;

		/// <summary>
		/// This is the part of the body affected by this condition
		/// </summary>
		public string System;

		/// <summary>
		/// The amount that this condition will increase infectiousness
		/// by. This is a multiplier.
		/// </summary>
		public double InfectiousnessMultiplier;

		/// <summary>
		/// The amount that this condition will affect how long hosts can
		/// survive with this virus. This is a multiplier.
		/// </summary>
		public double SurvivabilityMultiplier;

		/// <summary>
		/// The amount that this condition will affect how visible the virus
		/// is. This is a multiplier
		/// </summary>
		public double VisibilityMultiplier;

		/// <summary>
		/// The tool tip that is used to let the user know about this symptom.
		/// </summary>
		public string Tooltip;
	}
}
