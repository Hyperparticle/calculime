using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Calculime.DataStructures.Values;

namespace Calculime.Operations.UnaryOperations
{
    public class Inverse : UnaryOperation
    {
        public Inverse()
        {
            Symbol = "1/x";
        }

        public override Value executeUnary(Value value)
        {
			value.Val = 1 / value.Val;
			return value;
        }
    }
}
