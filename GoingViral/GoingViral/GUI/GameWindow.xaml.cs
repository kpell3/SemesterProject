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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GoingViral.GUI
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class GameWindow : Window
	{
		public GameWindow()
		{
			InitializeComponent();

			// setup the buttons within the canvas
			EnumControls( MapCanvas );
		}

		public void EnumControls( Visual myControl )
		{
			for( int i = 0; i < VisualTreeHelper.GetChildrenCount( myControl ); i++ )
			{
				// Retrieve child visual at specified index value.
				Visual childVisual = (Visual) VisualTreeHelper.GetChild( myControl, i );

				if( childVisual is Button )
				{
					( (Button) childVisual ).MouseEnter += HUD.Button_MouseMove;
				}

				// Enumerate children of the child visual object.
				EnumControls( childVisual );
			}
		}

		public void Update( bool pause, int DayNumber )
		{
			HUD.Update();
			for( int i = 0; i < VisualTreeHelper.GetChildrenCount( MapCanvas ); ++i )
			{
				Visual childVisual = (Visual) VisualTreeHelper.GetChild( MapCanvas, i );
				if( childVisual is Button )
				{
					UpdateButtonImage( childVisual as Button );
				}
			}

			if( pause )
			{
				PauseButton.Content = "Unpause";
			}
			else
			{
				PauseButton.Content = "Pause";
			}
			DayNumberLabel.Content = "Day " + DayNumber.ToString();
			//Update the window with values from the engine.
		}

		private void UpdateButtonImage( Button button )
		{
			Location loc = MapInfo.GetLocationByName( button.Name.Substring( 0, button.Name.IndexOf( "Button" ) ) );

			if( loc != null )
			{
				double InfectedPopulation = 0;
				if( loc.InfectedHosts.Count > 0 )
				{
					InfectedPopulation = loc.InfectedHosts.Count * loc.InfectedHosts[0].NumberOfPeopleRepresentedByThisHost;
				}
				Visual childVisual;
				for( int i = 0; i < VisualTreeHelper.GetChildrenCount( button ); ++i )
				{
					childVisual = (Visual) VisualTreeHelper.GetChild( button, i );
					if( childVisual is Image )
					{
						BitmapImage theImage = new BitmapImage();
						theImage.BeginInit();
						if( loc.Population <= 0 )
						{
							theImage.UriSource = new Uri( @"Images\skull_and_crossbones.jpg", UriKind.Relative );
						}
						else if( InfectedPopulation >= loc.Population )
						{
							theImage.UriSource = new Uri( @"Images\BiohazardRed.png", UriKind.Relative );
						}
						else if( InfectedPopulation >= ( loc.Population * 0.25 ) )
						{
							theImage.UriSource = new Uri( @"Images\BiohazardOrange.png", UriKind.Relative );
						}
						else if( InfectedPopulation >= ( loc.Population * 0.10 ) )
						{
							theImage.UriSource = new Uri( @"Images\Biohazard.png", UriKind.Relative );
						}
						else if( InfectedPopulation >= 1 )
						{
							theImage.UriSource = new Uri( @"Images\BiohazardGreen.png", UriKind.Relative );
						}
						else
						{
							theImage.UriSource = new Uri( @"Images\BiohazardClear.png", UriKind.Relative );
						}
						theImage.EndInit();
						( childVisual as Image ).Source = theImage;
					}
				}
			}
		}

		public Map MapInfo
		{
			get;
			set;
		}

		private void GameSpeedSlider_ValueChanged( object sender, RoutedPropertyChangedEventArgs<double> e )
		{

		}
	}
}
