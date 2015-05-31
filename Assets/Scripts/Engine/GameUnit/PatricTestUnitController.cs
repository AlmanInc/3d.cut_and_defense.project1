using UnityEngine;
using System.Collections;

namespace Runner.Engine
{
	public class PatricTestUnitController : BaseUnitObject
	{
		protected GameManager manager = null;

		override public void Init ()
		{
			if (manager == null || manager.Equals(null))
			{
				manager = GameManager.Instance;
			}

			this.gameObject.transform.localPosition = Vector3.forward * 10;
			this.gameObject.transform.localPosition += Vector3.left * Random.Range (-3.0f, 3.0f) + Vector3.up;
		}

		override public void Activate ()
		{
			this.gameObject.SetActive (true);
		}

		override public void Deactivate ()
		{
			this.gameObject.SetActive (false);
		}

		void Update ()
		{
			gameObject.transform.localPosition += Vector3.back * 1 * Time.deltaTime;
		}
	}
}
