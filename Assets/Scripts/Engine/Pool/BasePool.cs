using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Runner.Engine
{
	public class BasePool 
	{
		private GameObject basePrefab = null;
		private List<PoolObject> objectsList = null;
		
		public BasePool ()
		{
			objectsList = new List<PoolObject> ();
		}

		public void SetBasePoolPrefab (GameObject BasePrefab)
		{
			if (objectsList != null && !objectsList.Equals(null))
				objectsList.Clear ();
			
			if (basePrefab != null && !basePrefab.Equals(null))
				basePrefab = null;
			
			basePrefab = BasePrefab;
		}

		public void PutObjectInPool (PoolObject objectForPool) 
		{
			objectForPool.gameObject.SetActive (false);
			objectsList.Add (objectForPool);
		}
		
		public PoolObject GetObjectFromPool () 
		{
			PoolObject resultObject = null;
			
			if (objectsList.Count == 0) {
				resultObject = (GameObject.Instantiate (basePrefab) as GameObject).GetComponent<PoolObject> ();
				resultObject.gameObject.SetActive (false);
			} else {
				resultObject = objectsList[objectsList.Count-1];
				objectsList.RemoveAt(objectsList.Count-1);
			}
			
			return resultObject;
		}
				
		public void Clear ()
		{
			objectsList.Clear ();
		}
	}
}
