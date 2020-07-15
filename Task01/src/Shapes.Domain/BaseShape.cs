using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes.Domain
{
    public abstract class BaseShape
    {
        public abstract double Area { get; }

        public abstract double Perimeter { get; }

        public override string ToString() => GetType().Name;
    }
}