using Shapes.Domain.Interfaces;
using Shapes.Domain.Shape.AbstractShapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes.Domain.Shape.FilmShapes
{
    public class FilmRectangle : AbstractRectangle, IFilm
    {
        public FilmRectangle(double length, double width) : base(length, width){}

        public FilmRectangle(BaseAbstractShape curShape, FilmRectangle cutShape) : base(curShape,cutShape){}
    }
}
