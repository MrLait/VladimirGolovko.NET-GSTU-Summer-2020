using System;

namespace Shapes.Domain
{
    public class Rectangle : BaseShape
    {
        public Rectangle(double length, double width)
        {
            Length = length;
            Width = width;
        }

        public double Length { get; private set; }

        public double Width { get; private set; }

        public override double Area
        {
            get => Length * Width;
        }

        public override double Perimeter
        {
            get => 2 * Length + 2 * Width;
        }

        /// <summary>
        /// Comparing one rectangle with another.
        /// </summary>
        /// <param name="obj">The compared rectangle.</param>
        /// <returns>True if equal. False if not equal.</returns>
        public override bool Equals(Object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;
            Rectangle r = (Rectangle)obj;
            return Length.Equals(r.Length) && Width.Equals(r.Width);
        }

        /// <summary>
        /// Calculate hash code.
        /// </summary>
        /// <returns>The total hesh code.</returns>
        public override int GetHashCode()
        {
            return Length.GetHashCode() + Width.GetHashCode();
        }

        /// <summary>
        /// Represents class members in string format.
        /// </summary>
        /// <returns>Returns class members in string format.</returns>
        public override string ToString()
        {
            return string.Format("{0};{1};{2}", base.ToString(), Length, Width);
        }
    }
}
