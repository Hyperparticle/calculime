using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculime.Operations.UnaryOperations
{
    public class SquareRoot : UnaryOperation
    {
        public SquareRoot()
        {
            symbol = "SQRT";
        }

        public override Value executeUnary(Value value)
        {
            return value.squareRoot();
        }
    }
}
