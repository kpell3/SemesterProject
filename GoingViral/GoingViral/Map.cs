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
			theMap.Add( new Location( "WestUS", 100000.0 ) );
			theMap.Add( new Location( "EastUS", 100000.0 ) );
			theMap.Add( new Location( "SouthCanada", 100000.0 ) );

			theMap[0].LocationsAdjacentByLand.Add( "EastUS" );
			theMap[0].LocationsAdjacentByLand.Add( "SouthCanada" );

			theMap[1].LocationsAdjacentByLand.Add( "WestUS" );
			theMap[1].LocationsAdjacentByLand.Add( "SouthCanada" );

			theMap[2].LocationsAdjacentByLand.Add( "EastUS" );
			theMap[2].LocationsAdjacentByLand.Add( "WestUS" );
		}
		/// <summary>
		/// The execution of a single turn happens here.
		/// </summary>
		public bool TakeOneTurn()
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
						loc2.InfectNewHost();
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
			foreach( Location loc in theMap )
			{
				if( loc.Name == name )
				{
					return loc;
				}
			}
			return null;
		}

		/// <summary>
		/// A List of locations that actually makes up the map itself
		/// </summary>
		public List<Location> theMap = new List<Location>();
	}
}
