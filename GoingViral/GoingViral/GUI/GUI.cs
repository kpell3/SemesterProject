using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.ComponentModel;

namespace GoingViral.GUI
{
	/// <summary>
	/// This class keeps track of all of the window objects, making sure that
	/// they are handled properly, and can be accessed through here so only
	/// one instance is created.
	/// </summary>
	public class GUI
	{
		public GUI()
		{
			mGameWindow.ModifyVirusButton.Click += ModifyVirusButton_Click;
			mGameWindow.Closing += Exit;
			mModifyVirusWindow.Closing += HideModifyVirusWindow;
		}

		private void HideModifyVirusWindow( object sender, CancelEventArgs e )
		{
			e.Cancel = true;
			mModifyVirusWindow.Hide();
		}
		void Exit( object sender, CancelEventArgs e )
		{
			try
			{
				mModifyVirusWindow.Closing -= HideModifyVirusWindow;
				mModifyVirusWindow.Close();
			}
			catch( Exception ex )
			{
				//well, we tried to close it.
			}
		}
		public void Update( Engine theEngine )
		{
			if( mGameWindow.Visibility == Visibility.Visible )
			{
				mGameWindow.Update( theEngine );
			}
			if( mModifyVirusWindow.Visibility == Visibility.Visible )
			{
				mModifyVirusWindow.Update( theEngine );
			}
		}

		void ModifyVirusButton_Click( object sender, RoutedEventArgs e )
		{
			mModifyVirusWindow.Show();
		}

		public GameWindow mGameWindow = new GameWindow();
		public ModifyVirusWindow mModifyVirusWindow = new ModifyVirusWindow();

		GameMode mGameMode;
	}
}
