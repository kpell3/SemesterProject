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
		public GUI( Engine theengine)
		{
			mGameWindow.ModifyVirusButton.Click += ModifyVirusButton_Click;
			mGameWindow.PauseButton.Click += PauseButton_Click;
			mGameWindow.Closing += Exit;
			mModifyVirusWindow.Closing += HideModifyVirusWindow;
			TheEngine = theengine;
		}

		void PauseButton_Click( object sender, RoutedEventArgs e )
		{
			TheEngine.PauseSimulation = !TheEngine.PauseSimulation;
			if( TheEngine.PauseSimulation )
			{
				mGameWindow.PauseButton.Content = "Unpause";
			}
			else
			{
				mGameWindow.PauseButton.Content = "Pause";
			}
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
		public void Update()
		{
			if( mGameWindow.Visibility == Visibility.Visible )
			{
				mGameWindow.Update( TheEngine );
			}
		}

		void ModifyVirusButton_Click( object sender, RoutedEventArgs e )
		{
			mModifyVirusWindow.Show();
			mModifyVirusWindow.Update();
		}

		public GameWindow mGameWindow = new GameWindow();
		public ModifyVirusWindow mModifyVirusWindow = new ModifyVirusWindow();
		public Engine TheEngine;

		GameMode mGameMode;
	}
}
