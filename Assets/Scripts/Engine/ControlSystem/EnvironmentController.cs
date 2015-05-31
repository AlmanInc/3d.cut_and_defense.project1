using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Runner.Engine
{
	public class EnvironmentController
	{
		private GameManager manager = null;
		private TerrainInformation terrainData = null;

		private PoolGroup unitsPool;

		private Transform playerTransform;
		private Transform platformTransform;
		private Vector3 platformPosition;

		public EnvironmentController ()
		{
			if (manager == null || manager.Equals(null))
				manager = GameManager.Instance;
			
			terrainData = manager.Settings.PlatformsData;

			unitsPool = new PoolGroup ();
		}

		public void Clear ()
		{
			unitsPool.Clear ();
		}

		public void LoadLevel (string level)
		{
			switch (level)
			{
			case GameConstants.Level1:
				unitsPool.CreateNewItemInGroup (Resources.Load(GameConstants.PathPatricUnit) as GameObject);
				break;
			}
		}

		public void StartLevel ()
		{
			playerTransform = manager.Player.transform;

			AddNewItemToActivePlatforms ();
		}

		public void AddNewItemToActivePlatforms ()
		{
			BaseUnitObject newUnit = (unitsPool.GetAnyObjectFromGroupPool()).GetComponent<PatricTestUnitController>();

			newUnit.Init ();
			newUnit.Activate ();
		}

		public void DestroyGameUnitOrGroup (BaseUnitObject currentUnit)
		{
			unitsPool.PutObjectInGroupPool (currentUnit);

			// Need destroy, use EnvironmentAnalitics for adding object
			AddNewItemToActivePlatforms ();
		}

		public void EnvironmentAnalitics (float timeLeft)
		{
			AddNewItemToActivePlatforms ();
		}
	}
}
