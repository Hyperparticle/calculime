using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculime.Operations.UnaryOperations
{
    public class Square : UnaryOperation
    {
        public Square()
        {
            symbol = "^2";
        }

        public override Value executeUnary(Value value)
        {
            return value.multiply(value);
        }
    }
}
