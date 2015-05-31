using UnityEngine;
using System.Collections;

namespace Runner.Engine
{
	public class MusicButtonController : GameplayPanelController 
	{
		[SerializeField]
		private UISprite background = null;
		[SerializeField]
		private UIButton button= null;

		private readonly string MusicOnName = "music";
		private readonly string MusicOffName = "music_off";

		void Start ()
		{
			if (background == null || background.Equals(null))
			{
				background = this.gameObject.GetComponent<UISprite> ();
			}
			
			if (button == null || button.Equals(null))
			{
				button = this.gameObject.GetComponent<UIButton> ();
			}
			
			SetMusicUIState (true);
		}

		public void SetMusicUIState (bool isMusic)
		{
			if (isMusic)
			{
				background.spriteName = MusicOnName;
				
				button.normalSprite = MusicOnName;
				button.hoverSprite = MusicOnName;
				button.pressedSprite = MusicOnName;
				button.disabledSprite = MusicOnName;
			} else 
			{
				background.spriteName = MusicOffName;
				
				button.normalSprite = MusicOffName;
				button.hoverSprite = MusicOffName;
				button.pressedSprite = MusicOffName;
				button.disabledSprite = MusicOffName;
			}
		}

		void OnClick ()
		{
			SetMusicUIState (false);

		}
	}
}
