using UnityEngine;
using System.Collections;

namespace Runner.Engine
{
	public class PlayerMovementController : MonoBehaviour 
	{
		private GameManager manager;

		private enum MoveState
		{
			DefaultState,
			MoveLeft,
			MoveRight
		}
		private MoveState moveState = MoveState.DefaultState;

		private Rigidbody rigidbodyController;
		private Transform playerTransform;
		private Vector3 playerPosition;

		void Awake ()
		{
			if (manager == null || manager.Equals(null))
				manager = GameManager.Instance;

			manager.Player = this.gameObject;

			rigidbodyController = this.gameObject.GetComponent<Rigidbody> ();
			playerTransform = this.gameObject.transform;
			playerPosition = playerTransform.localPosition;
		}

		void Update ()
		{
			InputController ();

			//rigidbodyController.MovePosition (targetPoint);
		}

		private void InputController ()
		{
#if UNITY_EDITOR
			if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.A))
				;

			if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.D))
				;

			if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.W))
				;
#elif UNITY_ANDROID

#endif
		}

	}
}
