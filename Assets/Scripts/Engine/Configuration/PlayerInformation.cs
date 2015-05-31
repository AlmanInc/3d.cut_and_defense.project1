using UnityEngine;
using System.Collections;
using System.Xml;

namespace Runner.Engine
{
	public class PlayerInformation : MonoBehaviour 
	{
		private float speed;
		public float Speed
		{
			get { return speed; }
		}

		private float jumpSpeed;
		public float JumpSpeed
		{
			get { return jumpSpeed; }
		}

		private float jumpHeight;
		public float JumpHeight
		{
			get { return jumpHeight; }
		}

		public PlayerInformation ()
		{
			XmlDocument xmlDocument = XmlDataHelper.GenerateAndLoadXmlDocument (GameConstants.PathPlayerInformation);
			XmlNode nodePlayer = XmlDataHelper.FindTagByUniqueAttributeValue (xmlDocument, "Unit", "Name", "Gerda", true);
			
			XmlNode moveNode = XmlDataHelper.FindUniqueTagInChild (nodePlayer, "MoveToSide", true);
			speed = float.Parse (moveNode.Attributes["Speed"].Value);
			
			XmlNode jumpNode = XmlDataHelper.FindUniqueTagInChild (nodePlayer, "Jump", true);
			jumpSpeed = float.Parse (jumpNode.Attributes["Speed"].Value);
			jumpHeight = float.Parse (jumpNode.Attributes["Height"].Value);
		}
	}
}
