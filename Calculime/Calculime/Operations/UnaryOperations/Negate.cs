using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculime.Operations.UnaryOperations
{
    public class Negate : UnaryOperation
    {
        public Negate()
        {
            symbol = "-/+";
        }

        public override Value executeUnary(Value value)
        {
            return value.negate();
        }
    }
}
