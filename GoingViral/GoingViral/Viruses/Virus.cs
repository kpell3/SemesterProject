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
			//Have to generate objects for the list of conditions. This is done by system.
			Condition Dryness = new Condition( "Integumentary(Skin)", "Dryness", 1, 1.01, 1.05,
				"Dry Skin is not very visible, barely lethal, and does not affect infection." );
			Condition Rash = new Condition( "Integumentary(Skin)", "Rash", 1.10, 1.05, 1.15,
				"A Rash provides a method of spread through touch, and may be lethal if combined with other symptoms. It is very visible." );
			Condition OpenSores = new Condition( "Integumentary(Skin)", "Open Sores", 1.10, 1.10, 1.30,
				"Open sores provide good spread and lethality, but are very visible." );
			Condition Necrosis = new Condition( "Integumentary(Skin)", "Necrosis", 1.10, 3, 3,
				"Your skin just dies. All over. Very lethal and very visible." );

			Condition ToothDecay = new Condition( "Skeletal(Bones)", "Tooth Decay", 1, 1, 1.05,
				"Tooth decay is not contagious or lethal, but is slightly noticable." );
			Condition Osteoporosis = new Condition( "Skeletal(Bones)", "Osteoporosis", 1, 1.10, 1.05,
				"This means your bones develop holes and become weak. Can kill you over time, and only slightly visible." );
			Condition Osteopetrosis = new Condition( "Skeletal(Bones)", "Osteopetrosis", 1, 2, 1.05,
				"Your bones turn to stone and die. Can be very lethal because marrow dies, and hard to notice." );
			Condition Dissolution = new Condition( "Skeletal(Bones)", "Skeletal Dissolution", 1, 4, 3,
				"Your skeleton dissolves, leaving you in a puddle on the floor. Usually fatal, but obvious." );

			Condition Cramping = new Condition( "Muscular(Muscles)", "Cramping", 1, 1.05, 1.15,
				"Cramping is painful, and can therefore be seen, but a bad cramp at the wrong time can cause death" );
			Condition Tremors = new Condition( "Muscular(Muscles)", "Tremors", 1, 1.05, 1.05,
				"Tremors are involuntary movements of the muscle. They are not very deadly or visible." );
			Condition Dystrophy = new Condition( "Muscular(Muscles)", "Dystrophy", 1, 2, 2,
				"Muscular Dystrophy means that your muscles decay slowly. Can be quite deadly but also visible." );
			Condition LossOfControl = new Condition( "Muscular(Muscles)", "Loss Of Control", 1, 3, 3,
				"Total loss of muscular control. Very deadly but very noticable." );

			Condition MinorComp = new Condition( "Immune", "Minorly Compromised", 1.25, 1.10, 1.05,
				"The immune system is slightly compromised. Makes it harder to fight off new viruses, and can be fatal with other conditions. Barely visible." );
			Condition MajorComp = new Condition( "Immune", "Majorly Compromised", 1.25, 1.10, 1.05,
				"The immune system is now majorly compromised. Doubles the effects of minorly compromised." );
			Condition Useless = new Condition( "Immune", "Useless", 1.5, 1.20, 1.25,
				"The immune system is now useless, further doubling the majorly compromised, but much more visible." );
			Condition Rogue = new Condition( "Immune", "Rogue", 1.25, 3, 2,
				"The immune system has gone rogue and is now attacking the body. Very hard to survive, and increased infectiousness, but visible." );

			Condition Palpitation = new Condition( "Cardiovascular(Heart)", "Palpitation", 1, 1.10, 1.05,
				"Heart palpitations hurt, and can be dangerous, and aren't very visible." );
			Condition Murmur = new Condition( "Cardiovascular(Heart)", "Murmur", 1, 1.25, 1.10,
				"Heart murmurs are dangerous and not very visible." );
			Condition Hemophilia = new Condition( "Cardiovascular(Heart)", "Hemophilia", 1.25, 1.25, 1.10,
				"This means that your blood doesn't clot. This makes it splatter and can cause infection, and prevents you from healing from cuts effectively. It is somewhat visible." );
			Condition HeartFailure = new Condition( "Cardiovascular(Heart)", "Heart Failure", 1, 5, 2,
				"You need your heart. If if fails, it is almost always fatal without a transplant. It is also visible." );

			Condition Nausea = new Condition( "Digestive(Stomach)", "Nausea", 1, 1, 1.1,
				"Nausea is uncomfortable and noticable, but not deadly." );
			Condition Vomiting = new Condition( "Digestive(Stomach)", "Vomiting", 1.25, 1.25, 1.5,
				"Vomiting is noticable, but is also dangerous and gives potential for additional infection." );
			Condition Ulcers = new Condition( "Digestive(Stomach)", "Ulcers", 1, 1.5, 1.10,
				"Ulcers are dangerous, and not particularly visible until autopsy." );
			Condition DigestiveParalysis = new Condition( "Digestive(Stomach)", "Digestive Paralysis", 1, 4, 1.10,
				"Digestive paralysis is dangerous and hard to diagnose, and relatively invisible after death." );

			Condition Pleurisy = new Condition( "Respiratory(Lungs)", "Pleurisy", 1, 1.10, 1.5,
				"Pleurisy is an infection in the lungs that makes it painful to breathe. It can cause pneumonia if you don't breathe deeply." );
			Condition Pneumonia = new Condition( "Respiratory(Lungs)", "Pneumonia", 1, 1.5, 1.1,
				"Pneumonia is when your lungs fill up with fluid. It is dangerous, and often confused with other causes." );
			Condition CollapsedLung = new Condition( "Respiratory(Lungs)", "Collapsed Lung", 1, 3, 3,
				"Yep, a lung collapsed. Only having one lung doesn't usually last someone long." );
			Condition FloodedLungs = new Condition( "Respiratory(Lungs)", "Lungs Flooded", 1, 8, 5,
				"This is when a person's lungs fill completely with fluid, drowning them. Very difficult to treat, and results in death in minutes." );

			Condition Drowsiness = new Condition( "Nervous(Brain)", "Drowsiness", 1, 1.05, 1.01,
				"Drowsiness can be dangerous when operating machinery or driving. Lots of people are drowsy often, so it isn't really noticable." );
			Condition Seizures = new Condition( "Nervous(Brain)", "Seizures", 1.05, 1.5, 1.5,
				"Seizures are very visible and dangerous. They also can cause vomiting or draw blood, which can increase infection." );
			Condition Paralysis = new Condition( "Nervous(Brain)", "Paralysis", 0.95, 1.5, 1.5,
				"Sudden onset Paralysis can be extraordinarily dangerous and visible. However, due to the nature, it actually makes a host slightly less infectious." );
			Condition ALS = new Condition( "Nervous(Brain)", "ALS", 1, 10, 5,
				"ALS or Lou Gherig's disease is a degeneration of the nervous system. Is is chronic and fatal, but can take time to kill." );
			PossibleConditions = new List<Condition>();
			PossibleConditions.Add( Dryness );
			PossibleConditions.Add( Rash );
			PossibleConditions.Add( OpenSores );
			PossibleConditions.Add( Necrosis );
			PossibleConditions.Add( ToothDecay );
			PossibleConditions.Add( Osteoporosis );
			PossibleConditions.Add( Osteopetrosis );
			PossibleConditions.Add( Dissolution );
			PossibleConditions.Add( Cramping );
			PossibleConditions.Add( Tremors );
			PossibleConditions.Add( Dystrophy );
			PossibleConditions.Add( LossOfControl );
			PossibleConditions.Add( MinorComp );
			PossibleConditions.Add( MajorComp );
			PossibleConditions.Add( Useless );
			PossibleConditions.Add( Rogue );
			PossibleConditions.Add( Palpitation );
			PossibleConditions.Add( Murmur );
			PossibleConditions.Add( Hemophilia );
			PossibleConditions.Add( HeartFailure );
			PossibleConditions.Add( Nausea );
			PossibleConditions.Add( Vomiting );
			PossibleConditions.Add( Ulcers );
			PossibleConditions.Add( DigestiveParalysis );
			PossibleConditions.Add( Pleurisy );
			PossibleConditions.Add( Pneumonia );
			PossibleConditions.Add( CollapsedLung );
			PossibleConditions.Add( FloodedLungs );
			PossibleConditions.Add( Drowsiness );
			PossibleConditions.Add( Seizures );
			PossibleConditions.Add( Paralysis );
			PossibleConditions.Add( ALS );
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
		/// Represents the day after the initial infection after which a host
		/// becomes infectious.
		/// </summary>
		public double StartOfInfectiousness_Day
		{
			get;
			set;
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
			set;
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
			set;
		}
		/// <summary>
		/// This is a multiplier representing how infectious this virus is.
		/// </summary>
		public double Infectiousness
		{
			get;
			set;
		}

		/// <summary>
		/// This is a list of all of the conditions that a virus could possibly have.
		/// </summary>
		public List<Condition> PossibleConditions
		{
			get;
			private set;
		}

		/// <summary>
		/// Will get a condition from the list of conditions given the name.
		/// </summary>
		/// <param name="condition">the name of the condition to get</param>
		/// <returns></returns>
		public Condition GetConditionByName( string condition )
		{
			foreach( Condition cond in PossibleConditions )
			{
				if( cond.Name == condition )
				{
					return cond;
				}
			}
			return null;
		}
	}
}
