using Shapes.Domain.Enum;
using Shapes.Domain.Interfaces;
using Shapes.Domain.Shape.AbstractShapes;
using Shapes.Domain.UserExceprion;
using System;

namespace Shapes.Domain.Shape.PaperShapes
{
    public class PaperRectangle : AbstractRectangle, IColor
    {
        private Color _color;

        public PaperRectangle(double length, double width, Color color) : base(length, width)
        {
            _color = color;
        }

        public PaperRectangle(BaseAbstractShape curShape, PaperRectangle cutShape) : base(curShape, cutShape)
        {
            var coloredCurShape = (IColor)curShape;
            var paperPrevShapeColor = coloredCurShape.Color;
            ShapeException.ColorEqualsHandler(paperPrevShapeColor, cutShape.Color);
            _color = cutShape.Color;
        }

        public bool IsReColored { get; private set; } = false;

        public Color Color
        {
            get => _color;

            set
            {
                if (!IsReColored)
                {
                    _color = value;
                    IsReColored = true;
                }
                else
                    throw new ShapeException("A paper figure can only be painted once.");
            }
        }

        /// <summary>
        /// Comparing one circle wit another.
        /// </summary>
        /// <param name="obj">The compared circle.</param>
        /// <returns>True if equal. False if not eqal.</returns>
        public override bool Equals(Object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;
            PaperRectangle r = (PaperRectangle)obj;
            return Color.Equals(r.Color) && base.Equals((AbstractRectangle)obj);
        }

        /// <summary>
        /// Calculate hash code.
        /// </summary>
        /// <returns>The total hesh code.</returns>
        public override int GetHashCode()
        {
            return Tuple.Create(Color, base.GetHashCode()).GetHashCode();
        }

        /// <summary>
        /// Represents class members in string format.
        /// </summary>
        /// <returns>Returns class members in string format.</returns>
        public override string ToString()
        {
            return string.Format("{0};{1}", base.ToString(), Color);
        }

    }
}
