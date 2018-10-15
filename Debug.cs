
/**
 * Debug.cs
 * Debugging related snippets for MonoGame
 */

/* using */
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


/* -----------------------------------------
   Retrieve FPS
----------------------------------------- */
// Constructor:
double framerate = 60;

// LoadContent():
SpriteBatch spriteBatch = new SpriteBatch(graphics.GraphicsDevice);

SpriteFont arial = Content.Load<SpriteFont>("Graphics\\Arial"); // load Arial font as SpriteFont from ./<Content>/Graphics/ folder

// Draw():
spriteBatch.Begin();
spriteBatch.DrawString(arial, "FPS "+framerate.ToString(), new Vector2(5, 5), Color.White); // draw fps Text at 2D position [5, 5]
spriteBatch.End();

/// ...

// get framerate for this frame, place at the end, right before base.Draw(gameTime);
framerate = Math.Round(1 / gameTime.ElapsedGameTime.TotalSeconds);

