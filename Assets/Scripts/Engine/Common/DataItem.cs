using UnityEngine;
using System.Collections;

namespace Runner.Engine
{
	public class DataItem
	{
		private bool isOnlyPositive;
		
		public DataItem (bool onlyPositive = false) 
		{
			isOnlyPositive = onlyPositive;
		}
		
		private float minValue = 0;
		public float MinValue
		{
			get { return minValue; }
			set { 
				minValue = value;
				if (isOnlyPositive && minValue < 0)
				{
					minValue = 0;
				}
			}
		}
		
		private float maxValue = 0;
		public float MaxValue
		{
			get { return maxValue; }
			set {
				maxValue = value;
				if (isOnlyPositive && maxValue < 0)
				{
					minValue = 0;
					maxValue = 0;
				}
			}
		}
		
		public float RandomFloatValue
		{
			get { return Random.Range(minValue, maxValue); }
		}
		
		public int RandomIntValue
		{
			get { return Random.Range((int)minValue, (int)maxValue+1); }
		}
	}
}
