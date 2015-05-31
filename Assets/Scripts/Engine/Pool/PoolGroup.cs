using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Runner.Engine
{
	public class PoolGroup 
	{
		private List<BasePool> poolList;
		
		public PoolGroup ()
		{
			poolList = new List<BasePool> ();
		}
		
		public void CreateNewItemInGroup (GameObject basePrefab)
		{
			poolList.Add (new BasePool ());
			poolList[poolList.Count-1].SetBasePoolPrefab (basePrefab);
		}

		public void PutObjectInGroupPool (PoolObject obj)
		{
			if (!obj.IsGroupObject || obj.GroupIndex < 0 || obj.GroupIndex >= poolList.Count)
			{
				Debug.Log ("[Class = PoolGroup, method = PutObjectInGroupPool] : Incorrect index or not group object.");
				return;
			}

			poolList[obj.GroupIndex].PutObjectInPool (obj);
		}

		public PoolObject GetAnyObjectFromGroupPool ()
		{
			int index = Random.Range(0, poolList.Count);
			
			PoolObject resultObject = poolList[index].GetObjectFromPool ();
			resultObject.IsGroupObject = true;
			resultObject.GroupIndex = index;

			return resultObject;
		}

		public void Clear ()
		{
			if (poolList != null && !poolList.Equals(null) && poolList.Count > 0)
			{
				for (int i = 0; i < poolList.Count; i++)
					poolList[i].Clear ();

				poolList.Clear ();
			}
		}
	}
}
