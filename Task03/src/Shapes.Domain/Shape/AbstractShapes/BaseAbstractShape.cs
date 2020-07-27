using Shapes.Domain.UserExceprion;

namespace Shapes.Domain.Shape.AbstractShapes
{
    /// <summary>
    /// Base abstract class for others shapes.
    /// </summary>
    public abstract class BaseAbstractShape
    {
        /// <summary>
        /// Empty costructor.
        /// </summary>
        public BaseAbstractShape()
        {
        }

        /// <summary>
        /// Constructor to cut figure from another.
        /// </summary>
        /// <param name="curShape">The original shape to cut from.</param>
        /// <param name="cutShape">The shape that should turn out.</param>
        public BaseAbstractShape(BaseAbstractShape curShape, BaseAbstractShape cutShape)
        {
            ShapeException.AreaEqualitysHandler(curShape, cutShape);
        }

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