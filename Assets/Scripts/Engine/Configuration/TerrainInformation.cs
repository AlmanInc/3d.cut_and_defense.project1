using UnityEngine;
using System.Collections;
using System.Xml;
using System.IO;

namespace Runner.Engine
{
	public class TerrainInformation 
	{
		public PlatformData BasePlatformData = null;

		public TerrainInformation ()
		{
			BasePlatformData = new PlatformData ();
		}

		public void LoadInformation (string levelName)
		{
			XmlDocument xmlDocument = XmlDataHelper.GenerateAndLoadXmlDocument (GameConstants.PathTerrainInformation);
			
			XmlNode targetNode = XmlDataHelper.FindTagByUniqueAttributeValue (xmlDocument, "Level", "Name", levelName);
			
			var childList = targetNode.ChildNodes;
			foreach (XmlNode item in childList)
			{
				if (item.Name.Equals("BasePlatform"))
				{
					LoadPlatformInformation (item, BasePlatformData);
				}
			}
		}

		private void LoadPlatformInformation (XmlNode noteItem, PlatformData data)
		{
			var childList = noteItem.ChildNodes;
			foreach (XmlNode item in childList)
			{
				if (item.Name.Equals("Size"))
				{
					data.Width.MinValue = float.Parse (item.Attributes["minWidth"].Value);
					data.Width.MaxValue = float.Parse (item.Attributes["maxWidth"].Value);
					data.Length.MinValue = float.Parse (item.Attributes["minLength"].Value);
					data.Length.MaxValue = float.Parse (item.Attributes["maxLength"].Value);
					data.Height.MinValue = float.Parse (item.Attributes["minHeight"].Value);
					data.Height.MaxValue = float.Parse (item.Attributes["maxHeight"].Value);
				} else if (item.Name.Equals("DistanceTo"))
				{
					data.DistanceToLength.MinValue = float.Parse (item.Attributes["minLength"].Value);
					data.DistanceToLength.MaxValue = float.Parse (item.Attributes["maxLength"].Value);
					data.DistanceToWidth.MinValue = float.Parse (item.Attributes["minWidth"].Value);
					data.DistanceToWidth.MaxValue = float.Parse (item.Attributes["maxWidth"].Value);
					data.DistanceToHeight.MinValue = float.Parse (item.Attributes["minHeight"].Value);
					data.DistanceToHeight.MaxValue = float.Parse (item.Attributes["maxHeight"].Value);
				} else if (item.Name.Equals("DistanceNext"))
				{
					data.DistanceNextLength.MinValue = float.Parse (item.Attributes["minLength"].Value);
					data.DistanceNextLength.MaxValue = float.Parse (item.Attributes["maxLength"].Value);
					data.DistanceNextWidth.MinValue = float.Parse (item.Attributes["minWidth"].Value);
					data.DistanceNextWidth.MaxValue = float.Parse (item.Attributes["maxWidth"].Value);
					data.DistanceNextHeight.MinValue = float.Parse (item.Attributes["minHeight"].Value);
					data.DistanceNextHeight.MaxValue = float.Parse (item.Attributes["maxHeight"].Value);
				}
			}
		}
	}
}
