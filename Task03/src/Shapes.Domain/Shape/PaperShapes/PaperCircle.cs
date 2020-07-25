using Shapes.Domain.Enum;
using Shapes.Domain.Interfaces;
using Shapes.Domain.Shape.AbstractShapes;
using Shapes.Domain.UserExceprion;

namespace Shapes.Domain.Shape.PaperShapes
{
    public class PaperCircle : AbstractCircle, IColor
    {

        public PaperCircle(double radius, Color color):base(radius)
        {
            Color = color;
        }

        public PaperCircle(BaseAbstractShape prevShape, PaperCircle curShape) : base(prevShape, curShape)
        {
            var paperPrevShape = (IColor)prevShape;
            var paperPrevShapeColor = paperPrevShape.Color;
            ShapeException.ColorEqualsHandler(paperPrevShapeColor, curShape.Color);
            Color = curShape.Color;
        }

        public Color Color { get; set; }
    }
}
