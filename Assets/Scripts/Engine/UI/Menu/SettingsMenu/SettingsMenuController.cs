using UnityEngine;
using System.Collections;

namespace Runner.Engine
{
	public class SettingsMenuController : GameplayPanelController
	{
		public void BackButtonClick ()
		{
			manager.LoadLevel (GameConstants.StartMenu);
		}
	}
}
