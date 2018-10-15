
/**
 * Video.cs
 * Video related snippets for MonoGame
 */

/* using */
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;


/* -----------------------------------------
   Play a Video file (Windows DX only)
----------------------------------------- */
// Constructor:
private VideoPlayer player;
private Video video;

// LoadContent():
SpriteBatch spriteBatch = new SpriteBatch(graphics.GraphicsDevice);

player = new VideoPlayer();
video  = Content.Load<Video>("Video/Opening"); // load Opening.mp4 as Video from ./<Content>/Video/ folder
player.IsLooped = false; // loop state
player.Volume = 1.0f; // audio volume
player.Play(video);

// Draw():
if (player.State != MediaState.Stopped) {
	// display video texture if not stopped
	spriteBatch.Begin();
	spriteBatch.Draw(player.GetTexture(), new Rectangle(0, 0, 1280, 720), Color.White);
	spriteBatch.End();
} else {
	// if stopped and exists, then dispose
	if (video != null) {
		video.Dispose();
		video = null;
	}
}


