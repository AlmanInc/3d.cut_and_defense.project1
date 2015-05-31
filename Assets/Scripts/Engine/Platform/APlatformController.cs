using UnityEngine;
using System.Collections;

namespace Runner.Engine
{
	public enum PlatformType
	{
		BasePlatform,
		SpecialPlatform,
		TerrainPlatform
	}

	abstract public class APlatformController : PoolObject
	{
		public PlatformType platformType = PlatformType.BasePlatform;
		protected GameManager manager = null;
		protected PlatformData data = null;
		private Vector3 toPlayerVector;

		protected float width = 0;
		public float Width
		{
			get { return width; }
		}

		protected float height = 0;
		public float Height
		{
			get { return height; }
		}

		protected float length = 0;
		public float Length
		{
			get { return length; }
		}

		abstract public void InitPlatform ();

		abstract public void DestroyPlatform ();

		abstract public void PreActivationProcess ();

		abstract public void ActivatePlatform ();

		abstract public void DeactivatePlatform ();

		void Awake ()
		{
			InitPlatform ();
		}

		void OnDestroy ()
		{
			DestroyPlatform ();
		}
	}
}
