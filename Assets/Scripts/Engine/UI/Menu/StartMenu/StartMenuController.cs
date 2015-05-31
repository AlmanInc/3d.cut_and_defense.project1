using UnityEngine;
using System.Collections;

namespace Runner.Engine
{
	public class StartMenuController : GameplayPanelController 
	{
		public void PlayButtonClick ()
		{
			manager.LoadLevel (GameConstants.Level1);
		}
		
		public void SettingsButtonClick ()
		{
			manager.LoadLevel (GameConstants.SettingsMenu);
		}
		
		public void BonusButtonClick ()
		{

		}
	}
}
