using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoingViral
{
    /// <summary>
    /// This represents a virus that is currently active in the simulation and
    /// is being controlled by the user. Often, this virus has not yet actually
    /// been deployed, since deploying it will set the conditions of the virus.
    /// </summary>
    public class ActiveVirus : Virus
    {
        ActiveVirus()
        {

        }
        /// <summary>
        /// Will add a new condition to the list of conditions this virus will
        /// have when it is deployed.
        /// </summary>
        /// <param name="newCondition">The condition to add</param>
        void AddCondition( Condition newCondition )
        {
            Conditions.Add(newCondition);
        }
        /// <summary>
        /// Will remove a condition from the list of conditions this virus will
        /// have when it is deployed.
        /// </summary>
        /// <param name="toRemove">The condition to be removed</param>
        void RemoveCondition(Condition toRemove)
        {
            if( Conditions.Contains( toRemove ) )
            {
                Conditions.Remove( toRemove );
            }
        }
        /// <summary>
        /// Represents how long before a host will get over this virus on
        /// their own.
        /// </summary>
        public Progression VirusProgression
        {
            get;
            set;
        }
        /// <summary>
        /// Will lock down the list of conditions, finalize the virus, and put
        /// it into the wild.
        /// </summary>
        public void TriggerInitialInfection()
        {
        }

        /// <summary>
        /// A list of conditions that this virus has
        /// </summary>
        private List<Condition> Conditions = new List<Condition>();
    }
}
