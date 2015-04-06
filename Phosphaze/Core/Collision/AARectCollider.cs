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

namespace Phosphaze.Core.Collision
{
    /// <summary>
    /// An ICollidable object representing an axis-aligned rectangular area.
    /// </summary>
    public class AARectCollider : ICollidable
    {

        /// <summary>
        /// Return the AARectCollider Collision Priority (1).
        /// </summary>
        /// <returns>1</returns>
        public int GetCollisionPriority() { return 1; }

        #region Fields and Properties

        // The x coordinate of the topleft corner.
        public double x {get; private set;}
        // The y coordinate of the topleft corner.
        public double y {get; private set;}
        // The width of the rect.
        public double w {get; private set;}
        // The height of the rect.
        public double h {get; private set;}

        // The area of the rectangle.
        public double Area
        {
            get { return w * h; }
        }

        // The perimeter of the rectangle.
        public double Perimeter
        {
            get { return 2 * (w + h); }
        }

        #region Corners

        // The topleft corner.
        public Vector2 TopLeft
        {
            get { return new Vector2((float)x, (float)y); }
        }

        // The topright corner.
        public Vector2 TopRight
        {
            get { return new Vector2((float)(x + w), (float)y); }
        }

        // The bottomleft corner.
        public Vector2 BottomLeft
        {
            get { return new Vector2((float)x, (float)(y + h)); }
        }

        // The bottomright corner.
        public Vector2 BottomRight
        {
            get { return new Vector2((float)(x + w), (float)(y + h)); }
        }

        // A list of the corners in clockwise order.
        public List<Vector2> Corners
        {
            get { return new List<Vector2> {TopLeft, TopRight, BottomRight, BottomLeft}; }
        }

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Default AARectCollider constructor. Equivalent to AARectCollider(0f, 0f, 0f, 0f).
        /// </summary>
        public AARectCollider() : this(0f, 0f, 0f, 0f) { }

        /// <summary>
        /// Construct an AARectCollider representing a square area with topleft corner at the origin.
        /// </summary>
        /// <param name="side_length">The side length of the square.</param>
        public AARectCollider(double side_length) : this(0f, 0f, side_length, side_length) { }

        /// <summary>
        /// Construct an AARectCollider representing a rectangle with topleft corner at the origin.
        /// </summary>
        /// <param name="w">The width of the rectangle.</param>
        /// <param name="h">The height of the rectangle.</param>
        public AARectCollider(double w, double h) : this(0f, 0f, w, h) { }

        /// <summary>
        /// Construct an AARectCollider representing a square with the given topleft corner.
        /// </summary>
        /// <param name="x">The x coordinate of the topleft corner.</param>
        /// <param name="y">The y coordinate of the topleft corner.</param>
        /// <param name="side_length">The side length of the square.</param>
        public AARectCollider(double x, double y, double side_length) : this(x, y, side_length, side_length) { }

        /// <summary>
        /// Construct an AARectCollider representing a rectangular area.
        /// </summary>
        /// <param name="x">The x coordinate of the topleft corner.</param>
        /// <param name="y">The y coordinate of the topleft corner.</param>
        /// <param name="w">The width of the rectangle.</param>
        /// <param name="h">The height of the rectangle.</param>
        public AARectCollider(double x, double y, double w, double h)
        {
            this.x = x;
            this.y = y;
            this.w = w;
            this.h = h;
        }

        /// <summary>
        /// Construct an AARectCollider from the list of parameters.
        /// </summary>
        /// <param name="parameters"></param>
        public AARectCollider(List<Double> parameters) 
        {
            switch (parameters.Count)
            {
                case 0:
                    x = 0;
                    y = 0;
                    w = 0;
                    h = 0;
                    break;
                case 1:
                    x = 0;
                    y = 0;
                    w = parameters[0];
                    h = parameters[0];
                    break;
                case 2:
                    x = 0;
                    y = 0;
                    w = parameters[0];
                    h = parameters[1];
                    break;
                case 3:
                    x = parameters[0];
                    y = parameters[1];
                    w = parameters[2];
                    h = parameters[2];
                    break;
                case 4:
                    x = parameters[0];
                    y = parameters[1];
                    w = parameters[2];
                    h = parameters[3];
                    break;
                default:
                    throw new ArgumentException("Invalid parameter count.");
            }
        }

        #endregion

        /// <summary>
        /// Construct a new CollisionContext between the two ICollidable objects.
        /// </summary>
        /// <param name="collidable1"></param>
        /// <param name="collidable2"></param>
        public CollisionContext GetCollision(ICollidable other)
        {
            CollisionContext context = null;
            switch (other.GetCollisionPriority())
            {
                case 1:
                    context = collision_withAARect((AARectCollider)other);
                    break;
                default:
                    throw new CollisionPriorityException("Unknown collision priority " + other.GetCollisionPriority());
            }
            return context;
        }

        #region Collision Algorithms

        /// <summary>
        /// Calculate a collision with another AARectCollider.
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        private CollisionContext collision_withAARect(AARectCollider other)
        {
            double x2 = other.x, y2 = other.y, w2 = other.w, h2 = other.h;

            // This simply checks if any axes are overlapping. All axes must
            // overlap for the rects to be colliding.
            if (x <= x2 + w2 && x + w >= x2 && y <= y2 + h2 && y + h > y2)
                return new CollisionContext(this, other);
            return null;
        }

        #endregion

        /// <summary>
        /// Return a Rectangle struct representing this AARectCollider.
        /// </summary>
        /// <returns></returns>
        public Rectangle AsRectangle()
        {
            return new Rectangle((int)x, (int)y, (int)w, (int)h);
        }

    }
}
