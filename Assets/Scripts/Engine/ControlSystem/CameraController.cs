using UnityEngine;
using System.Collections;

namespace Runner.Engine
{
	public class CameraController : MonoBehaviour 
	{
		private Vector3 deltaPosition;
		private Vector3 deltaRotation;
		private Vector3 scalePositionVector;
		private Transform playerTransform;
		private Transform cameraTransform;

		private Vector3 currentPosition;
		private Quaternion currentRotation;
		
		private float dxScale;

		void Start ()
		{
			var manager = GameManager.Instance;

			deltaPosition = manager.Settings.CameraData.Position;
			deltaRotation = manager.Settings.CameraData.Rotation;
			scalePositionVector = new Vector3 (manager.Settings.CameraData.DXScale, 1, 1);
			playerTransform = manager.Player.transform;
			cameraTransform = this.gameObject.transform;
			
			UpdateCamera ();
		}
		
		void LateUpdate ()
		{
			UpdateCamera ();
		}

		private void UpdateCamera ()
		{
			currentPosition = playerTransform.localPosition;
			currentPosition += playerTransform.forward * deltaPosition.z + playerTransform.up * deltaPosition.y + playerTransform.right * deltaPosition.x;
			currentPosition.Scale (scalePositionVector);

			cameraTransform.localPosition = currentPosition;
			
			currentRotation = playerTransform.localRotation;
			currentRotation.eulerAngles += deltaRotation;
			cameraTransform.localRotation = currentRotation;
		}
	}
}
