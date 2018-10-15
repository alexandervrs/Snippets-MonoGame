
/**
 * Input.cs
 * Input related snippets for MonoGame
 */

/* using */
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;


/* -----------------------------------------
   Check Hold Keyboard Key Down
----------------------------------------- */
// Update():
KeyboardState keyboard = Keyboard.GetState();

if (keyboard.IsKeyDown(Keys.Left)) { // IsKeyDown, IsKeyUp
	// key pressed ...
}


/* -----------------------------------------
   Check Keyboard Key Once
----------------------------------------- */
// Constructor: 
private KeyboardState keyboardOldState;

// Update():
KeyboardState keyboardNewState = Keyboard.GetState();

if (keyboardOldState.IsKeyUp(Keys.Left) && keyboardNewState.IsKeyDown(Keys.Left)) {
	// key pressed ...
}

/// Handle rest of Update() ...

// at update end, reset state
keyboardOldState = keyboardNewState; // reset state for next press

/* -----------------------------------------
   Check Hold Mouse Button Down
----------------------------------------- */
// Update():
MouseState mouse = Mouse.GetState();

if (mouseState.LeftButton == ButtonState.Pressed) { 
	/// button pressed ...
}


/* -----------------------------------------
   Check Mouse Button Once
----------------------------------------- */
// Constructor: 
private MouseState mouseOldState;

// Update():
MouseState mouseNewState = Mouse.GetState();
 
if (mouseNewState.LeftButton == ButtonState.Pressed && mouseOldState.LeftButton == ButtonState.Released) { // Pressed, Released
    /// button pressed ...
}

/// Handle rest of Update() ...

// at update end, reset state
mouseOldState = mouseNewState; // reset state for next press


/* -----------------------------------------
   Check Hold Gamepad Button
----------------------------------------- */
// Update():
GamePadState gpad1 = GamePad.GetState(PlayerIndex.One);

// check connection first
if (gpad1.IsConnected) {

	// check gamepad button
	if (gpad1.Buttons.X == ButtonState.Pressed) { // ButtonState.Pressed, ButtonState.Released
		// button pressed ...
	}
	
	/*
		Buttons:
			A, B, Y, X, Back, Start
	*/

}

/* -----------------------------------------
   Check Gamepad Button Once
----------------------------------------- */
// Constructor: 
private GamePadState gpad1OldState;

// Update():
GamePadState gpad1NewState = GamePad.GetState(PlayerIndex.One);

// check connection first
if (gpad1NewState.IsConnected) {

	// check gamepad button
	if (gpad1NewState.Buttons.X == ButtonState.Pressed && gpad1OldState.Buttons.X == ButtonState.Released) { // ButtonState.Pressed, ButtonState.Released
		// button pressed ...
	}

}

/// Handle rest of Update() ...

// at update end, reset state
gpad1OldState = gpad1NewState; // reset state for next press



/* -----------------------------------------
   Check Hold Gamepad DPAD
----------------------------------------- */
// Update():
GamePadState gpad1 = GamePad.GetState(PlayerIndex.One);

// check connection first
if (gpad1.IsConnected) {

	// check gamepad button
	if (gpad1.DPad.Down == ButtonState.Pressed) {
		// button pressed ...
	}

}

/* -----------------------------------------
   Vibrate the Gamepad
----------------------------------------- */
// Update():
GamePadState gpad1 = GamePad.GetState(PlayerIndex.One);

// check connection first
if (gpad1.IsConnected) {
	
	GamePad.SetVibration(PlayerIndex.One, 1.0f, 1.0f); // setting to 0.0f, 0.0f will stop the vibration
	
}

