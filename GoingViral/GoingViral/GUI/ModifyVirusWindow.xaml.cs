using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GoingViral.GUI
{
	/// <summary>
	/// Interaction logic for ModifyVirusWindow.xaml
	/// </summary>
	public partial class ModifyVirusWindow : Window
	{
		public ModifyVirusWindow()
		{
			InitializeComponent();
		}
		public void Populatebuttons()
		{
			if( theVirus != null )
			{
				for( int i = 0; i < VisualTreeHelper.GetChildrenCount( SymptomBoxGrid ); ++i )
				{
					Visual childVisual = (Visual)VisualTreeHelper.GetChild( SymptomBoxGrid, i );
					if( childVisual is Button )
					{
						Button thebutton = childVisual as Button;
						thebutton.Background = Brushes.DarkBlue;
						thebutton.Foreground = Brushes.Yellow;
						double index = Char.GetNumericValue( thebutton.Name[thebutton.Name.Length - 1] );
						string buttonsystem = thebutton.Name.Substring( 0, thebutton.Name.IndexOf( "Button" ) );
						foreach( Condition cond in theVirus.PossibleConditions )
						{
							string system = cond.System;
							if( system.Contains( "(" ) )
							{
								system = system.Substring( 0, system.IndexOf( "(" ) );
							}
							if( system == buttonsystem && index == 1 )
							{
								thebutton.Content = cond.Name;
								thebutton.ToolTip = cond.Tooltip;
								break;
							}
							else if( system == buttonsystem )
							{
								index--;
							}
						}
					}
				}
			}
		}

		public void Update()
		{
			//Update this window with values from the active virus
			IncubationPeriodBox.Text = theVirus.IncubationPeriod_Days.ToString();
			TimeToKillBox.Text = theVirus.TimeToKill.ToString();
			TimeToRecoverBox.Text = theVirus.TimeToRecover.ToString();
			TotalInfectiousnessBox.Text = theVirus.Infectiousness.ToString();
		}

		public ActiveVirus theVirus
		{
			get;
			set;
		}

		private void ConditionButton_Click( object sender, RoutedEventArgs e )
		{
			string senderName = ( sender as Button ).Content.ToString();
			Button senderButton = sender as Button;
			if( theVirus.HasCondition( senderName ) )
			{
				theVirus.RemoveCondition( theVirus.GetConditionByName( senderName ) );
				senderButton.Background = Brushes.DarkBlue;
				senderButton.Foreground = Brushes.Yellow;
			}
			else
			{
				theVirus.AddCondition( theVirus.GetConditionByName( senderName ) );
				senderButton.Background = Brushes.LawnGreen;
				senderButton.Foreground = Brushes.Black;
			}
			Update();
		}

		private void InfectivityBar_ValueChanged( object sender, RoutedPropertyChangedEventArgs<double> e )
		{
			if( theVirus != null )
			{
				theVirus.AdditionalInfectiousness = ( sender as Slider ).Value;
				theVirus.UpdateVirusInformation();
				Update();
			}
		}

		private void TimeUntilOnset_ValueChanged( object sender, RoutedPropertyChangedEventArgs<double> e )
		{
			if( theVirus != null )
			{
				theVirus.IncubationPeriod_Days = ( sender as Slider ).Value;
				Update();
			}
		}

		private void StartOfInfectiousness_ValueChanged( object sender, RoutedPropertyChangedEventArgs<double> e )
		{
			if( theVirus != null )
			{
				theVirus.StartOfInfectiousness_Day = ( sender as Slider ).Value;

				Update();
			}
		}

		private void BloodbourneButton_Click( object sender, RoutedEventArgs e )
		{
			theVirus.VirusTransmissionMethod = TransmissionMethod.Bloodbourne;
			TransmissionMethodBox.Text = "Bloodbourne";
		}

		private void SkinTransferButton_Click( object sender, RoutedEventArgs e )
		{
			theVirus.VirusTransmissionMethod = TransmissionMethod.SkinTransfer;
			TransmissionMethodBox.Text = "SkinTransfer";
		}

		private void WaterbourneButton_Click( object sender, RoutedEventArgs e )
		{
			theVirus.VirusTransmissionMethod = TransmissionMethod.Waterbourne;
			TransmissionMethodBox.Text = "Waterbourne";
		}

		private void AirbourneButton_Click( object sender, RoutedEventArgs e )
		{
			theVirus.VirusTransmissionMethod = TransmissionMethod.Airbourne;
			TransmissionMethodBox.Text = "Airbourne";
		}
	}
}
