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
    public class Location
    {
        /// <summary>
        /// The name of the location to be displayed on the map
        /// </summary>
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// This is the base population of this area
        /// </summary>
        public double Population
        {
            get;
            set;
        }

        public Tuple<int, int> Coordinates
        {
            get;
            set;
        }

        /// <summary>
        /// Locations that you can walk or drive to from this location
        /// </summary>
        public List<string> LocationsAdjacentByLand = new List<string>();

        /// <summary>
        /// Locations that you can fly to from this location
        /// </summary>
        public List<string> LocationsAdjacentByAir = new List<string>();

        /// <summary>
        /// Locations that you can take a boat to from this location
        /// </summary>
        public List<string> LocationsAdjacentBySea = new List<string>();

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

        public Location(string rawLocationInformation)
        {
            string[] rawInfos = rawLocationInformation.Split(new string[] { "|" }, StringSplitOptions.None);

            for (int i = 0; i < rawInfos.Length; i++)
            {
                switch (i)
                {
                    case 0: // name field
                        Name = rawInfos[i].Replace(" ", string.Empty).Trim();
                        break;

                    case 1: // population field
                        Population = int.Parse(rawInfos[i].Replace(",", string.Empty).Trim());
                        break;

                    case 2: // coordinate field
                        string[] coords = rawInfos[i].Split(new string[] { "," }, StringSplitOptions.None);
                        int x = int.Parse(coords[0]);
                        int y = int.Parse(coords[1]);

                        Coordinates = new Tuple<int, int>(x, y);
                        break;

                    case 3: // locations adjacent by land
                        string[] regionNames1 = rawInfos[i].Split(new string[] { "," }, StringSplitOptions.None);
                        foreach (string region in regionNames1)
                        {
                            LocationsAdjacentByLand.Add(region.Replace(" ", string.Empty));
                        }
                        break;

                    case 4: // locations adjacent by air
                        string[] regionNames2 = rawInfos[i].Split(new string[] { "," }, StringSplitOptions.None);
                        foreach (string region in regionNames2)
                        {
                            LocationsAdjacentByAir.Add(region.Replace(" ", string.Empty));
                        }
                        break;

                    case 5: // locations adjacent by sea
                        string[] regionNames3 = rawInfos[i].Split(new string[] { "," }, StringSplitOptions.None);
                        foreach (string region in regionNames3)
                        {
                            LocationsAdjacentBySea.Add(region.Replace(" ", string.Empty));
                        }
                        break;

                }
            }
        }

        public Location(string name, double population)
        {
            Name = name;
            Population = population;
        }

        /// <summary>
        /// Will take one turn at this location.
        /// </summary>
        public List<string> TakeOneTurn()
        {
            //Run through the InfectedHosts list.
            List<string> InfectionsToTrigger = new List<string>();
            List<Host> DeadHosts = new List<Host>();
            List<Host> CuredHosts = new List<Host>();

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
                //This will progress the virus and cause then store the status of the host
                Status EndStatus = thisHost.Progress();
                if (EndStatus == Status.Dead)
                {
                    DeadHosts.Add(thisHost);
                }
                else if (EndStatus == Status.Uninfected)
                {
                    CuredHosts.Add(thisHost);
                }
            }

            //Time to modify the infected hosts list. This cannot be done in the first foreach because of
            //C# rules about modifying a list you are recursing over.
            foreach (Host deadhost in DeadHosts)
            {
                Population -= deadhost.NumberOfPeopleRepresentedByThisHost;
                if (Population < 0)
                    Population = 0;

                InfectedHosts.Remove(deadhost);
            }

            foreach (Host curedhost in CuredHosts)
            {
                InfectedHosts.Remove(curedhost);
            }

            return InfectionsToTrigger;
            //Determine if the Water/Air got infected.
            //Determine if the area has been quarentined
        }

        /// <summary>
        /// This will create a newly infected host in this region
        /// </summary>
        public void InfectNewHost(Virus theVirus)
        {
            if (Population > 0)
            {
                if (InfectedHosts.Count == 0 || InfectedHosts.Count * InfectedHosts[0].NumberOfPeopleRepresentedByThisHost < Population)
                {
                    if (InfectedHosts.Count >= 1000)
                    {
                        for (int x = 0; x < 100; ++x)
                        {
                            InfectedHosts[x].NumberOfPeopleRepresentedByThisHost *= 10;
                        }

                        InfectedHosts.RemoveRange(100, InfectedHosts.Count - 100);
                    }
                    else if (InfectedHosts.Count > 0)
                    {
                        InfectedHosts.Add(new Host(theVirus, InfectedHosts[0].NumberOfPeopleRepresentedByThisHost));
                    }
                    else
                    {
                        InfectedHosts.Add(new Host(theVirus, 1.0));
                    }
                }
            }
        }
    }
}
