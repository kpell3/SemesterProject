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

namespace GoingViral.Controls
{
	/// <summary>
	/// Interaction logic for MapInformationControl.xaml
	/// </summary>
	public partial class MapInformationControl : UserControl
	{
		/// <summary>
		/// The map data, contains location information
		/// </summary>
		public Map MapInfo
		{
			get;
			set;
		}

		public MapInformationControl()
		{
			InitializeComponent();
		}

		public void Button_MouseMove( object sender, MouseEventArgs e )
		{
			if( MapInfo != null )//Only process if map object is not null
			{
				string SenderName = ( sender as Button ).Name;
				SenderName = SenderName.Substring( 0, SenderName.IndexOf( "Button" ) );
				RegionNameBox.Text = SenderName;
				Update();
			}
		}
		public void Update()
		{
			if( MapInfo != null )//Only process if map object is not null
			{
				Location theLocation = MapInfo.GetLocationByName( RegionNameBox.Text );
				if( theLocation != null )
				{
					RegionNameBox.Text = theLocation.Name;
					PopulationBox.Text = ( theLocation.Population ).ToString();
					if( theLocation.InfectedHosts.Count > 0 )
					{
						InfectedPopulationBox.Text = ( theLocation.InfectedHosts.Count * theLocation.InfectedHosts[0].NumberOfPeopleRepresentedByThisHost ).ToString();
					}
					else
					{
						InfectedPopulationBox.Text = "0";
					}
					WaterInfectedBox.IsChecked = theLocation.WaterInfected;
					AirInfectedBox.IsChecked = theLocation.AirInfected;
					UnderQuarentineBox.IsChecked = theLocation.IsUnderQuarentine;
				}
				else
				{
					PopulationBox.Text = "0";
					InfectedPopulationBox.Text = "0";
					WaterInfectedBox.IsChecked = false;
					AirInfectedBox.IsChecked = false;
					UnderQuarentineBox.IsChecked = false;
				}
			}
		}
	}
}
