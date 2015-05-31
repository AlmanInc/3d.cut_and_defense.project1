using UnityEngine;
using System.Collections;

namespace Runner.Engine
{
	public class BasePlatformController : APlatformController 
	{
		override public void InitPlatform ()
		{
			if (manager == null || manager.Equals(null))
				manager = GameManager.Instance;
				
			data = manager.Settings.PlatformsData.BasePlatformData;
		}
		
		override public void DestroyPlatform ()
		{
			if (manager != null && !manager.Equals(null))
				manager = null;
		}

		override public void PreActivationProcess ()
		{
			float newWidth = data.Width.RandomIntValue;
			float newLength = data.Length.RandomFloatValue;
			float newHeight = data.Height.RandomFloatValue;
			Vector3 platformSize = new Vector3 (newWidth, newHeight, newLength);
			this.gameObject.transform.localScale = platformSize;

			width = this.gameObject.renderer.bounds.size.x;
			height = this.gameObject.renderer.bounds.size.y;
			length = this.gameObject.renderer.bounds.size.z;
		}
		
		override public void ActivatePlatform ()
		{
			//this.gameObject.SetActive (true);
		}
		
		override public void DeactivatePlatform ()
		{
			//this.gameObject.SetActive (false);
			//manager.Environment.ReturnPlatformToPool (this);
		}

		void Update ()
		{
			return;

			//gameObject.transform.localPosition -= manager.Player.transform.forward * 36 * Time.deltaTime;

			var r = this.gameObject.GetComponent<Rigidbody>();
			r.velocity = -manager.Player.transform.forward * 36;

			//if (IsPlatformBehindPlayer())
			//	DeactivatePlatform ();
		}

	}
}