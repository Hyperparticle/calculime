using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Calculime.DataStructures.Values;

namespace Calculime.Operations.UnaryOperations
{
    public class Square : UnaryOperation
    {
        public Square()
        {
            Symbol = "^2";
        }

        public override Value executeUnary(Value value)
        {
            return value * value;
        }
    }
}
