using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoingViral
{
    /// <summary>
    /// The virus class is a glorified struct. It never actually acts on
    /// anything itself, it just stores a whole lot of variables.
    /// </summary>
    public class Virus
    {
        public Virus()
        {
            
        }
        /// <summary>
        /// The Strain of this virus. In a multi-player game, represents
        /// which player's virus this is.
        /// </summary>
        public double Strain
        {
            get;
            set;
        }
        /// <summary>
        /// Represents which iteration this virus is for its player.
        /// </summary>
        public double Number
        {
            get;
            set;
        }
        /// <summary>
        /// Represents how this virus is transmitted.
        /// </summary>
        public TransmissionMethod VirusTransmissionMethod
        {
            get;
            set;
        }
        /// <summary>
        /// Represents how long it takes before this virus starts showing
        /// symptoms.
        /// </summary>
        public double IncubationPeriod_Days
        {
            get;
            set;
        }
        /// <summary>
        /// Represents the amount of time between symptom onset and full
        /// symptoms.
        /// </summary>
        public double SymptomOnset_Days
        {
            get;
            private set;
        }
        /// <summary>
        /// Represents the day after the initial infection after which a host
        /// becomes infectious.
        /// </summary>
        public double StartOfInfectiousness_Day
        {
            get;
            private set;
        }
        /// <summary>
        /// Represents how long the host is infectious for. This number is
        /// counted from the day of Start of Infectiousness.
        /// </summary>
        public double InfectiousTime_Days
        {
            get;
            set;
        }
        /// <summary>
        /// Represents how long the virus can survive outside the body.
        /// Used to determine how far away a virus can infect new hosts.
        /// </summary>
        public Resiliency VirusResiliency
        {
            get;
            set;
        }
        /// <summary>
        /// The amount of time it takes this virus, on average, to kill
        /// a host. Each host has a percent chance of dieing when they get
        /// close to this time if they are still infected.
        /// Note: This time starts AFTER onset of symptoms
        /// </summary>
        public double TimeToKill
        {
            get;
            private set;
        }
        /// <summary>
        /// This is how long it will take to recover from this virus
        /// This is measured from the beginning of infection, since it is
        /// possible that one could recover from a virus before showing
        /// symptoms.
        /// </summary>
        public double TimeToRecover
        {
            get;
            private set;
        }
        /// <summary>
        /// This is a multiplier representing how infectious this virus is.
        /// </summary>
        public double Infectiousness
        {
            get;
            private set;
        }
    }
}
