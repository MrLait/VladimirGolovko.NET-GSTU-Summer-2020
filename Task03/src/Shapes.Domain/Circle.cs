using Shapes.Domain.Enum;
using Shapes.Domain.Interfaces;
using Shapes.Domain.Matarial;
using System;

namespace Shapes.Domain
{
    /// <summary>
    /// Class circle shape.
    /// </summary>
    public class Circle : BaseShape
    {
        public Circle(IMaterial previousShape, IMaterial currentShape) : base(previousShape, currentShape)
        {
            Circle curCircle;
            try
            {
                curCircle = (Circle)currentShape;
            }
            catch (InvalidCastException)
            {

                throw new InvalidCastException();
            }
            Radius = curCircle.Radius;
        }
        public Circle(double radius)
        {
            Radius = radius;
        }
        public Circle(double radius, IMaterial material)
        {
            var b = material is IFilm;
            var m = (Film)material;
            var t = material.GetType().Name;
            Material = material;

            Radius = radius;
        }
        public IMaterial Material { get; set; }
        /// <summary>
        /// Constructor with radius parameter.
        /// </summary>
        /// <param name="radius">Parameter for init radius.</param>
        public Circle(double radius, Color color) : base(color)
        {
            Radius = radius;
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

        public override bool IsFilm { get; set; }

        private double GetArea() => Math.Round(Math.PI * Math.Pow(Radius, 2), 2);
        private double GetPerimeter() => Math.Round(Math.PI * 2 * Radius, 2);


        /// <summary>
        /// Comparing one circle wit another.
        /// </summary>
        /// <param name="obj">The compared circle.</param>
        /// <returns>True if equal. False if not eqal.</returns>
        public override bool Equals(Object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;
            Circle r = (Circle)obj;
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
    }
}
