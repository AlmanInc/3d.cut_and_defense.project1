using UnityEngine;
using System.Collections;

namespace Runner.Engine
{
	public class GameMath 
	{
		public static bool IsChance (int percent)
		{
			if (percent >= Random.Range(1, 101))
				return true;
			else
				return false;
		}

		public static float PartOf (float value, float percent)
		{
			return percent * (value / 100f);
		}
	}
}
