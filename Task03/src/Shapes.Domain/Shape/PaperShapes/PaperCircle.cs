using Shapes.Domain.Enum;
using Shapes.Domain.Interfaces;
using Shapes.Domain.Shape.AbstractShapes;
using Shapes.Domain.UserExceprion;

namespace Shapes.Domain.Shape.PaperShapes
{
    public class PaperCircle : AbstractCircle, IColor
    {
        private bool _isReColored = false;
        private Color _color;

        public PaperCircle(double radius, Color color):base(radius)
        {
           _color = color;
        }

        public PaperCircle(BaseAbstractShape prevShape, PaperCircle curShape) : base(prevShape, curShape)
        {
            var paperPrevShape = (IColor)prevShape;
            var paperPrevShapeColor = paperPrevShape.Color;
            ShapeException.ColorEqualsHandler(paperPrevShapeColor, curShape.Color);
            Color = curShape.Color;
        }

        public bool IsReColored => _isReColored;

        public Color Color
        {
            get => _color;

            set
            {
                if (!_isReColored)
                {
                    _color = value;
                    _isReColored = true;
                }
                else
                    throw new ShapeException("A paper figure can only be painted once.");
            }
        }

    }
}
