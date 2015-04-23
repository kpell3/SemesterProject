using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoingViral
{
	/// <summary>
	/// This represents a virus that is currently active in the simulation and
	/// is being controlled by the user. Often, this virus has not yet actually
	/// been deployed, since deploying it will set the conditions of the virus.
	/// </summary>
	public class ActiveVirus : Virus
	{
		public ActiveVirus()
		{
			VirusProgression = Progression.Acute;
			AdditionalInfectiousness = 1;
		}
		/// <summary>
		/// Will add a new condition to the list of conditions this virus will
		/// have when it is deployed.
		/// </summary>
		/// <param name="newCondition">The condition to add</param>
		public void AddCondition( Condition newCondition )
		{
			Conditions.Add( newCondition );
			UpdateVirusInformation();
		}
		/// <summary>
		/// Will remove a condition from the list of conditions this virus will
		/// have when it is deployed.
		/// </summary>
		/// <param name="toRemove">The condition to be removed</param>
		public void RemoveCondition( Condition toRemove )
		{
			if( Conditions.Contains( toRemove ) )
			{
				Conditions.Remove( toRemove );
				UpdateVirusInformation();
			}
		}

		public void UpdateVirusInformation()
		{
			TimeToKill = 30;
			TimeToRecover = 1;
			Infectiousness = 1;
			foreach( Condition cond in Conditions )
			{
				TimeToKill /= cond.SurvivabilityMultiplier;
				TimeToRecover *= cond.SurvivabilityMultiplier;
				Infectiousness *= cond.InfectiousnessMultiplier;
			}
			Infectiousness *= AdditionalInfectiousness;
		}
		/// <summary>
		/// Represents how long before a host will get over this virus on
		/// their own.
		/// </summary>
		public Progression VirusProgression
		{
			get;
			set;
		}
		/// <summary>
		/// Will lock down the list of conditions, finalize the virus, and put
		/// it into the wild.
		/// </summary>
		public void TriggerInitialInfection()
		{
		}

		/// <summary>
		/// A list of conditions that this virus has
		/// </summary>
		private List<Condition> Conditions = new List<Condition>();

		public bool HasCondition( string condition )
		{
			foreach( Condition cond in Conditions )
			{
				if( cond.Name == condition )
				{
					return true;
				}
			}
			return false;
		}

		/// <summary>
		/// Represents an extra boost to infectiousness using the slider
		/// </summary>
		public double AdditionalInfectiousness
		{
			get;
			set;
		}
	}
}
