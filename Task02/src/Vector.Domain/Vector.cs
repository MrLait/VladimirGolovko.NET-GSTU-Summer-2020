using System;

namespace Vectors.Domain
{
    /// <summary>
    /// Class vector with overloading opertors.
    /// </summary>
    public class Vector
    {
        /// <summary>
        /// X readonly coordinate.
        /// </summary>
        private readonly double x;
        /// <summary>
        /// Y readonly coordinate.
        /// </summary>
        private readonly double y;
        /// <summary>
        /// Z readonly coordinate.
        /// </summary>
        private readonly double z;

        /// <summary>
        /// This is a constructor for initializing x,y,z coordinates.
        /// </summary>
        /// <param name="x">x coordinate.</param>
        /// <param name="y">y coordinate.</param>
        /// <param name="z">z coordinate.</param>
        public Vector(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        /// <summary>
        /// X coordinate of the vector.
        /// </summary>
        public double X => x;

        /// <summary>
        /// Y coordinate of the vector.
        /// </summary>
        public double Y => y;

        /// <summary>
        /// Z coordinate of the vector.
        /// </summary>
        public double Z => z;

        /// <summary>
        /// The length property of the vector.
        /// </summary>
        public double Magnitude
        {
            get => Math.Sqrt(x * x + y * y + z * z);
        }

        /// <summary>
        /// Returns the normalized vector with a magnitude of 1.
        /// </summary>
        public Vector Normalized
        {
            get => new Vector(x / Magnitude, y / Magnitude, z / Magnitude);
        }

        /// <summary>
        /// Returns the squared length of the vector.
        /// </summary>
        public double SqrMagnitude
        {
            get => (x * x + y * y + z * z);
        }

        /// <summary>
        /// Direct access to components of vector x, y, z using an index.
        /// </summary>
        /// <param name="i">The index of a vector component.</param>
        /// <returns>Returns x, y or z compoent.</returns>
        public double this[int i]
        {
            get
            {
                switch (i)
                {
                    case 0: { return x; }
                    case 1: { return y; }
                    case 2: { return z; }
                    default:
                        throw new ArgumentOutOfRangeException("A vector can " +
                   "contain only three elements.");
                }
            }
        }

        /// <summary>
        /// Operator -subtracts one vector from another.
        /// </summary>
        /// <param name="vectorOne">The first vector.</param>
        /// <param name="vectorTwo">The second vector.</param>
        /// <returns>Returns the vector after subtraction.</returns>
        public static Vector operator -(Vector vectorOne, Vector vectorTwo)
        {
            return new Vector(
                vectorOne.X - vectorTwo.X,
                vectorOne.Y - vectorTwo.Y,
                vectorOne.Z - vectorTwo.Z);
        }

        /// <summary>
        /// Operator == Returns true if two vectors are approximately equal.
        /// </summary>
        /// <param name="vectorOne">The first vector.</param>
        /// <param name="vectorTwo">The second vector.</param>
        /// <returns>Returns bool after comparison.</returns>
        public static bool operator ==(Vector vectorOne, Vector vectorTwo)
        {
            return ((vectorOne.X == vectorTwo.X) &&
                    (vectorOne.Y == vectorTwo.Y) &&
                    (vectorOne.Z == vectorTwo.Z));
        }

        /// <summary>
        /// Operator != returns true if vectors different.
        /// </summary>
        /// <param name="vectorOne">The first vector.</param>
        /// <param name="vectorTwo">The second vector.</param>
        /// <returns>Returns bool after comparison.</returns>
        public static bool operator !=(Vector vectorOne, Vector vectorTwo)
        {
            return !(vectorOne == vectorTwo);
        }

        /// <summary>
        /// Operator + adds two vectors.
        /// </summary>
        /// <param name="vectorOne">The first vector.</param>
        /// <param name="vectorTwo">The second vector.</param>
        /// <returns>Returns the vector after summation.</returns>
        public static Vector operator +(Vector vectorOne, Vector vectorTwo)
        {
            return new Vector(
                vectorOne.X + vectorTwo.X,
                vectorOne.Y + vectorTwo.Y,
                vectorOne.Z + vectorTwo.Z);
        }

        /// <summary>
        /// Operator *multiplies a vector by a number.
        /// </summary>
        /// <param name="vectorOne">The first vector.</param>
        /// <param name="number">A number.</param>
        /// <returns>Returns the vector after multiplication.</returns>
        public static Vector operator *(Vector vectorOne, double number)
        {
            return new Vector(
                vectorOne.X * number,
                vectorOne.Y * number,
                vectorOne.Z * number);
        }

        /// <summary>
        /// Operator * multiplies a number by a vector.
        /// </summary>
        /// <param name="number">A number.</param>
        /// <param name="vectorOne">The first vector.</param>
        /// <returns>Returns the vector after multiplication.</returns>
        public static Vector operator *(double number, Vector vectorOne)
        {
            return new Vector(
                vectorOne.X * number,
                vectorOne.Y * number,
                vectorOne.Z * number);
        }

        /// <summary>
        /// Operator / divides a vector by a number.
        /// </summary>
        /// <param name="vectorOne">The first vector.</param>
        /// <param name="number">A number.</param>
        /// <returns>Returns the vector after division.</returns>
        public static Vector operator /(Vector vectorOne, double number)
        {
            return new Vector(
                vectorOne.X / number,
                vectorOne.Y / number,
                vectorOne.Z / number);
        }

        /// <summary>
        /// Operator / divides a number by a vector.
        /// </summary>
        /// <param name="number">The first number.</param>
        /// <param name="vectorOne">The first vector.</param>
        /// <returns>Returns the vector after division.</returns>
        public static Vector operator /(double number, Vector vectorOne)
        {
            return new Vector(
                number / vectorOne.X,
                number / vectorOne.Y,
                number / vectorOne.Z);
        }

        /// <summary>
        /// Comparison of the properties of vectors.
        /// </summary>
        /// <param name="obj">Object.</param>
        /// <returns>Returns bool after comparison.</returns>
        public override bool Equals(Object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;
            Vector v = (Vector)obj;
            return (X.Equals(v.X) && Y.Equals(v.Y) && Z.Equals(v.Z));
        }

        /// <summary>
        /// Calculate hash code.
        /// </summary>
        /// <returns>The total hesh code.</returns>
        public override int GetHashCode()
        {
            return 33 * X.GetHashCode() + Y.GetHashCode()
                + Z.GetHashCode();
        }
    }
}
