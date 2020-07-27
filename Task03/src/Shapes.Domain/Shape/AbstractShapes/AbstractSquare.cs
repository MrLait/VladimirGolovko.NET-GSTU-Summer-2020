using Shapes.Domain.UserExceprion;
using System;

namespace Shapes.Domain.Shape.AbstractShapes
{
    /// <summary>
    /// Abstract class square shape.
    /// </summary>
    public abstract class AbstractSquare : BaseAbstractShape
    {
        /// <summary>
        /// Constructor to create square with length.
        /// </summary>
        /// <param name="length">Lenth parameter.</param>
        public AbstractSquare(double length)
        {
            Side = length;
        }

        /// <summary>
        /// Constructor to cut figure from another.
        /// </summary>
        /// <param name="curShape">The original shape to cut from.</param>
        /// <param name="cutShape">The shape that should turn out.</param>
        public AbstractSquare(BaseAbstractShape curShape, AbstractSquare cutShape) : base(curShape, cutShape)
        {
            ShapeException.MaterialEqualsHandler(curShape, cutShape);
            Side = cutShape.Side;
        }

        /// <summary>
        /// Property side
        /// </summary>
        public double Side { get; private set; }

        /// <summary>
        /// Property to getting area of square.
        /// </summary>
        public override double Area => GetArea();

        /// <summary>
        /// Property to getting perimeter of square.
        /// </summary>
        public override double Perimeter => GetPerimeter();

        /// <summary>
        /// Comparing one square with another.
        /// </summary>
        /// <param name="obj">The compared square.</param>
        /// <returns>True if equal. False if not eqal.</returns>
        public override bool Equals(Object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;
            AbstractSquare r = (AbstractSquare)obj;
            return Side.Equals(r.Side);
        }

        /// <summary>
        /// Calculate hash code.
        /// </summary>
        /// <returns>The total hesh code.</returns>
        public override int GetHashCode()
        {
            return Side.GetHashCode();
        }

        /// <summary>
        /// Represents class members in string format.
        /// </summary>
        /// <returns>Returns class members in string format.</returns>
        public override string ToString()
        {
            return string.Format("{0};{1}", base.ToString(), Side);
        }

        private double GetArea() => Math.Pow(Side, 2);
        private double GetPerimeter() => Side * 4;
    }
}
