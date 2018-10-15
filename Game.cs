
/**
 * Game.cs
 * Game related snippets for MonoGame
 */

/* using */
using System; // for Timespan
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


/* -----------------------------------------
   Setup Game Window
----------------------------------------- */
// Initialize():
Game game = this;
game.Window.Title             = "Application"; // set the window title
game.Window.AllowAltF4        = true; // allow Alt+F4 to close the game window or not
game.Window.AllowUserResizing = false; // make the window resizable or not
game.Window.IsBorderless      = false; // enable or disable the window border

// center window (if not fullscreen)
if (!game.graphics.IsFullScreen) {
	game.Window.Position = new Point(
		(graphics.GraphicsDevice.Adapter.CurrentDisplayMode.Width  / 2) - (graphics.PreferredBackBufferWidth  / 2),
		(graphics.GraphicsDevice.Adapter.CurrentDisplayMode.Height / 2) - (graphics.PreferredBackBufferHeight / 2)
	);
} 


/* -----------------------------------------
   Setup Content Folder Root
----------------------------------------- */
// Initialize(): 
Game game = this;
game.Content.RootDirectory = "Data"; // change the Content root to be in "./Data/" instead


/* -----------------------------------------
   Set Framerate
----------------------------------------- */
// Initialize():
Game game = this;
game.IsFixedTimeStep   = true; // lock FPS
game.TargetElapsedTime = TimeSpan.FromSeconds(1d / 30d); // set the framerate to 30 FPS


/* -----------------------------------------
   Check Game Focus
----------------------------------------- */
// Update():
// check state
Game game = this;
if (!game.IsActive) {
	// execute when not active
}

// Class Body:
// override events
protected override void OnActivated(object sender, System.EventArgs args)
{
	// resume game ...
	base.OnActivated(sender, args);
}

protected override void OnDeactivated(object sender, System.EventArgs args)
{
	// pause game ...
	base.OnActivated(sender, args);
}


/* -----------------------------------------
   Capture Close Button Event (Windows)
----------------------------------------- */
// Initialize():
#if WINDOWS
Game game = this;
System.Windows.Forms.Form gameWindowForm = (System.Windows.Forms.Form)System.Windows.Forms.Form.FromHandle(game.Window.Handle);
gameWindowForm.Closing += OnQuitting;
#endif

// Class Body:
#if WINDOWS
public void OnQuitting(object sender, System.ComponentModel.CancelEventArgs e)
{

	// show a messagebox before quitting, or add your own event ...
	System.Windows.Forms.DialogResult res = System.Windows.Forms.MessageBox.Show("Are you sure you want to quit? You will lose any unsaved progress!", "Warning", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.None);
	if (res == System.Windows.Forms.DialogResult.No) {
		e.Cancel = true; // do not quit the game
		return;
	}
	
}
#endif


/* -----------------------------------------
   Set Mouse Cursor Visibility
----------------------------------------- */
// Initialize(), Update():
Game game = this;
game.IsMouseVisible = false; // hide the mouse cursor


/* -----------------------------------------
   Switch Fullscreen mode with Alt+F4
----------------------------------------- */
// Constructor: 
Game game = this;
GraphicsDeviceManager graphics = new GraphicsDeviceManager(game);
private KeyboardState keyboardOldState;

// Update():
KeyboardState keyboardNewState = Keyboard.GetState();

if (keyboardNewState.IsKeyDown(Keys.LeftAlt) && (keyboardOldState.IsKeyUp(Keys.Enter) && keyboardNewState.IsKeyDown(Keys.Enter))
) {
	if (graphics.IsFullScreen) {
		// switch to window
		graphics.IsFullScreen              = false;
		game.Window.IsBorderless           = false;
		graphics.PreferredBackBufferWidth  = 1280;
		graphics.PreferredBackBufferHeight = 720;				
	} else {
		// switch to fullscreen
		graphics.IsFullScreen              = true;
		game.Window.IsBorderless           = true;
		graphics.PreferredBackBufferWidth  = graphics.GraphicsDevice.Adapter.CurrentDisplayMode.Width;
		graphics.PreferredBackBufferHeight = graphics.GraphicsDevice.Adapter.CurrentDisplayMode.Height;
	}
	
	// apply changes (before centering below)
	graphics.ApplyChanges();

	// if windowed, center the window
	if (!graphics.IsFullScreen) {
		game.Window.Position = new Point(
			(graphics.GraphicsDevice.Adapter.CurrentDisplayMode.Width  / 2) - (graphics.PreferredBackBufferWidth  / 2),
			(graphics.GraphicsDevice.Adapter.CurrentDisplayMode.Height / 2) - (graphics.PreferredBackBufferHeight / 2)
		);
	}
}

// at update end, reset state
keyboardOldState = keyboardNewState; // reset state for next press


/* -----------------------------------------
   Quit Game
----------------------------------------- */
// Update():
// quit game on ESC key press
if (Keyboard.GetState().IsKeyDown(Keys.Escape)) {
	base.Exit();
}


/* -----------------------------------------
   Crash the Game
----------------------------------------- */
throw new Exception();

