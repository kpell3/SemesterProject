using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoingViral
{
	public class Host
	{
		public Host( Virus virus, double NumberOfPeople, int randomNumberSeed, double daysInfected = 0 )
		{

			InfectedBy = virus;
			NumberOfPeopleRepresentedByThisHost = NumberOfPeople;
			Rand = new Random( randomNumberSeed );
			DaysInfected = daysInfected;
		}

		/// <summary>
		/// Search for other hosts to infect based upon infectiousness
		/// </summary>
		public List<string> Infect( List<string> AccessibleLocations )
		{
			if( DaysInfected > InfectedBy.StartOfInfectiousness_Day )
			{
				//Well, this host is infectious. Better reach out and infect some people.
				//The first location in the list is the hosts own location. This is 95% more likely than any other location.
				List<string> locationsToInfect = new List<string>();
				double remainingInfectiousness = ( InfectedBy.Infectiousness ) - Rand.NextDouble();
				while( remainingInfectiousness > 0 )
				{
					//95% chance to infect the local area.
					if( Rand.NextDouble() > 0.005 )
					{
						locationsToInfect.Add( AccessibleLocations[ 0 ] );
						remainingInfectiousness--;
					}
					//5% chance to choose a random location of all adjacent locations and infect there
					else
					{
						locationsToInfect.Add( AccessibleLocations[ ( int )( Rand.NextDouble() * AccessibleLocations.Count ) ] );
						remainingInfectiousness--;
					}
				}
				return locationsToInfect;
			}
			//This host isn't infectious, so return a null list.
			return new List<string>();
		}
		/// <summary>
		/// causes this host's illness to progress
		/// </summary>
		/// <returns>Whether or not the host is alive. If the host is
		/// not alive, it will be disposed of within the Location</returns>
		public Status Progress()
		{
			DaysInfected++;
			if( DaysInfected > InfectedBy.IncubationPeriod_Days )
			{
				if( ( DaysInfected - InfectedBy.IncubationPeriod_Days ) > InfectedBy.TimeToKill + ( ( Rand.NextDouble() - 0.5 ) * InfectedBy.TimeToKill ) )
				{
					return Status.Dead;
				}
				if( ( DaysInfected - InfectedBy.IncubationPeriod_Days ) > InfectedBy.TimeToRecover + ( ( Rand.NextDouble() - 0.5 ) * InfectedBy.TimeToRecover ) )
				{
					return Status.Uninfected;
				}
			}
			return Status.StillInfected;
		}
		/// <summary>
		/// The Virus that this host is infected by
		/// </summary>
		public Virus InfectedBy
		{
			get;
			private set;
		}
		/// <summary>
		/// The number of days that this host has been infected.
		/// </summary>
		public double DaysInfected;
		/// <summary>
		/// Whether or not this host has been quarentined by any outside force
		/// </summary>
		public bool Quarentined;
		/// <summary>
		/// Whether or not this host is resistant to this virus.
		/// </summary>
		public double Resistance;
		/// <summary>
		/// Since we can't account for 7 billion people in the world, this is the block
		/// of people represented by this host. Initially, it will be 1, but once the array size
		/// passes 1000, we'll have to consolidate it.
		/// </summary>
		public double NumberOfPeopleRepresentedByThisHost
		{
			get;
			set;
		}
		private Random Rand;
	}
}
