
/**
 * Audio.cs
 * Audio related snippets for MonoGame
 */

/* using */
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;


/* -----------------------------------------
   Play a Sound Effect OneShot
----------------------------------------- */
// LoadContent():
SoundEffect sfx = Content.Load<SoundEffect>("Audio\\TestSample");  // load TestSample as SoundEffect from ./<Content>/Audio/ folder

// play
sfx.Play(1.0f, 1.0f, 0.0f); // (volume, pitch, pan)


/* -----------------------------------------
   Play a Sound Effect with Instance
----------------------------------------- */
// LoadContent():
SoundEffect sfx = Content.Load<SoundEffect>("Audio\\TestSample");  // load TestSample as SoundEffect from ./<Content>/Audio/ folder

// Update():
// play with SoundEffectInstance reference
SoundEffectInstance sfxInstance = sfx.CreateInstance();
sfxInstance.IsLooped            = false; // looping state
sfxInstance.Volume              = 1.0f;
sfxInstance.Pan                 = 1.0f;
sfxInstance.Pitch               = 0.0f;
sfxInstance.Play();


/* -----------------------------------------
   Control Sound Effect Instance playback
----------------------------------------- */
// Update():
// stop
sfxInstance.Stop(); // uses our sfxInstance that we created above

// pause
sfxInstance.Pause();  // uses our sfxInstance that we created above (use Play() again to resume)


/* -----------------------------------------
   Check Sound Effect Instance playback
----------------------------------------- */
// Update():
// uses our sfxInstance that we created above
if (sfxInstance.State == SoundState.Playing) {  // SoundState.Playing, SoundState.Paused, SoundState.Stopped
	// is playing ...
}


/* -----------------------------------------
   Play a Background Track via MediaPlayer
----------------------------------------- */
// LoadContent():
Song song = Content.Load<Song>("Audio\\TestStream");  // load TestStream.ogg as Song from ./<Content>/Audio/ folder

// Update():
MediaPlayer.Volume = 1.0f;
MediaPlayer.IsRepeating = true; // looping state
MediaPlayer.Play(song);

// get song duration info
TimeSpan songDuration = song.Duration; 
// print as: songDuration.Minutes and songDuration.Seconds


/* -----------------------------------------
   Control the Media Player playback
----------------------------------------- */
// Update():
// stop
MediaPlayer.Stop();

// pause
MediaPlayer.Pause(); // (use Play() again to resume)


/* -----------------------------------------
   Get MediaPlayer track position Info
----------------------------------------- */
TimeSpan mpPosition = MediaPlayer.PlayPosition;
// print as: mpPosition.Minutes and mpPosition.Seconds

