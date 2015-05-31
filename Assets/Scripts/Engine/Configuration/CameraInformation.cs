using UnityEngine;
using System.Collections;
using System.Xml;

namespace Runner.Engine
{
	public class CameraInformation
	{
		private Vector3 position = Vector3.zero;
		public Vector3 Position
		{
			get { return position; }
		}

		private Vector3 rotation = Vector3.zero;
		public Vector3 Rotation
		{
			get { return rotation; }
		}

		private float dxScale = 1;
		public float DXScale
		{
			get { return dxScale; }
		}

		public CameraInformation ()
		{
			XmlDocument xmlDocument = XmlDataHelper.GenerateAndLoadXmlDocument (GameConstants.PathCameraInformation);

			XmlNode nodeCamera = XmlDataHelper.FindUniqueTag (xmlDocument, "Camera");
			XmlNode targetNode = null;
			float dx = 0;
			float dy = 0;
			float dz = 0;
			float rx = 0;
			float ry = 0;
			float rz = 0;

			switch (nodeCamera.Attributes["InGameCameraMode"].Value)
			{
			case "Classic":
				targetNode = XmlDataHelper.FindUniqueTagInChild (nodeCamera, "Classic", true);
				break;
			}

			dx = float.Parse (targetNode.Attributes["dx"].Value);
			dy = float.Parse (targetNode.Attributes["dy"].Value);
			dz = float.Parse (targetNode.Attributes["dz"].Value);
			position = new Vector3 (dx, dy, dz);

			rx = float.Parse (targetNode.Attributes["rotationX"].Value);
			ry = float.Parse (targetNode.Attributes["rotationY"].Value);
			rz = float.Parse (targetNode.Attributes["rotationZ"].Value);
			rotation = new Vector3 (rx, ry, rz);

			dxScale = float.Parse (targetNode.Attributes["dxScale"].Value);
		}
	}
}
