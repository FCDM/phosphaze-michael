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

namespace Phosphaze.Core.Collision
{
    /// <summary>
    /// Represents information retrieved from a collision between two
    /// ICollidable objects.
    /// </summary>
    public class CollisionContext
    {

        // The two collidable objects involved in this context.
        ICollidable collidable1;
        ICollidable collidable2;

        /// <summary>
        /// Construct a new CollisionContext between the two ICollidable objects.
        /// </summary>
        /// <param name="collidable1"></param>
        /// <param name="collidable2"></param>
        public CollisionContext(ICollidable collidable1, ICollidable collidable2)
        {
            this.collidable1 = collidable1;
            this.collidable2 = collidable2;
        }
    }
}
