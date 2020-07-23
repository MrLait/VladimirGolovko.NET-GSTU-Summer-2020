using Shapes.Domain.Enum;
using Shapes.Domain.Interfaces;

namespace Shapes.Domain
{
    /// <summary>
    /// Base abstract class for others shapes.
    /// </summary>
    public abstract class BaseShape : IFilm, IPaper
    {
        public BaseShape()
        {
        }

        public BaseShape(IMaterial previousShape, IMaterial currentShape)
        {
            var basePrevShape = (BaseShape)previousShape;
            var baseCurShape = (BaseShape)currentShape;

            if (basePrevShape.Area < baseCurShape.Area)
            {
                throw new System.ArgumentException("The cut shape cannot be larger than the previous shape.");
            }
        }

        public BaseShape(Color color)
        {
            Color = color;
        }

        public Color Color { get; set; }

        public abstract bool IsFilm { get; set; }

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