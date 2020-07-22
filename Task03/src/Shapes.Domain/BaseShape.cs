using Shapes.Domain.Enum;

namespace Shapes.Domain
{
    /// <summary>
    /// Base abstract class for others shapes.
    /// </summary>
    public abstract class BaseShape
    {
        public BaseShape()
        {
        }
        public BaseShape(Color color)
        {
            Color = color;
        }

        public Color Color { get; set; }

        /// <summary>
        /// Abstract property area.
        /// </summary>
        public abstract double Area { get; }

        /// <summary>
        /// Abstract property perimeter.
        /// </summary>
        public abstract double Perimeter { get; }

        /// <summary>
        /// Ovverriden method for get name of class.
        /// </summary>
        /// <returns></returns>
        public override string ToString() => GetType().Name;
    }
}