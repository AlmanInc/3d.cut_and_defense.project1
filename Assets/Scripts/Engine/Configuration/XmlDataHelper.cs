using UnityEngine;
using System.Collections;
using System.Xml;
using System.IO;

namespace Runner.Engine
{
	public class XmlDataHelper
	{
		public static bool Exists (string xmlFilePath)
		{
			return File.Exists (xmlFilePath);
		}

		public static XmlDocument LoadExistXmlDocument  (string XmlFilePath, string endsWith = ".xml")
		{
			XmlDocument xmlDocument = new XmlDocument ();
			
			if (XmlFilePath.EndsWith(endsWith))
			{
				xmlDocument.Load (XmlFilePath);
			} else
			{
				xmlDocument.Load (XmlFilePath+endsWith);
			}
			
			return xmlDocument;
		}

		public static XmlDocument GenerateAndLoadXmlDocument  (string XmlFilePath) 
		{
			TextAsset xmlAsset = Resources.Load (XmlFilePath) as TextAsset;
			
			if (xmlAsset == null || xmlAsset.Equals(null))
			{
				Debug.Log ("[Class = XmlDataHelper, method = GenerateAndLoadXmlDocument] : Couldn't load xmlAsset.");
				return null;
			}
			
			XmlDocument xmlDocument = new XmlDocument ();
			xmlDocument.LoadXml (xmlAsset.text);
			
			return xmlDocument;
		}
		
		public static XmlNode FindUniqueTag (XmlDocument document, string tagName)
		{
			XmlNodeList xmlTagList = document.GetElementsByTagName(tagName);
			
			if (xmlTagList == null || xmlTagList.Equals(null) || xmlTagList.Count == 0)
			{
				Debug.Log ("[Class = XmlDataHelper, method = FindUniqueTag] : Tag was not founded.");
				return null;
			}
			
			if (xmlTagList.Count >= 2)
			{
				Debug.Log ("[Class = XmlDataHelper, method = FindUniqueTag] : Tag count > 1, not unique");
			}
			
			return xmlTagList [0];
		}

		public static XmlNode FindTagByUniqueAttributeValue (XmlDocument document, string tagName, string attributeName, string attributeValue, bool fast = false)
		{
			XmlNodeList xmlTagList = document.GetElementsByTagName(tagName);

			if (xmlTagList == null || xmlTagList.Equals(null))
			{
				Debug.Log ("[Class = XmlDataHelper, method = FindTagByUniqueAttributeValue] : Tag was not founded.");
				return null;
			}

			return FindTagByUniqueAttributeValueInList (xmlTagList, tagName, attributeName, attributeValue, fast);
		}

		public static XmlNode FindUniqueTagInChild (XmlNode parentNode, string tagName, bool fast = false)
		{
			var childList = parentNode.ChildNodes;

			return FindUniqueTagInList (childList, tagName, fast);
		}

		public static XmlNode FindTagByUniqueAttributeValueInChild (XmlNode parentNode, string tagName, string attributeName, string attributeValue, bool fast = false)
		{
			var childList = parentNode.ChildNodes;
			
			return FindTagByUniqueAttributeValueInList (childList, tagName, attributeName, attributeValue, fast);
		}

		private static XmlNode FindUniqueTagInList (XmlNodeList xmlNodeList, string tagName, bool fast = false)
		{
			XmlNode targetNode = null;
			bool isItemWasFounded = false;
			
			foreach (XmlNode itemNode in xmlNodeList)
			{
				if (itemNode.Name.Equals(tagName))
				{
					if (isItemWasFounded)
					{
						Debug.Log ("[Class = XmlDataHelper, method = FindUniqueTagInList] : Tag is not unique.");
						break;
					} else 
					{
						targetNode = itemNode;
						
						if (fast)
							break;
						
						isItemWasFounded = true;
					}
				}
			}
			
			if (targetNode == null || targetNode.Equals(null))
			{
				Debug.Log ("[Class = XmlDataHelper, method = FindUniqueTagInList] : Tag value was not founded.");
				return null;
			}
			
			return targetNode;
		}
		
		private static XmlNode FindTagByUniqueAttributeValueInList (XmlNodeList xmlNodeList, string tagName, string attributeName, string attributeValue, bool fast = false)
		{
			XmlNode targetNode = null;
			bool isItemWasFounded = false;

			foreach (XmlNode itemNode in xmlNodeList)
			{
				if (itemNode.Attributes[attributeName].Value.Equals(attributeValue))
				{
					if (isItemWasFounded)
					{
						Debug.Log ("[Class = XmlDataHelper, method = FindTagByUniqueAttributeValueInList] : Tag value is not unique.");
						break;
					} else 
					{
						targetNode = itemNode;
						
						if (fast)
							break;
						
						isItemWasFounded = true;
					}
				}
			}
			
			if (targetNode == null || targetNode.Equals(null))
			{
				Debug.Log ("[Class = XmlDataHelper, method = FindTagByUniqueAttributeValueInList] : Tag value was not founded.");
				return null;
			}
			
			return targetNode;
		}
	}
}
