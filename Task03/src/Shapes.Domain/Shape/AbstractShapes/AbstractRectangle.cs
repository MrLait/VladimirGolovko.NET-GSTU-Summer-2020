﻿namespace Shapes.Domain.Shape.AbstractShapes
{
    /// <summary>
    ///  Class rectangle shape.
    /// </summary>
    public abstract class AbstractRectangle
    {

        ////public Rectangle(IMaterial previousShape, IMaterial currentShape) : base(previousShape, currentShape)
        ////{
        ////    Rectangle curRectangle;
        ////    try
        ////    {
        ////        curRectangle = (Rectangle)currentShape;
        ////    }
        ////    catch (InvalidCastException)
        ////    {
        ////        throw new InvalidCastException();
        ////    }
        ////    Length = curRectangle.Length;
        ////    Width = curRectangle.Width;
        ////}

        ////public Rectangle(double length, double width)
        ////{
        ////    Length = length;
        ////    Width = width;
        ////}



        ///// <summary>
        ///// Property length
        ///// </summary>
        ////public double Length { get; private set; }

        ///// <summary>
        ///// Property width
        ///// </summary>
        ////public double Width { get; private set; }

        ///// <summary>
        ///// Property to getting area of rectangle.
        ///// </summary>
        ////public override double Area => GetArea();

        ///// <summary>
        ///// Property to getting perimeter of rectangle.
        ///// </summary>
        ////public override double Perimeter => GetPerimeter();

        ////private double GetArea() => Length * Width;
        ////private double GetPerimeter() => 2 * Length + 2 * Width;

        ///// <summary>
        ///// Comparing one rectangle with another.
        ///// </summary>
        ///// <param name = "obj" > The compared rectangle.</param>
        ///// <returns>True if equal.False if not equal.</returns>
        ////public override bool Equals(Object obj)
        ////{
        ////    if (obj == null || GetType() != obj.GetType())
        ////        return false;
        ////    Rectangle r = (Rectangle)obj;
        ////    return Length.Equals(r.Length) && Width.Equals(r.Width);
        ////}

        ///// <summary>
        ///// Calculate hash code.
        ///// </summary>
        ///// <returns>The total hesh code.</returns>
        ////public override int GetHashCode()
        ////{
        ////    return Tuple.Create(Length, Width).GetHashCode();
        ////}

        ///// <summary>
        ///// Represents class members in string format.
        ///// </summary>
        ///// <returns>Returns class members in string format.</returns>
        ////public override string ToString()
        ////{
        ////    return string.Format("{0};{1};{2}", base.ToString(), Length, Width);
        ////}
    }
}