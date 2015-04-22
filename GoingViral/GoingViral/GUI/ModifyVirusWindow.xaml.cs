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
						double index = Char.GetNumericValue(thebutton.Name[ thebutton.Name.Length - 1 ]);
						string buttonsystem = thebutton.Name.Substring(0,thebutton.Name.IndexOf("Button"));
						foreach( Condition cond in theVirus.PossibleConditions )
						{
							string system = cond.System;
							if( system.Contains("(") )
							{
								system = system.Substring( 0, system.IndexOf("("));
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
		public void Update( Engine theEngine )
		{
			//Update this window with values from the engine
		}
		public ActiveVirus theVirus
		{
			get;
			set;
		}
	}
}
