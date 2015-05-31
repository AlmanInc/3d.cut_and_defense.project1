using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.IO;

namespace Runner.Engine
{
	public class AudioInformation
	{
		//private XmlDataHelper xmlDataHelper;

		private List<string> menuMusic = null;
		public List<string> MenuMusic
		{
			get { return menuMusic; }
		}

		private List<string> levelMusic = null;
		public List<string> LevelMusic
		{
			get { return levelMusic; }
		}

		private float trackDelay = 0;
		public float TrackDelay
		{
			get { return trackDelay; }
		}

		
		public AudioInformation ()
		{
			//xmlDataHelper = new XmlDataHelper ();
			
			menuMusic = new List<string> ();
			levelMusic = new List<string> ();
		}
		
		public void LoadMenuInformation ()
		{
			XmlDocument xmlDocement = XmlDataHelper.GenerateAndLoadXmlDocument (GameConstants.PathAudioInformation);

			XmlNode targetNode = XmlDataHelper.FindUniqueTag (xmlDocement, "Menu");
			if (targetNode == null || targetNode.Equals(null))
			{
				Debug.Log ("[Class = AudioInformation, method = LoadMenuInformation] : Couldn't find target tag.");
				return;
			}

			LoadInformation (targetNode, menuMusic);
		}
		
		public void LoadLevelInformation (string levelName)
		{
			XmlDocument xmlDocement = XmlDataHelper.GenerateAndLoadXmlDocument (GameConstants.PathAudioInformation);
			
			XmlNode targetNode = XmlDataHelper.FindTagByUniqueAttributeValue (xmlDocement, "Level", "Name", levelName, true);
			if (targetNode == null || targetNode.Equals(null))
			{
				Debug.Log ("[Class = AudioInformation, method = LoadLevelInformation] : Couldn't find target tag.");
				return;
			}

			LoadInformation (targetNode, levelMusic);
		}

		private void LoadInformation (XmlNode targetNode, List<string> nameList)
		{
			if (nameList.Count > 0)
				nameList.Clear ();

			XmlNode musicNode = XmlDataHelper.FindUniqueTagInChild (targetNode, "Music", true);
			XmlNode soundNode = XmlDataHelper.FindUniqueTagInChild (targetNode, "Sound", true);
			
			if (musicNode != null && !musicNode.Equals(null))
			{
				XmlNode tracks = XmlDataHelper.FindUniqueTagInChild (musicNode, "Tracks", true);
				if (tracks == null || tracks.Equals(null))
				{
					Debug.Log ("[Class = AudioInformation, method = LoadInformation] : Not correct music tag format Track tag not founded.");
					return;
				}
				
				trackDelay = float.Parse (musicNode.Attributes["delayForNext"].Value);

				string strMusicPath = musicNode.Attributes["basePath"].Value;
				int tracksCount = int.Parse(tracks.Attributes["count"].Value);
				for (int i = 1; i <= tracksCount; i++)
					nameList.Add (strMusicPath + tracks.Attributes["track"+i].Value);
			}

			if (soundNode != null && !soundNode.Equals(null))
			{

			}

		}
	}
}
