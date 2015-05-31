using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Runner.Engine
{
	public class SoundManager : MonoBehaviour 
	{
		private enum AudioManagerState
		{
			Default,
			Menu,
			Level
		}
		private AudioManagerState musicState = AudioManagerState.Default;

		private GameManager manager;
		private AudioInformation information;

		private List<AudioClip> menuMusic = null;
		private List<AudioClip> levelMusic = null;

		private AudioSource musicSource = null;

		private bool musicOut = false;
		private int index = -1;

		void Awake ()
		{
			manager = GameManager.Instance;
			information = manager.Settings.AudioInf;

			musicSource = gameObject.AddComponent<AudioSource> ();
			
			menuMusic = new List<AudioClip> ();
			levelMusic = new List<AudioClip> ();
			
			StartCoroutine ("MusicUpdate");
		}

		public void LoadScene (string sceneName)
		{
			if (manager.IsMenuScene && musicState != AudioManagerState.Menu)
			{
				if (musicState == AudioManagerState.Level)
				{
					musicOut = true;
					StopCoroutine ("MusicUpdate");
					StartCoroutine ("MusicUpdate");
				}

				var menuMusicNames = information.MenuMusic;
				for (int i = 0; i < menuMusicNames.Count; i++)
				{
					menuMusic.Add (Resources.Load(menuMusicNames[i]) as AudioClip);
				}
				musicState = AudioManagerState.Menu;
			} else if (!manager.IsMenuScene && musicState != AudioManagerState.Level)
			{
				if (musicState == AudioManagerState.Menu)
				{
					musicOut = true;
					StopCoroutine ("MusicUpdate");
					StartCoroutine ("MusicUpdate");
				}

				var levelMusicNames = information.LevelMusic;
				for (int i = 0; i < levelMusicNames.Count; i++)
				{
					levelMusic.Add (Resources.Load(levelMusicNames[i]) as AudioClip);
				}

				musicState = AudioManagerState.Level;
			}
		}

		private IEnumerator MusicUpdate ()
		{
			while (true)
			{
				if (musicState == AudioManagerState.Default)
					yield return null;

				if (musicOut)
				{
					musicSource.volume -= 1.0f * Time.deltaTime;
					if (musicSource.volume <= 0)
					{
						musicSource.volume = 0;
						musicOut = false;

						index = -1;
					}

					yield return null;
				}

				if (musicState == AudioManagerState.Menu && index < 0 && !musicOut)
				{
					musicSource.volume = 1;

					index = Random.Range (0, menuMusic.Count);
					musicSource.clip = menuMusic[index];
					musicSource.Play ();
					
					yield return new WaitForSeconds (menuMusic[index].length + information.TrackDelay);
					
					index = -1;
				}

				if (musicState == AudioManagerState.Level && index < 0 && !musicOut)
				{
					musicSource.volume=1;

					index = Random.Range (0, levelMusic.Count);
					musicSource.clip = levelMusic[index];
					musicSource.Play ();
					
					yield return new WaitForSeconds (levelMusic[index].length + information.TrackDelay);
					
					index = -1;
				}

				yield return null;
			}
		}
	}
}
