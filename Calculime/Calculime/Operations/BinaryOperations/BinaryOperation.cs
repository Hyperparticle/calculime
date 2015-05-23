using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Calculime.DataStructures.Values;

namespace Calculime.Operations.BinaryOperations
{
    public abstract class BinaryOperation : Operation
    {
        public abstract Value executeBinary(Value value1, Value value2);
    }
}
