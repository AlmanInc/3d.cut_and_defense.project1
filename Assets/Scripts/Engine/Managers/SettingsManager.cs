using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Runner.Engine
{
	public class SettingsManager 
	{
		private GameManager manager = null;

		private AudioInformation audioInformation = null;
		public AudioInformation AudioInf
		{
			get { return audioInformation; }
		}

		private CameraInformation cameraInformation = null;
		public CameraInformation CameraData
		{
			get { return cameraInformation; }
		}

		private TerrainInformation terrainInformation = null;
		public TerrainInformation PlatformsData
		{
			get { return terrainInformation; }
		}
		
		public SettingsManager ()
		{
			manager = GameManager.Instance;

			audioInformation = new AudioInformation ();
			cameraInformation = new CameraInformation ();
			terrainInformation = new TerrainInformation ();

			ApplicationSettings aap = new ApplicationSettings ();
		}

		public void LoadScene (string sceneName)
		{
			if (manager.IsMenuScene)
			{
				audioInformation.LoadMenuInformation ();
			} else
			{
				audioInformation.LoadLevelInformation (sceneName);
				terrainInformation.LoadInformation (sceneName);
			}
		}
	}
}
