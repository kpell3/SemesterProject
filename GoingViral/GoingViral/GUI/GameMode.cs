using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoingViral.GUI
{
	public enum GameMode
	{
		/// <summary>
		/// Indicates that the game will be played in sandbox mode with infinite DNA
		/// </summary>
		SandboxMode,

		/// <summary>
		/// Indicates that the game will be played in regular mode, with DNA points
		/// awarded for infecting more people.
		/// </summary>
		RegularMode
	}
}
