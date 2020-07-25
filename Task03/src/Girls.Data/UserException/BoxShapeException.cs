using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Girls.Data.UserException
{
    public class BoxShapeException : Exception
    {
        public BoxShapeException(string message) : base(message){}

        public BoxShapeException():this("Box shape exception"){}
    }
}
