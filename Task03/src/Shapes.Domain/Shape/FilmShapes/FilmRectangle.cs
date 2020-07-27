using Shapes.Domain.Interfaces;
using Shapes.Domain.Shape.AbstractShapes;

namespace Shapes.Domain.Shape.FilmShapes
{
    /// <summary>
    /// A rectangle made of film material.
    /// </summary>
    public class FilmRectangle : AbstractRectangle, IFilm
    {
        /// <summary>
        /// Constructor to create rectangle with length and width.
        /// </summary>
        /// <param name="length">Lenth parameter.</param>
        /// <param name="width">Width parameter.</param>
        public FilmRectangle(double length, double width) : base(length, width){}

        /// <summary>
        /// Constructor to cut figure from another.
        /// </summary>
        /// <param name="curShape">The original shape to cut from.</param>
        /// <param name="cutShape">The shape that should turn out.</param>
        public FilmRectangle(BaseAbstractShape curShape, FilmRectangle cutShape) : base(curShape,cutShape){}
    }
}
