using Shapes.Domain.Enum;

namespace Shapes.Domain.Interfaces
{
    /// <summary>
    /// Paper material interface.
    /// </summary>
    public interface IPaper
    {
        /// <summary>
        /// Is recolored
        /// </summary>
        bool IsReColored { get; }
        /// <summary>
        /// Property Colors
        /// </summary>
        Color Color { get; set; }
    }
}
