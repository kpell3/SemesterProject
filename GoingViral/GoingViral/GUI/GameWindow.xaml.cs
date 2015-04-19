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
	/// Interaction logic for GameWindow.xaml
	/// </summary>
	public partial class GameWindow : Window
	{
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="startingDNA">The amount of DNA the player starts with. -1 is infinite</param>
		public GameWindow()
		{
			InitializeComponent();
		}

		private void ModifyVirusButton_Click( object sender, RoutedEventArgs e )
		{
			//This click action is handled in the GUI class. nothing happens here.
		}
		public void Update( Engine theEngine )
		{
			//Update the window with values from the engine.
		}
	}
}
