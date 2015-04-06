#region License

// Copyright (c) 2015 FCDM
// Permission is hereby granted, free of charge, to any person obtaining 
// a copy of this software and associated documentation files (the "Software"), 
// to deal in the Software without restriction, including without limitation the 
// rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell 
// copies of the Software, and to permit persons to whom the Software is furnished 
// to do so, subject to the following conditions:

// The above copyright notice and this permission notice shall be included in all 
// copies or substantial portions of the Software.

// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, 
// INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A 
// PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
// HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION 
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE 
// SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

#endregion

// AUTHOR: Michael Ala

using System;
using System.Collections.Generic;

namespace Phosphaze.Core
{
    /// <summary>
    /// The game options.
    /// </summary>
    public static class Options
    {
        // Alright currently there's no point to having an internal
        // Globals class, but in the future we may need a Locals
        // class for Level specific options. We're not sure. This
        // just feels right right now.

        /// <summary>
        /// The global game options.
        /// </summary>
        public static class Globals
        {

            // The number of seconds delay between when the player
            // enters a level and when the bullets actually start
            // spawning.
            public static double SongOffset = 2.5;

            // Whether the window is FullScreen or not.
            [Obsolete] // NOT ACTUALLY USED AS OF ITERATION 2.
            public static bool FullScreen = false;

            // Whether or not bloom effects are used.
            public static bool BloomEffects = true;

            private static float _bgdim = 0.5f;

            // The background dim amount (ranges from 0 to 1).
            public static float BackgroundDim
            {
                get { return _bgdim; }
                set
                {
                    if (!(value >= 0 && value <= 1))
                        throw new ArgumentException("BackgroundDim must be clamped between 0 and 1 inclusive.");
                    _bgdim = value;
                }
            }

            // Whether or not the keyboard is used for controls, or the mouse.
            // If true, then the keyboard controls the player, otherwise the
            // mouse controls the player. This does not override the dual
            // functionality of the keyboard and the mouse in menu scenes.
            public static bool KeyboardControls = true;

            /// <summary>
            /// The various volume sliders (clamped between 0 and 1 inclusive).
            /// </summary>
            public static class Volumes
            {

                private static float _gbvol = 0.5f;
                private static float _sfxvol = 0.5f;
                private static float _mscvol = 0.5f;

                // The global volume (from 0 to 1).
                public static float GlobalVolume
                {
                    get { return _gbvol; }
                    set
                    {
                        if (!(value >= 0 && value <= 1))
                            throw new ArgumentException("GlobalVolume must be clamped between 0 and 1 inclusive.");
                        _gbvol = value;
                        _sfxvol = value;
                        _mscvol = value;
                    }
                }

                // The volume of the sound effects (from 0 to 1).
                public static float SoundFXVolume
                {
                    get { return _sfxvol; }
                    set
                    {
                        if (!(value >= 0 && value <= 1))
                            throw new ArgumentException("SoundFXVolume must be clamped between 0 and 1 inclusive.");
                        _sfxvol = value;
                    }
                }

                // The volume of the music (from 0 to 1).
                public static float MusicVolume
                {
                    get { return _mscvol; }
                    set
                    {
                        if (!(value >= 0 && value <= 1))
                            throw new ArgumentException("MusicVolume must be clamped between 0 and 1 inclusive.");
                        _mscvol = value;
                    }
                }

            }

        }

    }
}
