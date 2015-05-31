using UnityEngine;
using System.Collections;

namespace Runner.Engine
{
	public class UILayerController : MonoBehaviour
	{
		public enum UIObjectType
		{
			UIPanelObject,
			ParticleSystemObject
		}
		[SerializeField]
		private UIObjectType objectType = UIObjectType.UIPanelObject;
		[SerializeField]
		private int sortingOrder = 0;

		void Start () 
		{
			if (objectType == UIObjectType.UIPanelObject)
			{
				var panel = this.gameObject.GetComponent<UIPanel> ();
				panel.sortingOrder = sortingOrder;
			} else 
			{
				var particleSystem = this.gameObject.GetComponent<ParticleSystem> ();
				particleSystem.renderer.sortingOrder = sortingOrder;
			}
		}
	}
}
