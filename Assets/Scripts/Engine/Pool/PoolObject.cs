using UnityEngine;
using System.Collections;

namespace Runner.Engine
{
	public class PoolObject : MonoBehaviour 
	{
		[SerializeField]
		private bool isGroupObject = false;
		public bool IsGroupObject
		{
			get { return isGroupObject; }
			set { isGroupObject = value; }
		}
		
		[SerializeField]
		private int groupIndex = 0;
		public int GroupIndex
		{
			get { return groupIndex; }
			set { groupIndex = (value >= 0) ? value : 0; }
		}
	}
}
