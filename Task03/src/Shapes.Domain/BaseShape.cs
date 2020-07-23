using Shapes.Domain.Enum;
using Shapes.Domain.Interfaces;

namespace Shapes.Domain
{
    /// <summary>
    /// Base abstract class for others shapes.
    /// </summary>
    public abstract class BaseShape: IFilm, IPaper
    {
        public BaseShape()
        {
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

        public abstract void GetMaterial();

        /// <summary>
        /// Ovverriden method for get name of class.
        /// </summary>
        /// <returns></returns>
        public override string ToString() => GetType().Name;
    }
}