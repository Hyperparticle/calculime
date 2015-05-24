using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Calculime.DataStructures.Values;

namespace Calculime.Operations.UnaryOperations
{
    public class SquareRoot : UnaryOperation
    {
        public SquareRoot()
        {
            Symbol = "SQRT";
        }

        public override Value executeUnary(Value value)
        {
			value.Val = Math.Sqrt(value.Val);
            return value;
        }
    }
}
