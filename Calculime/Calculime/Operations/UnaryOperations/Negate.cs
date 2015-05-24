using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Calculime.DataStructures.Values;

namespace Calculime.Operations.UnaryOperations
{
    public class Negate : UnaryOperation
    {
        public Negate()
        {
            Symbol = "-/+";
        }

        public override Value executeUnary(Value value)
        {
            return -value;
        }
    }
}
