using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Calculime.DataStructures.Values;

namespace Calculime.Operations.UnaryOperations
{
    public abstract class UnaryOperation : Operation
    {
        public UnaryOperation()
        {
            Precedence = HIGH;
        }

        public abstract Value executeUnary(Value value);
    }
}
