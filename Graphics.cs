
/**
 * Graphics.cs
 * Graphics Rendering related snippets for MonoGame
 */

/* using */
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


/* -----------------------------------------
   Setup Graphics Device
----------------------------------------- */
// Constructor:
Game game = this;
GraphicsDeviceManager graphics = new GraphicsDeviceManager(game); // create new renderer

// Initialize():
graphics.PreferredBackBufferWidth       = 1280; // set backbuffer &window width
graphics.PreferredBackBufferHeight      = 720; // set backbuffer & window height
graphics.IsFullScreen                   = false; // enable fullscreen mode 
graphics.SynchronizeWithVerticalRetrace = true; // enable VSync
graphics.HardwareModeSwitch             = true; // hardware or software mode

// if fullscreen, set borderless & adapt backbuffer to display size instead
if (graphics.IsFullScreen) {
	graphics.IsBorderless              = true;
	graphics.PreferredBackBufferWidth  = graphics.GraphicsDevice.Adapter.CurrentDisplayMode.Width;
	graphics.PreferredBackBufferHeight = graphics.GraphicsDevice.Adapter.CurrentDisplayMode.Height;
}

// define orientation for mobile screens only
#if ANDROID || IOS || WINDOWS_PHONE
graphics.SupportedOrientations = DisplayOrientation.LandscapeLeft | DisplayOrientation.LandscapeRight;
#endif

graphics.GraphicsDevice.Viewport = new Viewport(0, 0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight); // create a main viewport
graphics.ApplyChanges(); // apply settings and initialize renderer, always use at the end of setup


/* -----------------------------------------
   Draw Sprite at X,Y
----------------------------------------- */
// LoadContent():
SpriteBatch spriteBatch = new SpriteBatch(graphics.GraphicsDevice);

Texture2D tex = Content.Load<Texture2D>("Graphics\\Dummy"); // load Dummy.png as Texture2D from ./<Content>/Graphics/ folder

// Draw():
spriteBatch.Begin(
	SpriteSortMode.Immediate, // SpriteSortMode.Immediate, SpriteSortMode.Deferred
	BlendState.AlphaBlend     // BlendState.Opaque, BlendState.AlphaBlend, BlendState.Additive
	SamplerState.LinearClamp,
	DepthStencilState.Default,
	RasterizerState.CullCounterClockwise
); // begin rendering the batch of sprites

// draw Sprite at 2D position [100, 100]
spriteBatch.Draw(tex, new Vector2(100, 100), Color.White);

// draw Sprite rotated at [200, 200]
spriteBatch.Draw(
	tex,                                        // texture to use 
	new Vector2(200, 200),                      // position X,Y 
	new Rectangle(0, 0, tex.Width, tex.Height), // source, part of the texture to draw
	Color.White,                                // tint color
	20.0f,                                      // rotation angle 
	new Vector2(tex.Width / 2, tex.Height),     // origin, we center the point
	1.0f,                                       // scale factor
	SpriteEffects.None,                         // SpriteEffect.FlipHorizontally, SpriteEffect.FlipVertically
	1                                           // depth
);

spriteBatch.End(); // end the batch rendering, always put at the end


/* -----------------------------------------
   Draw Text at X,Y
----------------------------------------- */
// LoadContent():
SpriteBatch spriteBatch = new SpriteBatch(graphics.GraphicsDevice);

SpriteFont arial = Content.Load<SpriteFont>("Graphics\\Arial"); // load Arial font as SpriteFont from ./<Content>/Graphics/ folder

// Draw():
spriteBatch.Begin();
spriteBatch.DrawString(arial, "Test", new Vector2(300, 100), Color.White); // draw Text at 2D position [300, 100]
spriteBatch.End();


/* -----------------------------------------
   Draw Sprite at X,Y with Shader FX
----------------------------------------- */
// Constructor:
private List<Effect> shaderEffects = new List<Effect>();

// LoadContent():
SpriteBatch spriteBatch = new SpriteBatch(graphics.GraphicsDevice);

Texture2D tex = Content.Load<Texture2D>("Graphics\\Dummy"); // load Dummy.png as Texture2D from ./<Content>/Graphics/ folder

shaderEffects.Add( Content.Load<Effect>("Shaders\\Grayscale") ); // load Grayscale.fx as Effect from ./<Content>/Shaders/ folder
shaderEffects[0].Parameters["ViewportSize"].SetValue(new Vector2(1280, 720)); // set Uniform in shader (vec2)

// Draw():
spriteBatch.Begin(
	SpriteSortMode.Deferred,                                         
	BlendState.NonPremultiplied,                      
	SamplerState.PointClamp, 
	DepthStencilState.Default,                                
	RasterizerState.CullNone,                                        
	shaderEffects[0] // draw SpriteBatch using Grayscale shader effect, first in our shaderEffects list
);

// draw Sprite at 2D position [100, 100]
spriteBatch.Draw(tex, new Vector2(100, 100), Color.White);
spriteBatch.End();


/* -----------------------------------------
   Create a Render Target
----------------------------------------- */
// Initialize():
RenderTarget2D renderTarget = new RenderTarget2D(graphics.GraphicsDevice, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight); // create new surface

// Draw():
graphics.GraphicsDevice.SetRenderTarget(renderTarget); // set the target surface for drawing operations
spriteBatch.GraphicsDevice.Clear(Color.Transparent); // clear surface first

spriteBatch.Begin();
/// Draw items ...
spriteBatch.End();

graphics.GraphicsDevice.SetRenderTarget(null); // reset target surface when done, always use at the end of Draw()

// draw backbuffer background
graphics.GraphicsDevice.Clear(Color.CornflowerBlue);
// draw the render target
spriteBatch.Begin();
spriteBatch.Draw(renderTarget, Vector2.Zero, Color.White);
spriteBatch.End();

/* -----------------------------------------
   Enable Depth Buffer
----------------------------------------- */
// Draw():
graphics.GraphicsDevice.DepthStencilState = new DepthStencilState() { DepthBufferEnable = true };


/* -----------------------------------------
   Create a Blend Mode
----------------------------------------- */
// Draw():
BlendState blend            = new BlendState();
blend.ColorBlendFunction    = BlendFunction.Add;
blend.ColorSourceBlend      = Blend.DestinationColor;
blend.ColorDestinationBlend = Blend.Zero;

/*
	Blend.Zero
	BlendFunction.Add
	Blend.DestinationColor
*/


/* -----------------------------------------
   Get Display info
----------------------------------------- */
int screenWidth  = graphics.GraphicsDevice.Adapter.CurrentDisplayMode.Width;
int screenHeight = graphics.GraphicsDevice.Adapter.CurrentDisplayMode.Height;

