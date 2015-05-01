using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoingViral
{
	/// <summary>
	/// Represents the world in its current state. Any worldwide or regional
	/// events will happen here.
	/// </summary>
	public class Map
	{
		/// <summary>
		/// This will generate the inital map conditions.
		/// This is a lot of hard coded values for how the map should look.
		/// </summary>
		public Map()
		{
			//Initialize the map
            theMap.Load();
		}
		/// <summary>
		/// The execution of a single turn happens here.
		/// </summary>
		public bool TakeOneTurn( Virus theVirus )
		{
			//Execute anything that needs to happen world wide
			List<string> InfectionsToTrigger = new List<string>();
			foreach( Location loc in theMap )
			{
				InfectionsToTrigger.AddRange( loc.TakeOneTurn() );
			}
			foreach( string loc1 in InfectionsToTrigger )
			{
				foreach( Location loc2 in theMap )
				{
					if( loc2.Name.Equals( loc1, StringComparison.Ordinal ) )
					{
						loc2.InfectNewHost( theVirus );
					}
				}
			}
			//Check to make sure at least one location still has someone alive there,
			//and that someone is infected somewhere.
			foreach( Location loc in theMap )
			{
				if( loc.Population != 0 )
				{
					return true;
				}
			}
			//Everybody's dead Dave.
			return false;
		}

		public Location GetLocationByName( string name )
		{
            return theMap.FirstOrDefault(l => l.Name == name);
		}

		/// <summary>
		/// A List of locations that actually makes up the map itself
		/// </summary>
		public LocationCollection theMap = new LocationCollection();

		public void ReleaseVirus( Virus theVirus )
		{
			Random random = new Random();
			int i = random.Next( 0, theMap.Count );
			theMap[i].InfectNewHost( theVirus );
		}
	}
}

