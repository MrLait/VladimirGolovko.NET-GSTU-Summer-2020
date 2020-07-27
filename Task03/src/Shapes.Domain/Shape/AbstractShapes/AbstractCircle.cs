using Shapes.Domain.UserExceprion;
using System;

namespace Shapes.Domain.Shape.AbstractShapes
{
    /// <summary>
    /// Abstract class with circle shape.
    /// </summary>
    public abstract class AbstractCircle : BaseAbstractShape
    {
        /// <summary>
        /// Constructor to create circle with radius.
        /// </summary>
        /// <param name="radius">Radius parameter.</param>
        public AbstractCircle(double radius)
        {
            Radius = radius;
        }

        /// <summary>
        /// Constructor to cut figure from another.
        /// </summary>
        /// <param name="curShape">The original shape to cut from.</param>
        /// <param name="cutShape">The shape that should turn out.</param>
        public AbstractCircle(BaseAbstractShape curShape, AbstractCircle cutShape) : base(curShape,cutShape)
        {
            ShapeException.MaterialEqualsHandler(curShape, cutShape);
            Radius = cutShape.Radius;
        }

        /// <summary>
        /// Property radius.
        /// </summary>
        public double Radius { get; }

        /// <summary>
        /// Property to getting Area of circle.
        /// </summary>
        public override double Area => GetArea();

        /// <summary>
        /// Property to getting perimeter of circle.
        /// </summary>
        public override double Perimeter => GetPerimeter();

        /// <summary>
        /// Comparing one circle wit another.
        /// </summary>
        /// <param name="obj">The compared circle.</param>
        /// <returns>True if equal. False if not eqal.</returns>
        public override bool Equals(Object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;
            AbstractCircle r = (AbstractCircle)obj;
            return Radius.Equals(r.Radius);
        }

        /// <summary>
        /// Calculate hash code.
        /// </summary>
        /// <returns>The total hesh code.</returns>
        public override int GetHashCode()
        {
            return Radius.GetHashCode();
        }

        /// <summary>
        /// Represents class members in string format.
        /// </summary>
        /// <returns>Returns class members in string format.</returns>
        public override string ToString()
        {
            return string.Format("{0};{1}", base.ToString(), Radius);
        }

        private double GetArea() => Math.Round(Math.PI * Math.Pow(Radius, 2), 2);
        private double GetPerimeter() => Math.Round(Math.PI * 2 * Radius, 2);
    }
}
