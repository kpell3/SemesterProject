using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GoingViralEngine.Viruses.Traits;

namespace GoingViralEngine
{
    /// <summary>
    /// Represents a single location or area in the world. This will handle
    /// any location-wide things like hospitals, water and air infections, etc.
    /// </summary>
    public class Location
    {
        private Tuple<int, int> _coordinates;
        private int _population;

        public Location(string name, int pop, Tuple<int, int> coord)
        {
            Name = name;
            Population = pop;
            _coordinates = coord;
        }
        /// <summary>
        /// Will take one turn at this location.
        /// </summary>
        public List<string> TakeOneTurn()
        {
            //Run through the InfectedHosts list.
            List<string> InfectionsToTrigger = new List<string>();
            foreach (Host thisHost in InfectedHosts)
            {
                //A virus can always spread locally.
                List<string> InfectableLocations = new List<string>();
                InfectableLocations.Add(Name);
                //A virus can always spread by land if the area isn't under quarentine.
                if (!IsUnderQuarentine)
                {
                    InfectableLocations.AddRange(LocationsAdjacentByLand);
                }
                //A virus can only spread by sea if carried in the air or in the water.
                if (thisHost.InfectedBy.VirusTransmissionMethod == TransmissionMethod.Waterbourne
                    || thisHost.InfectedBy.VirusTransmissionMethod == TransmissionMethod.Airbourne)
                {
                    InfectableLocations.AddRange(LocationsAdjacentBySea);
                }
                //A virus can only spread by plane if carried in the air. Airlines use bottled water.
                if (thisHost.InfectedBy.VirusTransmissionMethod == TransmissionMethod.Airbourne)
                {
                    InfectableLocations.AddRange(LocationsAdjacentByAir);
                }
                InfectionsToTrigger.AddRange(thisHost.Infect(InfectableLocations));
                thisHost.Progress();
            }
            return InfectionsToTrigger;
            //Determine if the Water/Air got infected.
            //Determine if the area has been quarentined
        }
        /// <summary>
        /// This will create a newly infected host in this region, and progress the 
        /// </summary>
        public void InfectNewHost()
        {
        }
        /// <summary>
        /// The name of the location to be displayed on the map
        /// </summary>
        public string Name
        {
            get;
            private set;
        }

        public Tuple<int, int> Coordinates
        {
            get
            {
                return _coordinates;
            }

        }

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

        /// <summary>
        /// This is the base population of this area
        /// </summary>
        public int Population
        {
            get { return _population; }
            set { _population = value; }
        }
    }
}
