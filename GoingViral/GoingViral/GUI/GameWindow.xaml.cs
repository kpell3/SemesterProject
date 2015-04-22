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
			WestUSButton.MouseDown += HUD.Button_MouseMove;
			EastUSButton.MouseEnter += HUD.Button_MouseMove;
        }

		private void ModifyVirusButton_Click( object sender, RoutedEventArgs e )
		{

		}

		public void Update( Engine theEngine )
		{
			//Update the window with values from the engine.
		}

		private void RegionButton_Click( object sender, RoutedEventArgs e )
		{
			
		}
    }
}
