using Shapes.Domain.Enum;
using Shapes.Domain.Interfaces;
using Shapes.Domain.Shape.AbstractShapes;
using System;

namespace Shapes.Domain.UserExceprion
{
    public class ShapeException : Exception
    {
        public ShapeException(string message) : base(message){}

        public ShapeException():this("ShapeExceprion"){}


        internal static void AreaEqualitysHandler(BaseAbstractShape curShape, BaseAbstractShape cutShape)
        {
            if (curShape.Area < cutShape.Area)
                throw new ShapeException($"The area of ​​the cut shape '{cutShape.ToString()}' cannot be larger than the current shape '{curShape.ToString()}'.");
        }

        internal static void MaterialEqualsHandler(BaseAbstractShape curShape, BaseAbstractShape cutShape)
        {
            if (curShape is IColor != cutShape is IColor)
                throw new ShapeException($"The material of ​​the cut shape '{cutShape.ToString()}' have to equal the current shape '{curShape.ToString()}'.");
        }

        internal static void ColorEqualsHandler(Color curShapeColor, Color cutShapeColor) 
        {
            if (curShapeColor  != cutShapeColor)
                throw new ShapeException($"The color of ​​the cut shape '{cutShapeColor.ToString()}' have to equal the current shape '{curShapeColor.ToString()}'.");
        }


    }
}
