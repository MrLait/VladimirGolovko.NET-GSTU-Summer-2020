using Shapes.Domain.Interfaces;
using Shapes.Domain.Shape.AbstractShapes;

namespace Shapes.Domain.Shape.FilmShapes
{
    /// <summary>
    /// A circle made of film material.
    /// </summary>
    public class FilmCircle : AbstractCircle, IFilm
    {
        /// <summary>
        /// Constructor to create circle with radius.
        /// </summary>
        /// <param name="radius">Radius parameter.</param>
        public FilmCircle(double radius) : base(radius){}

        /// <summary>
        /// Constructor to cut figure from another.
        /// </summary>
        /// <param name="curShape">The original shape to cut from.</param>
        /// <param name="cutShape">The shape that should turn out.</param>
        public FilmCircle(BaseAbstractShape curShape, FilmCircle cutShape) : base(curShape, cutShape)
        {
        }

    }
}
