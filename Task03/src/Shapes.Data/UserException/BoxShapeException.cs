using System;

namespace Shapes.Data.UserException
{
    /// <summary>
    /// Exception class for shapes.
    /// </summary>
    public class BoxShapeException : Exception
    {
        /// <summary>
        /// Constructor to display the shape exception message.
        /// </summary>
        /// <param name="message">Exceprion message.</param>
        public BoxShapeException(string message) : base(message){}

        /// <summary>
        /// Empty consturctor.
        /// </summary>
        public BoxShapeException():this("Box shape exception"){}
    }
}
