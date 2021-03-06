﻿using Shapes.Domain.UserExceprion;
using System;

namespace Shapes.Domain.Shape.AbstractShapes
{
    /// <summary>
    /// Abstract class with rectangle shape.
    /// </summary>
    public abstract class AbstractRectangle : BaseAbstractShape
    {
        /// <summary>
        /// Constructor to create rectangle with length and width.
        /// </summary>
        /// <param name="length">Lenth parameter.</param>
        /// <param name="width">Color parameter.</param>
        public AbstractRectangle(double length, double width)
        {
            Length = length;
            Width = width;
        }

        /// <summary>
        /// Constructor to cut figure from another.
        /// </summary>
        /// <param name="curShape">The original shape to cut from.</param>
        /// <param name="cutShape">The shape that should turn out.</param>
        public AbstractRectangle(BaseAbstractShape curShape, AbstractRectangle cutShape) : base(curShape, cutShape)
        {
            ShapeException.MaterialEqualsHandler(curShape, cutShape);
            Length = cutShape.Length;
            Width = cutShape.Width;
        }

        /// <summary>
        /// Property length
        /// </summary>
        public double Length { get; private set; }

        /// <summary>
        /// Property width
        /// </summary>
        public double Width { get; private set; }

        /// <summary>
        /// Property to getting area of rectangle.
        /// </summary>
        public override double Area => GetArea();

        /// <summary>
        /// Property to getting perimeter of rectangle.
        /// </summary>
        public override double Perimeter => GetPerimeter();

        /// <summary>
        /// Comparing one rectangle with another.
        /// </summary>
        /// <param name = "obj" > The compared rectangle.</param>
        /// <returns>True if equal.False if not equal.</returns>
        public override bool Equals(Object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;
            AbstractRectangle r = (AbstractRectangle)obj;
            return Length.Equals(r.Length) && Width.Equals(r.Width);
        }

        /// <summary>
        /// Calculate hash code.
        /// </summary>
        /// <returns>The total hesh code.</returns>
        public override int GetHashCode()
        {
            return Tuple.Create(Length, Width).GetHashCode();
        }

        /// <summary>
        /// Represents class members in string format.
        /// </summary>
        /// <returns>Returns class members in string format.</returns>
        public override string ToString()
        {
            return string.Format("{0};{1};{2}", base.ToString(), Length, Width);
        }

        private double GetArea() => Length * Width;
        private double GetPerimeter() => 2 * Length + 2 * Width;
    }
}
