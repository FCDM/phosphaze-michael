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

namespace Phosphaze.Core.Collision
{
    /// <summary>
    /// Represents a class that implements collision detection.
    /// </summary>
    public interface ICollidable
    {
        
        /// <summary>
        /// Return this Collider's Collision Priority. The Collision Priority
        /// of a Collider is a property used to determine what collision algorithm
        /// to use.
        /// </summary>
        /// <returns></returns>
        int GetCollisionPriority();

        /// <summary>
        /// Check for collisions between this ICollidable object and another.
        /// </summary>
        /// <param name="other">The other ICollidable object.</param>
        /// <returns>A CollisionContext or null.</returns>
        CollisionContext GetCollision(ICollidable other);

    }
}
