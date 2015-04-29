using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoingViral.GUI;
using System.Threading;

namespace GoingViral
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
        public Engine(GameMode mMode)
        {
            //Initialize variables
            TheGUI = new GUI.GUI(this);
            mTheActiveVirus = new ActiveVirus();
            TheMap = new Map();
            TheGUI.mGameWindow.MapInfo = TheMap;
            TheGUI.mGameWindow.HUD.MapInfo = TheMap;
            TheGUI.mModifyVirusWindow.theVirus = mTheActiveVirus;
            TheGUI.mModifyVirusWindow.Populatebuttons();
            TheGUI.mModifyVirusWindow.ReleaseVirusButton.Click += ReleaseVirusButton_Click;
        }

        /// <summary>
        /// This button triggers the initial infection for a virus.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReleaseVirusButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            TheMap.ReleaseVirus(mTheActiveVirus as Virus);
        }

        /// <summary>
        /// Receives control of the program from the entry screen and prepares 
        /// to run the game
        /// </summary>
        public void StartGame()
        {
            Thread EngineThread = new Thread(RunSimulation);
            TheGUI.mGameWindow.Show();
            EngineThread.Start();
        }

        /// <summary>
        /// Will run one turn of the game
        /// </summary>
        public bool TakeOneTurn()
        {
            try
            {
                TheMap.TakeOneTurn(mTheActiveVirus as Virus);
                TheGUI.Update();
            }
            catch (Exception)
            {
                return false;
                //Throw E to some kind of error window
            }
            return true;
        }

        /// <summary>
        /// Will run the simulation in a realtime loop based upon
        /// the SleepDuration.
        /// </summary>
        public void RunSimulation()
        {
            //This will need to be a timed runtime loop, processing turns
            //using the stopwatch
            while (ContinueSimulation)
            {
                if (!PauseSimulation)
                {
                    ContinueSimulation = TheMap.TakeOneTurn(mTheActiveVirus as Virus);
                }
                TheGUI.Update();
                System.Threading.Thread.Sleep(SleepDuration);
            }
        }

        /// <summary>
        /// The map object representing the game board.
        /// </summary>
        public Map TheMap
        {
            get;
            private set;
        }

        /// <summary>
        /// A GUI that will be made when the game mode is decided.
        /// </summary>
        public GUI.GUI TheGUI
        {
            get;
            private set;
        }

        //need some kind of a stopwatch to keep track of time to make turns
        //process smoothly
        public double NumberOfTurnsPerSecond = 1;

        /// <summary>
        /// The Active Virus
        /// </summary>
        public ActiveVirus mTheActiveVirus
        {
            get;
            private set;
        }

        /// <summary>
        /// The number of DNA points that the player has. -1 is infinite.
        /// </summary>
        public double mDNAPoints
        {
            get;
            private set;
        }

        /// <summary>
        /// Represents whether or not the simulation should currently be paused.
        /// </summary>
        public bool PauseSimulation = true;

        /// <summary>
        /// Represents whether or not the simulation should be exited.
        /// </summary>
        public bool ContinueSimulation = true;

        /// <summary>
        /// Represents how long the sleep should be between each RTI.
        /// </summary>
        public int SleepDuration = 1000;
    }
}
