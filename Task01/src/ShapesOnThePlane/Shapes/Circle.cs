using System;

namespace ShapesOnThePlane.Shapes
{
    public class Circle : Shape
    {
        public Circle(double radius)
        {
            Radius = radius;
        }
        
        public double Radius { get; }

        public override double Area
        {
            get => Math.Round(Math.PI * Math.Pow(Radius, 2), 2);
        }

        public override double Perimeter
        {
            get => Math.Round(Math.PI * 2 * Radius, 2);
        }

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
