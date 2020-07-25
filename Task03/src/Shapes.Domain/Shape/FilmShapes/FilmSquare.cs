using Shapes.Domain.Interfaces;
using Shapes.Domain.Shape.AbstractShapes;

namespace Shapes.Domain.Shape.FilmShapes
{
    public class FilmSquare : AbstractSquare, IFilm
    {
        public FilmSquare(double length) : base(length) { }

        public FilmSquare(BaseAbstractShape curShape, FilmSquare cutShape) : base(curShape,cutShape){}
    }
}
