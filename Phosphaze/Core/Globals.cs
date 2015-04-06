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
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Phosphaze.Core
{
    public static class Globals
    {
        // The Screen Width.
        public const int SW =  800;

        // The Screen Height.
        public const int SH = 920;

        // The Screen Background Fill Colour.
        public static Color BG_FCOL = Color.Black;

        /// <summary>
        /// The global options used by the entire game.
        /// </summary>
        public static class Options
        {

            #region Booleans

            // Whether or not the game is fullscreen or not.
            public static Boolean Fullscreen = false;

            // Whether or not we move with the mouse or the arrow keys.
            public static Boolean MoveWithMouse = false;

            #endregion

            #region Keybindings

            // The key corresponding to the "UP" action.
            public static Keys K_UP = Keys.Up;

            // The key corresponding to the "DOWN" action.
            public static Keys K_DOWN = Keys.Down;

            // The key corresponding to the "LEFT" action.
            public static Keys K_LEFT = Keys.Left;

            // The key corresponding to the "RIGHT" action.
            public static Keys K_RIGHT = Keys.Right;

            // The key corresponding to the "SELECT" action.
            public static Keys K_SELECT = Keys.Enter;

            // The key corresponding to the "EXIT" action.
            public static Keys K_EXIT = Keys.Escape;

            #endregion

            #region Miscellaneous

            public static string SongFolder = @"\Songs";

            #endregion
        }
    }
}
