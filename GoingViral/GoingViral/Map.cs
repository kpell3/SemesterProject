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
    class Map
    {
        /// <summary>
        /// This will generate the inital map conditions.
        /// This is a lot of hard coded values for how the map should look.
        /// </summary>
        public Map()
        {
            //Initialize the map
            for (int x = 0; x < 10; ++x)
            {
                theMap.Add(new Location("TestLocation" + x.ToString()));
                for (int y = 0; y < 10; ++y)
                {
                    theMap[x].LocationsAdjacentByLand.Add("TestLocation" + y);
                }
            }
        }
        /// <summary>
        /// The execution of a single turn happens here.
        /// </summary>
        public void TakeOneTurn()
        {
            //Execute anything that needs to happen world wide
            foreach (Location loc in theMap)
            {
                loc.TakeOneTurn();
            }
        }
        /// <summary>
        /// A List of locations that actually makes up the map itself
        /// </summary>
        public List<Location> theMap = new List<Location>();
    }
}
