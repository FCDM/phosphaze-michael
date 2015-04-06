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
using System.Linq;
using Microsoft.Xna.Framework;
using Phosphaze.Core;

namespace Phosphaze.Core.SceneElements
{
    /// <summary>
    /// A special type of scene used for creating menus.
    /// </summary>
    public class MenuScene : Scene
    {

        // List of available MenuElements.
        List<MenuElement> elements = new List<MenuElement>();

        /// <summary>
        /// Menu Scene Initialization.
        /// </summary>
        public override void Initialize()
        {

        }

        /// <summary>
        /// Menu Scene update.
        /// </summary>
        /// <param name="gameTime">The global game time.</param>
        public override void Update(GameTime gameTime)
        {

        }

        /// <summary>
        /// Retrieve a MenuElement of the given generic type by it's name, or
        /// null if no such element exists.
        /// </summary>
        /// <typeparam name="T">
        /// The type of MenuElement to retrieve. Must be a subclass of MenuElement.
        /// </typeparam>
        /// <param name="name">The name of the MenuElement to retrieve.</param>
        /// <returns>The first matching MenuElement.</returns>
        public T GetElement<T>(string name) where T : MenuElement
        {
            foreach (MenuElement element in elements)
            {
                if (element is T && element.name.Equals(name))
                {
                    return (T)element;
                }
            }
            return null;
        }

        /// <summary>
        /// Return a list of all elements of the given generic type.
        /// </summary>
        /// <typeparam name="T">
        /// The type of MenuElement to retrieve. Must be a subclass of MenuElement.
        /// </typeparam>
        /// <returns>A list of all MenuElements of the given type.</returns>
        public List<T> GetElements<T>() where T : MenuElement
        {
            var _elements = from element in elements
                            where element is T
                            select (T)element;
            return new List<T>(_elements);
        }

    }
}
