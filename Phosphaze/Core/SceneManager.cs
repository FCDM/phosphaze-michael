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
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Phosphaze.Core
{
    /// <summary>
    /// For overlapping scenes.
    /// </summary>
    public sealed class SceneManager
    {

        // Mapping of scene names to scene objects.
        Dictionary<string, Scene> registered_scenes = new Dictionary<string, Scene>();

        // The name of the current scene (or null).
        private string current_scene;

        // The default scene (or null).
        private Scene default_scene;

        // The game GraphicsDeviceManager.
        public GraphicsDeviceManager graphics { get; private set; }

        // The game ContentManager;
        public ContentManager Content { get; private set; }

        // The game SpriteBatch;
        public SpriteBatch spriteBatch { get; private set; }

        /// <summary>
        /// Construct a new SceneManager.
        /// </summary>
        public SceneManager(
            GraphicsDeviceManager graphics, 
            ContentManager content, 
            SpriteBatch spriteBatch)
            : this(null, null, graphics, content, spriteBatch) { }

        /// <summary>
        /// Construct a new SceneManager whose initial scene has the given name.
        /// </summary>
        /// <param name="initial_scene">The name of the initial scene.</param>
        public SceneManager(
            string initial_scene, 
            GraphicsDeviceManager graphics, 
            ContentManager content, 
            SpriteBatch spriteBatch)
            : this(initial_scene, null, graphics, content, spriteBatch) { }

        /// <summary>
        /// Construct a new SceneManager whose initial scene has the given name,
        /// and uses the given default Scene if the current scene is null.
        /// </summary>
        /// <param name="initial_scene">The name of the initial scene.</param>
        /// <param name="default_scene">The default Scene object.</param>
        public SceneManager(
            string initial_scene, 
            Scene default_scene, 
            GraphicsDeviceManager graphics, 
            ContentManager content, 
            SpriteBatch spriteBatch)
        {
            current_scene = initial_scene;
            if (default_scene != null)
                default_scene.SetManager(this);
            this.default_scene = default_scene;

            this.graphics = graphics;
            this.Content = content;
            this.spriteBatch = spriteBatch;
        }

        /// <summary>
        /// Register a scene to this SceneManager.
        /// </summary>
        /// <param name="name">The name of the scene by which to reference it.</param>
        /// <param name="scene">The scene object.</param>
        public void RegisterScene(string name, Scene scene)
        {
            scene.SetManager(this);
            // Scene specific initialization.
            scene.Initialize();

            registered_scenes.Add(name, scene);
        }

        /// <summary>
        /// Remove a registered scene.
        /// </summary>
        /// <param name="name">The name to revoke.</param>
        public void RevokeRegisteredScene(string name)
        {
            registered_scenes.Remove(name);
        }

        /// <summary>
        /// Update the current scene.
        /// </summary>
        /// <param name="gameTime"></param>
        public void Update(GameTime gameTime)
        {
            // Update the scene with the current_scene name.
            if (current_scene != null)
            {
                registered_scenes[current_scene].Update(gameTime);
            }
            else
            {
                // Default to updating the default scene if the current_scene is null.
                if (default_scene != null)
                {
                    default_scene.Update(gameTime);
                }
                else
                {
                    // Throw an exception if there is no default scene to use.
                    throw new NullReferenceException("No default scene set.");
                }
            }
        }
        
        /// <summary>
        /// Set the current scene.
        /// </summary>
        /// <param name="scene">The name of the current scene.</param>
        public void SetCurrentScene(string scene)
        {
            current_scene = scene;
        }

        /// <summary>
        /// Set the current scene to the default scene.
        /// </summary>
        public void Default()
        {
            SetCurrentScene(null);
        }

    }
}
