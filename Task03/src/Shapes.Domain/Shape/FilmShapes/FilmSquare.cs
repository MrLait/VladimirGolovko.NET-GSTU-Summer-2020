using Shapes.Domain.Interfaces;
using Shapes.Domain.Shape.AbstractShapes;

namespace Shapes.Domain.Shape.FilmShapes
{
    /// <summary>
    /// A square made of film material.
    /// </summary>
    public class FilmSquare : AbstractSquare, IFilm
    {
        /// <summary>
        /// Constructor to create square with length.
        /// </summary>
        /// <param name="length">Lenth parameter.</param>
        public FilmSquare(double length) : base(length) { }

        /// <summary>
        /// Constructor to cut figure from another.
        /// </summary>
        /// <param name="curShape">The original shape to cut from.</param>
        /// <param name="cutShape">The shape that should turn out.</param>
        public FilmSquare(BaseAbstractShape curShape, FilmSquare cutShape) : base(curShape,cutShape){}
    }
}
