using Shapes.Domain.Enum;
using Shapes.Domain.Interfaces;
using System;

namespace Shapes.Domain
{
    /// <summary>
    ///  Class square shape.
    /// </summary>
    public class Square : BaseShape
    {
        public Square(IMaterial previousShape, IMaterial currentShape) : base(previousShape, currentShape)
        {
            Square curSquare;
            try
            {
                curSquare = (Square)currentShape;
            }
            catch (InvalidCastException)
            {
                throw new InvalidCastException();
            }
            Side = curSquare.Side;
        }

        public Square(double length)
        {
            Side = length;
        }

        /// <summary>
        /// Constructor with length parameter.
        /// </summary>
        /// <param name="length"></param>
        public Square(double length, Color color) : base(color)
        {
            Side = length;
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

        public override bool IsFilm { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        private double GetArea() => Math.Pow(Side, 2);
        private double GetPerimeter() => Side * 4;

        /// <summary>
        /// Comparing one square with another.
        /// </summary>
        /// <param name="obj">The compared square.</param>
        /// <returns>True if equal. False if not eqal.</returns>
        public override bool Equals(Object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;
            Square r = (Square)obj;
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

    }
}
