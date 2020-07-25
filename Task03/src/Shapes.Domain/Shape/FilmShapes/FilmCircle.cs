using Shapes.Domain.Interfaces;
using Shapes.Domain.Shape.AbstractShapes;

namespace Shapes.Domain.Shape.FilmShapes
{
    public class FilmCircle : AbstractCircle, IFilm
    {
        public FilmCircle(double radius) : base(radius){}

        public FilmCircle(BaseAbstractShape curShape, FilmCircle cutShape) : base(curShape, cutShape)
        {
        }

    }
}
