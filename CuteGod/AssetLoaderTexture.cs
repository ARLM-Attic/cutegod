using BooGame;
using BooGame.Video;
using MfGames.Sprite3;
using MfGames.Sprite3.BooGameBE;
using System;

namespace CuteGod
{
	/// <summary>
	/// Defers the loading of textures by the use of the AssetLoader
	/// class.
	/// </summary>
	public class AssetLoaderTexture
	: IAssetLoader
	{
		#region Constructors
		public AssetLoaderTexture(string path)
		{
			Filename = path;
		}
 		#endregion

		#region Properties
		private string key;
		private string filename;

		/// <summary>
		/// Sets the filename for this loader.
		/// </summary>
		public string Filename
		{
			set
			{
				// Strip out the information to get the key
				filename = value;
				key = value;
				key = key.Substring(key.LastIndexOf("/") + 1);
				key = key.Substring(0, key.IndexOf("."));
			}
		}
		#endregion

		#region Loading
		/// <summary>
		/// Implements the actual loading process.
		/// </summary>
		public void Load()
		{
            // Load the drawable using PhysFs
            Texture texture = Core.Backend.CreateTexture(filename);
            TextureDrawable drawable = new TextureDrawable(texture);

			// Set the drawable in the cache
			AssetLoader.Instance.Drawables[key] = drawable;
		}
		#endregion
	}
}
