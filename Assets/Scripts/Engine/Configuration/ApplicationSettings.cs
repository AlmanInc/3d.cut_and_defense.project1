using UnityEngine;
using System.Collections;
using System.Xml;
using System.IO;

namespace Runner.Engine
{
	public class ApplicationSettings
	{
		private XmlDocument xmlDocument;

		private bool isMusic;
		private bool isSound;

		public ApplicationSettings ()
		{
			var defaultSettingsDirectory = GameConstants.PathDefaultApplicationSettings;
			var currentSettingsDirectory = Application.persistentDataPath + "/" + GameConstants.FileApplicationSettings;

			if (!File.Exists(currentSettingsDirectory))
			{
				LoadInformation (defaultSettingsDirectory);
				SaveInformation (currentSettingsDirectory);
			} else
			{
				LoadInformation (currentSettingsDirectory, true);
			}
		}

		public void LoadInformation (string dataPath, bool fileExists = false)
		{
			if (fileExists)
			{
				xmlDocument = XmlDataHelper.LoadExistXmlDocument(dataPath);
			} else
			{
				xmlDocument = XmlDataHelper.GenerateAndLoadXmlDocument (dataPath);
			}
			
			XmlNode targetNode = XmlDataHelper.FindUniqueTag (xmlDocument, "Application");
			
			XmlNode itemNode = XmlDataHelper.FindUniqueTagInChild (targetNode, "Music", true);
			isMusic = bool.Parse (itemNode.InnerText);
			itemNode = XmlDataHelper.FindUniqueTagInChild (targetNode, "Sound", true);
			isSound = bool.Parse (itemNode.InnerText);
		}

		public void SaveInformation (string dataPath)
		{
			XmlDocument targetDocument = new XmlDocument ();
			
			XmlNode rootNode = targetDocument.CreateElement ("Application");
			rootNode.RemoveAll ();
			targetDocument.AppendChild (rootNode);
			
			XmlElement itemNode = targetDocument.CreateElement ("Music");
			itemNode.InnerText = isMusic.ToString ();
			rootNode.AppendChild (itemNode);
			
			itemNode = targetDocument.CreateElement ("Sound");
			itemNode.InnerText = isSound.ToString ();
			rootNode.AppendChild (itemNode);
			
			targetDocument.Save (dataPath);
			return;
		}
	}
}
