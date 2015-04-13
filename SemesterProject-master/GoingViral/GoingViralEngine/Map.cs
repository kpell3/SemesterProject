using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoingViralEngine
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
            theMap = new List<Location>();
        }

        public Map(bool doTest)
            : this()
        {
            if (doTest)
            {
                //Initialize the map
                for (int x = 0; x < 10; ++x)
                {
                    for (int y = 0; y < 10; ++y)
                    {
                        theMap.Add(new Location(string.Format("TestLocation{0}", x), 100000, new Tuple<int, int>(x, y)));
                        theMap[x].LocationsAdjacentByLand.Add(string.Format("TestLocation{0}", y));
                    }
                }
            }
        }
        /// <summary>
        /// The execution of a single turn happens here.
        /// </summary>
        public void TakeOneTurn()
        {
            //Execute anything that needs to happen world wide
            List<string> InfectionsToTrigger = new List<string>();
            foreach (Location loc in theMap)
            {
                InfectionsToTrigger.AddRange(loc.TakeOneTurn());
            }
            foreach (string loc1 in InfectionsToTrigger)
            {
                foreach (Location loc2 in theMap)
                {
                    if (loc2.Name.Equals(loc1, StringComparison.Ordinal))
                    {
                        loc2.InfectNewHost();
                    }
                }
            }
        }
        /// <summary>
        /// A List of locations that actually makes up the map itself
        /// </summary>
        public List<Location> theMap;
    }

}
