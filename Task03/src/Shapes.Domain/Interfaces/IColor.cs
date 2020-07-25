using Shapes.Domain.Enum;

namespace Shapes.Domain.Interfaces
{
    public interface IColor
    {
        bool IsReColored { get;}
        Color Color { get; set; }
    }
}
