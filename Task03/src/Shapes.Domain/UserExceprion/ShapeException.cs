using Shapes.Domain.Enum;
using Shapes.Domain.Interfaces;
using Shapes.Domain.Shape.AbstractShapes;
using System;
using System.Linq;

namespace Shapes.Domain.UserExceprion
{
    /// <summary>
    /// Exception class for shapes.
    /// </summary>
    public class ShapeException : Exception
    {
        /// <summary>
        /// Constructor to display the box shape exception message.
        /// </summary>
        /// <param name="message">Exceprion message.</param>
        public ShapeException(string message) : base(message){}

        /// <summary>
        /// Empty consturctor.
        /// </summary>
        public ShapeException():this("Shape exceprion"){}


        internal static void AreaEqualitysHandler(BaseAbstractShape curShape, BaseAbstractShape cutShape)
        {
            if (curShape.Area < cutShape.Area)
                throw new ShapeException($"The area of ​​the cut shape '{cutShape.ToString()}' cannot be larger than the current shape '{curShape.ToString()}'.");
        }

        internal static void MaterialEqualsHandler(BaseAbstractShape curShape, BaseAbstractShape cutShape)
        {
            var materialCurShape = curShape.GetType().GetInterfaces()
                .Where(i => i.GetInterfaces().Contains(typeof(IMaterial)))
                .ToList();
            var materialCutShape = cutShape.GetType().GetInterfaces()
                .Where(i => i.GetInterfaces().Contains(typeof(IMaterial)))
                .ToList();

            if (!Enumerable.SequenceEqual(materialCurShape, materialCutShape))
                throw new ShapeException($"The material of ​​the cut shape '{cutShape.ToString()}' have to equal the current shape '{curShape.ToString()}'.");
        }

        internal static void ColorEqualsHandler(Color curShapeColor, Color cutShapeColor) 
        {
            if (curShapeColor  != cutShapeColor)
                throw new ShapeException($"The color of ​​the cut shape '{cutShapeColor.ToString()}' have to equal the current shape '{curShapeColor.ToString()}'.");
        }


    }
}
