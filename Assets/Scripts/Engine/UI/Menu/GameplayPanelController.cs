using UnityEngine;
using System.Collections;

namespace Runner.Engine
{
	public class GameplayPanelController : MonoBehaviour 
	{
		protected GameManager manager = null;
		
		protected  virtual void Awake ()
		{
			if (manager == null || manager.Equals(null))
				manager = GameManager.Instance;
		}

		void OnDestroy ()
		{
			manager = null;
		}
	}
}
