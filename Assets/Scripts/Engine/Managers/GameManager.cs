using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Runner.Engine;

namespace Runner.Engine
{
	public class GameManager : MonoSingleton<GameManager> 
	{
		private string currentLevel = null;
		public string CurrentLevel
		{
			get { return currentLevel; }
			set { currentLevel = value; }
		}

		public bool IsMenuScene
		{
			get 
			{
				if (currentLevel == null || currentLevel.Equals(null))
				{
					Debug.Log ("[Class = GameManager, field = IsMenuScene] : CurrentLevel = null.");
					return false;
				}

				if (currentLevel.Equals(GameConstants.Level1))
					return false;
				else
					return true;
			}
		}

		private SettingsManager settingsManager = null;
		public SettingsManager Settings
		{
			get { return settingsManager; }
			set { settingsManager = value; }
		}
		
		public GameObject Player;
					
		public SoundManager audioManager = null;
		public SoundManager AudioManager
		{
			get { return audioManager; }
		}

		private EnvironmentController environment = null;
		public EnvironmentController Environment
		{
			get { return environment; }
		}

		protected override void Init ()
		{
			settingsManager = new SettingsManager ();
			
			if (audioManager == null || audioManager.Equals(null))
				audioManager = this.gameObject.AddComponent <SoundManager> ();
			
			environment = new EnvironmentController ();
			
			DontDestroyOnLoad (this);
		}

		public void LoadLevel (string levelName)
		{
			if (currentLevel != null && !currentLevel.Equals(null) && currentLevel.Equals(levelName))
				return;

			bool needChangeScene = true;
			if (currentLevel == null || currentLevel.Equals(null))
				needChangeScene = false;

			currentLevel = levelName;

			Settings.LoadScene (levelName);
			audioManager.LoadScene (levelName);

			if (!IsMenuScene)
			{
				environment.Clear ();
				environment.LoadLevel (levelName);
			}

			if (needChangeScene)
				Application.LoadLevel (levelName);
		}
	}
}
