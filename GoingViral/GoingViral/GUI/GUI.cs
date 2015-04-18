using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoingViral.GUI
{
	/// <summary>
	/// This class keeps track of all of the window objects, making sure that
	/// they are handled properly, and can be accessed through here so only
	/// one instance is created.
	/// </summary>
	public class GUI
	{
		public GUI( GameMode mode )
		{
			mGameMode = mode;
			if( mGameMode == GameMode.RegularMode )
			{
			}
			else if( mGameMode == GameMode.SandboxMode )
			{

			}
		}
		public ModifyVirusWindow mModifyVirusWindow = new ModifyVirusWindow();
		public GameWindow mGameWindow = new GameWindow();
		GameMode mGameMode;
	}
}
