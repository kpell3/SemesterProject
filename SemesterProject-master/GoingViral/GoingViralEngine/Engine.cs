using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoingViralEngine
{
    /// <summary>
    /// This is the core engine of the program. It will be in charge of running
    /// the runtime loop, and keeping track of the map, and other game-wide
    /// events.
    /// </summary>
    public class Engine
    {
        /// <summary>
        /// A basic constructor
        /// </summary>
        public Engine()
        {
        }
        /// <summary>
        /// Will run one turn of the game
        /// </summary>
        public void TakeOneTurn()
        {
            try
            {
                theMap.TakeOneTurn();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Will run the simulation in a realtime loop based upon
        /// the NumberOfTurnsPerSecond.
        /// </summary>
        public void RunSimulation()
        {
            //This will need to be a timed runtime loop, processing turns
            //using the stopwatch
            while (true)
            {
                theMap.TakeOneTurn();
            }
        }

        /// <summary>
        /// The map object representing the game board.
        /// </summary>
        Map theMap = new Map();
        //need some kind of a stopwatch to keep track of time to make turns
        //process smoothly
        public double NumberOfTurnsPerSecond = 1;
    }
}
