﻿#region License

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

namespace Phosphaze.Core
{
    /// <summary>
    /// The base interface for scene objects.
    /// </summary>
    public abstract class Scene
    {

        // The SceneManager that oversees this scene.
        protected SceneManager manager;

        /// <summary>
        /// Assign a SceneManager to this scene.
        /// </summary>
        /// <param name="manager">The SceneManager.</param>
        public void SetManager(SceneManager manager)
        {
            this.manager = manager;
        }

        /// <summary>
        /// Perform any scene specific initialization.
        /// </summary>
        public abstract void Initialize();

        /// <summary>
        /// Update this scene.
        /// </summary>
        /// <param name="game">The global game time.</param>
        public abstract void Update(GameTime game);

    }
}
