using UnityEngine;
using System.Collections;

namespace Runner.Engine
{
	public class LevelPanelController : GameplayPanelController 
	{
		public enum SceneType
		{
			StartScene,
			SettingsScene,
			BonusScene,
			Level1Scene
		}
		public SceneType scene = SceneType.StartScene;

		override protected void Awake () 
		{
			base.Awake ();
			StartLevel ();
		}

		void Start ()
		{
			if (!manager.IsMenuScene)
				manager.Environment.StartLevel ();
		}

		private void StartLevel ()
		{
			switch (scene)
			{
			case SceneType.StartScene:
				manager.LoadLevel (GameConstants.StartMenu);
				break;
				
			case SceneType.SettingsScene:
				manager.LoadLevel (GameConstants.SettingsMenu);
				break;
				
			case SceneType.BonusScene:
				manager.LoadLevel (GameConstants.BonusMenu);
				break;
				
			case SceneType.Level1Scene:
				manager.LoadLevel (GameConstants.Level1);
				break;
			}
		}
	}
}
