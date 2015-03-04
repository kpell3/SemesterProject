using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoingViral
{
    /// <summary>
    /// Represents a single location or area in the world. This will handle
    /// any location-wide things like hospitals, water and air infections, etc.
    /// </summary>
    class Location
    {
        public Location( string name )
        {
            Name = name;
        }
        /// <summary>
        /// Will take one turn at this location.
        /// </summary>
        public void TakeOneTurn()
        {
            //Run through the InfectedHosts list.
            foreach (Host thisHost in InfectedHosts)
            {
                thisHost.Infect();
            }
            //Determine if the Water/Air got infected.
            //Determine if the area has been quarentined
        }
        /// <summary>
        /// The name of the location to be displayed on the map
        /// </summary>
        public string Name;

        /// <summary>
        /// Locations that you can walk or drive to from this location
        /// </summary>
        public List<string> LocationsAdjacentByLand;

        /// <summary>
        /// Locations that you can fly to from this location
        /// </summary>
        public List<string> LocationsAdjacentByAir;

        /// <summary>
        /// Locations that you can take a boat to from this location
        /// </summary>
        public List<string> LocationsAdjacentBySea;

        /// <summary>
        /// A list of currently infected hosts.
        /// </summary>
        public List<Host> InfectedHosts = new List<Host>();

        /// <summary>
        /// Whether or not the water in this area has been infected
        /// </summary>
        public bool WaterInfected = false;

        /// <summary>
        /// Whether or not this area is under quarentine
        /// </summary>
        public bool IsUnderQuarentine = false;

        /// <summary>
        /// Whether or not the air in this area has been infected
        /// </summary>
        public bool AirInfected = false;
    }
}
