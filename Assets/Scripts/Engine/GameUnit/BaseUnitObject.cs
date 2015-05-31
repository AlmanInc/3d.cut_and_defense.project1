using UnityEngine;
using System.Collections;

namespace Runner.Engine
{
	abstract public class BaseUnitObject : PoolObject
	{
		protected GameManager manager = null;
		
		abstract public void Init ();
		
		abstract public void Activate ();
		
		abstract public void Deactivate ();
		
		void Awake ()
		{
			Init ();
		}
		
		void OnDestroy ()
		{
			manager = null;
		}
	}
}
